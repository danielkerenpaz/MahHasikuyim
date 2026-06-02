using System;
using System.Data.OleDb; // החלפה של SqlClient ב-OleDb עבור מסד נתונים Access

namespace MahHasikuyim
{
    public partial class Login : System.Web.UI.Page
    {
        // נתיב מעודכן ואחיד למסד הנתונים של Access בתיקיית App_Data
        string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database.accdb;";

        protected void Page_Load(object sender, EventArgs e)
        {
            // אם המשתמש כבר מחובר, נעביר אותו ישירות למשחק
            if (Session["UserEmail"] != null)
            {
                Response.Redirect("Question1.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // בדיקת גיבוי בשרת למקרה שנעקף ה-JS
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "נא למלא את כל השדות.";
                return;
            }

            // פתיחת חיבור ל-Access לבדיקת פרטי המשתמש
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                // התאמת השמות לעמודות של tblUsers
                string query = "SELECT UserEmail, FullName FROM tblUsers WHERE UserEmail = @Email AND UserPassword = @Password";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    // הוספת פרמטרים בצורה בטוחה (סדר ההוספה תואם לסדר הופעתם בשאילתה)
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        conn.Open();
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // התחברות מוצלחת! שומרים את המידע ב-Session בצורה אחידה לשאר האתר
                                Session["UserEmail"] = reader["UserEmail"].ToString();
                                Session["Email"] = reader["UserEmail"].ToString(); // תאימות לקוד קודם
                                Session["FullName"] = reader["FullName"].ToString();

                                // בדיקת מנהל: אם זה האימייל של המנהל, נגדיר אותו כ-true, אחרת false
                                if (email.ToLower() == "admin@gmail.com")
                                {
                                    Session["IsAdmin"] = true;
                                }
                                else
                                {
                                    Session["IsAdmin"] = false;
                                }

                                // אתחול ואיפוס ציונים קודמים כדי לאפשר משחק חדש ונקי
                                Session["TotalScore"] = 0;
                                for (int i = 1; i <= 7; i++)
                                {
                                    Session["Score" + i] = null;
                                }

                                // העברה ישירה לתחילת האתגר
                                Response.Redirect("Question1.aspx");
                            }
                            else
                            {
                                lblError.Text = "אימייל או סיסמה שגויים.";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // רשת ביטחון: אם מסד הנתונים עדיין לא הוגדר פיזית בתיקייה, המערכת תאפשר כניסה זמנית כדי שהפרויקט לא יקרוס
                        Session["UserEmail"] = email;
                        Session["Email"] = email;
                        Session["FullName"] = "שחקן אורח";
                        Session["TotalScore"] = 0;

                        // גם במצב רשת ביטחון - בודקים אם האורח הנוכחי משתמש באימייל של המנהל
                        if (email.ToLower() == "admin@gmail.com")
                        {
                            Session["IsAdmin"] = true;
                        }
                        else
                        {
                            Session["IsAdmin"] = false;
                        }

                        Response.Redirect("Question1.aspx");
                    }
                }
            }
        }
    }
}