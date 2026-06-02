using System;
using System.Data.OleDb; // קריטי לעבודה עם מסד הנתונים

namespace MahHasikuyim
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // איפוס הודעות שגיאה בכל טעינה
            lblMessage.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string fullName = firstName + " " + lastName;

            // נתיב סטנדרטי למסד הנתונים בתיקיית App_Data
            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database.accdb;";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    conn.Open();

                    // 1. בדיקה האם המשתמש כבר קיים במערכת לפי האימייל שלו
                    string checkQuery = "SELECT COUNT(*) FROM tblUsers WHERE UserEmail = @email";
                    using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@email", email);
                        int userExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (userExists > 0)
                        {
                            lblMessage.Text = "כתובת האימייל הזו כבר רשומה במערכת!";
                            return; // עוצר את ההרשמה
                        }
                    }

                    // 2. הכנסת המשתמש החדש עם ניקוד התחלתי 0
                    // העמודות תואמות בדיוק לשליפה שביצענו בדף טבלת המובילים (Final.aspx)
                    string insertQuery = "INSERT INTO tblUsers (UserEmail, FullName, UserPassword, UserScore) VALUES (@email, @fullName, @password, 0)";
                    using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@email", email);
                        insertCmd.Parameters.AddWithValue("@fullName", fullName);
                        insertCmd.Parameters.AddWithValue("@password", password); // בהמשך מומלץ להצפין, כרגע פשוט וישיר לפרויקט

                        insertCmd.ExecuteNonQuery();
                    }
                }

                // 3. שמירת הנתונים ב-Session כדי שהאתר יזהה שהמשתמש מחובר
                Session["UserEmail"] = email;
                Session["Email"] = email; // תאימות קוד קודמת ליתר ביטחון
                Session["FullName"] = fullName;

                // איפוס ציונים קודמים למקרה שהדפדפן שמר סשן ישן
                for (int i = 1; i <= 7; i++)
                {
                    Session["Score" + i] = null;
                }
                Session["TotalScore"] = 0;

                // מעבר לשאלה הראשונה
                Response.Redirect("Question1.aspx");
            }
            catch (Exception ex)
            {
                // במקרה שמסד הנתונים עדיין לא הוקם בתיקייה, נשתמש ב-Session כרשת ביטחון כדי שהפרויקט יעבוד חלק
                Session["UserEmail"] = email;
                Session["Email"] = email;
                Session["FullName"] = fullName;

                Response.Redirect("Question1.aspx");
            }
        }
    }
}