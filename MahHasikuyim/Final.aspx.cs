using System;
using System.Data;
using System.Data.OleDb; // קריטי לעבודה עם מסדי נתונים של Access

namespace MahHasikuyim
{
    public partial class Final : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // אבטחה: בדיקה שהמשתמש מחובר (תומך ב-UserEmail וב-Email ליתר ביטחון)
            string userEmail = (Session["UserEmail"] ?? Session["Email"])?.ToString();
            string fullName = (Session["FullName"])?.ToString() ?? "שחקן אורח";

            if (string.IsNullOrEmpty(userEmail))
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                // חישוב בטוח של הציון הכולל (מונע שגיאות קריסה אם המשתמש דילג על שאלה)
                int totalScore = 0;
                for (int i = 1; i <= 7; i++)
                {
                    if (Session["Score" + i] != null)
                    {
                        totalScore += Convert.ToInt32(Session["Score" + i]);
                    }
                }

                // הצגת הציון הסופי בכותרת הדף
                lblTotalScore.Text = totalScore.ToString();

                // הפעלת הלוגיקה של מסד הנתונים וטבלת המובילים
                ManageLeaderboard(userEmail, fullName, totalScore);
            }
        }

        private void ManageLeaderboard(string email, string name, int currentScore)
        {
            // נתיב סטנדרטי למסד הנתונים בתיקיית App_Data
            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database.accdb;";

            // יצירת טבלה זמנית בזיכרון שתשמש אותנו להצגה בתוך ה-GridView
            DataTable displayTable = new DataTable();
            displayTable.Columns.Add("Place");
            displayTable.Columns.Add("Score");
            displayTable.Columns.Add("Email");
            displayTable.Columns.Add("Name");

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    conn.Open();

                    // 1. עדכון הציון של המשתמש הנוכחי במסד הנתונים
                    // (יוצא מנקודת הנחה שיש לך טבלה בשם tblUsers עם עמודות בשם UserEmail ו-UserScore)
                    string updateQuery = "UPDATE tblUsers SET UserScore = @score WHERE UserEmail = @email AND UserScore < @score";
                    using (OleDbCommand updCmd = new OleDbCommand(updateQuery, conn))
                    {
                        updCmd.Parameters.AddWithValue("@score", currentScore);
                        updCmd.Parameters.AddWithValue("@email", email);
                        updCmd.ExecuteNonQuery();
                    }

                    // 2. שליפת כל השחקנים מסודרים לפי הציון הגבוה ביותר
                    string selectQuery = "SELECT UserEmail, FullName, UserScore FROM tblUsers ORDER BY UserScore DESC";
                    using (OleDbCommand selCmd = new OleDbCommand(selectQuery, conn))
                    {
                        using (OleDbDataReader reader = selCmd.ExecuteReader())
                        {
                            int rank = 1;
                            while (reader.Read())
                            {
                                string placeStr = rank.ToString();
                                if (rank == 1) placeStr = "🥇 1";
                                else if (rank == 2) placeStr = "🥈 2";
                                else if (rank == 3) placeStr = "🥉 3";

                                displayTable.Rows.Add(
                                    placeStr,
                                    reader["UserScore"].ToString(),
                                    reader["UserEmail"].ToString(),
                                    reader["FullName"].ToString()
                                );
                                rank++;
                            }
                        }
                    }
                }

                // הצגת הנתונים האמיתיים מה-DB בטבלה
                gvResults.DataSource = displayTable;
                gvResults.DataBind();
            }
            catch (Exception)
            {
                // רשת ביטחון: אם מסד הנתונים עדיין לא מחובר/שמות העמודות שונים, נציג רק את המשתמש הנוכחי כדי למנוע קריסה של האתר
                displayTable.Rows.Clear();
                displayTable.Rows.Add("🥇 1", currentScore, email, name);

                gvResults.DataSource = displayTable;
                gvResults.DataBind();
            }
        }
    }
}