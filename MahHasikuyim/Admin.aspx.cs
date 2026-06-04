using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI;

namespace MahHasikuyim
{
    public partial class Admin : System.Web.UI.Page
    {
        // מחרוזת התחברות למסד הנתונים MS Access
        private string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database.accdb;";

        protected void Page_Load(object sender, EventArgs e)
        {
            // אבטחת הדף: רק המייל שלך מורשה להיכנס לפאנל הניהול
            if (Session["UserEmail"] == null || Session["UserEmail"].ToString().Trim().ToLower() != "danielkerenpaz@gmail.com")
            {
                // אם זה לא אתה - זריקה מיידית החוצה לדף הבית
                Response.Redirect("Default.aspx");
            }

            if (!IsPostBack)
            {
                // טעינה ראשונית של כל המשתמשים בטבלה
                BindUsers("");
            }
        }

        // פונקציה חכמה השולפת את המשתמשים ומסננת לפי צורך
        private void BindUsers(string searchTerm)
        {
            if (lblMessage != null)
            {
                lblMessage.Text = "";
            }

            // פתרון השגיאה: שולפים שדות קיימים ומזייפים את השאר (0 ו-False) כדי שה-GridView ב-HTML לא יתלונן
            string query = "SELECT UserEmail, FullName, 0 AS TotalScore, False AS IsAdmin FROM Users";

            // אם המנהל כתב משהו בתיבת החיפוש - נוסיף תנאי סינון (WHERE) לשאילתה
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query += " WHERE UserEmail LIKE @search OR FullName LIKE @search";
            }

            // שימוש ב-using סוגר ומנקה את הזיכרון אוטומטית למניעת נעילת קובץ ה-Access
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    // הגנה מפני SQL Injection באמצעות פרמטרים
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");
                    }

                    try
                    {
                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // קישור הנתונים שחזרו מהמסד אל ה-GridView שמציג אותם על המסך
                        gvUsers.DataSource = dt;
                        gvUsers.DataBind();

                        if (dt.Rows.Count == 0 && lblMessage != null)
                        {
                            lblMessage.Text = "לא נמצאו משתמשים העונים לקריטריון החיפוש.";
                        }
                    }
                    catch (Exception ex)
                    {
                        if (lblMessage != null)
                        {
                            lblMessage.Text = "שגיאה בטעינת הנתונים: " + ex.Message;
                        }
                        else
                        {
                            string safeMessage = ex.Message.Replace("'", "\"");
                            Response.Write("<script>alert('שגיאה בטעינת הנתונים: " + safeMessage + "');</script>");
                        }
                    }
                }
            }
        }

        // אירוע לחיצה על כפתור החיפוש
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            BindUsers(search);
        }

        // אירוע לחיצה על כפתור "הצג הכל" שמנקה את החיפוש
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            BindUsers("");
        }
    }
}