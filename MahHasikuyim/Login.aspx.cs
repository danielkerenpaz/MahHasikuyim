using System;
using System.Data.OleDb;

namespace MahHasikuyim
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database.accdb;";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT FullName FROM Users WHERE UserEmail = @email AND UserPassword = @password";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string fullName = result.ToString();

                            Session["UserEmail"] = email;
                            Session["Email"] = email;
                            Session["FullName"] = fullName;
                            Session["TotalScore"] = 0;

                            // הדלקת הגדרת מנהל ב-Session אם זה המייל שלך (בשביל התפריטים באתר)
                            if (email.ToLower() == "danielkerenpaz@gmail.com")
                            {
                                Session["IsAdmin"] = true;
                            }
                            else
                            {
                                Session["IsAdmin"] = false;
                            }

                            Response.Redirect("Question1.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('כתובת האימייל או הסיסמה אינם נכונים.');</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string safeMessage = ex.Message.Replace("'", "\"");
                Response.Write("<script>alert('שגיאת מסד נתונים: " + safeMessage + "');</script>");
            }
        }
    }
}