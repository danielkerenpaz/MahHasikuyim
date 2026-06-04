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






























// =========================================================================
//                  🎯 מדריך שליפה מהירה למבחן - פרויקט מה הסיכויים 🎯
// =========================================================================
//
// 📄 1. הוספת עמוד חדש באתר (Web Form)
// -------------------------------------------------------------------------
// 1. בצד ימין, בחלון ה-Solution Explorer, קליק ימני על שם הפרויקט (MahHasikuyim).
// 2. עומדים על Add ואז בוחרים ב-New Item...
// 3. בחלון שנפתח בוחרים ב-Web Form (או Web Form with Master Page אם יש עיצוב אחיד).
// 4. למטה ב-Name משנים את השם למה שהמורה ביקשה (למשל: Test.aspx) ולוחצים על Add.
//
// 📊 2. שינויים בטבלה (רוחב, אורך, צבע, מסגרת)
// -------------------------------------------------------------------------
// [שינוי רוחב ואורך - Width & Height]
// * בטבלת HTML רגילה:  <table style="width: 500px; height: 300px;">
// * ב-GridView של ASP:  <asp:GridView ID="gvUsers" runat="server" Width="100%" Height="200px">
//
// [שינוי צבע רקע - Background Color]
// * בטבלת HTML רגילה:  <table style="background-color: LightBlue;">
// * ב-GridView של ASP:  <asp:GridView ID="gvUsers" runat="server" BackColor="#F0F0F0">
//
// [שינוי צבע ועובי הגבול / מסגרת - Border]
// * בטבלת HTML רגילה:  <table style="border: 2px solid Red;">
// * ב-GridView של ASP:  <asp:GridView ID="gvUsers" runat="server" BorderWidth="3px" BorderColor="Blue">
//
// 🖼️ 3. הוספת תמונה, סרטון וקישורים ב-HTML
// -------------------------------------------------------------------------
// [הוספת תמונה]
// <img src="Images/myPhoto.png" width="200" height="150" alt="תיאור התמונה" />
//
// [הוספת סרטון מיוטיוב - הכי נפוץ במבחן]
// כנס ליוטיוב -> שתף -> הטמעה (Embed) -> תעתיק את ה-iframe ותדביק:
// <iframe width="560" height="315" src="https://www.youtube.com/embed/VIDEO_ID" frameborder="0" allowfullscreen></iframe>
//
// [הוספת סרטון מקומי מהמחשב]
// <video width="400" controls><source src="Videos/myVideo.mp4" type="video/mp4"></video>
//
// [הוספת קישור רגיל]
// <a href="Default.aspx">לחץ כאן לחזרה לעמוד הבית</a>
// <a href="https://www.google.com" target="_blank">פתח את גוגל בטאב חדש</a>
//
// [הוספת קישור בתוך תמונה (תמונה לחיצה)]
// <a href="Question1.aspx"><img src="Images/play.png" width="100" height="100" /></a>
//
// 👑 4. שינוי צבע של כותרת
// -------------------------------------------------------------------------
// משתמשים במאפיין style בתגיות הכותרת h1 עד h6:
// <h1 style="color: DarkGreen;">ברוכים הבאים למשחק!</h1>
// <h2 style="color: #FF5733;">כותרת משנית בצבע כתום</h2>
//
// 🎯 5. דברים מפתיעים שהמורה יכולה לבקש (רשימת הצלה)
// -------------------------------------------------------------------------
// * שינוי טקסט של כפתור: חפש את ה-Button ב-HTML ושנה את ה-Text שלו: Text="לחץ כאן"
//
// * שינוי צבע רקע של כל העמוד: חפש את תגית ה-<body> ב-HTML ותוסיף לה צבע:
//   <body style="background-color: LightGray;">
//
// * מעבר עמוד אוטומטי מתוך קוד C#: באירוע לחיצה על כפתור מוסיפים את הפקודה:
//   Response.Redirect("TargetPage.aspx");
//
// * מיון השחקנים לפי ניקוד ב-SQL (גבוה לנמוך / נמוך לגבוה):
//   מוסיפים ORDER BY בסוף מחרוזת ה-query בתוך קוד ה-C#.
//   - מהגבוה לנמוך (DESC): string query = "SELECT * FROM Users ORDER BY UserScore DESC";
//   - מהנמוך לגבוה (ASC):  string query = "SELECT * FROM Users ORDER BY UserScore ASC";
//
// * חוק ברזל: אם עשית שינוי עיצובי והוא לא מתעדכן על המסך, תלחץ על Ctrl + F5 בדפדפן!
// =========================================================================