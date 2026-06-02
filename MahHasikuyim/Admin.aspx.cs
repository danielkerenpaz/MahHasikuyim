using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI;

namespace MahHasikuyim
{
    public partial class Admin : System.Web.UI.Page
    {
        // מחרוזת התחברות למסד הנתונים MS Access (ודא ששם הקובץ והנתיב מתאימים לפרויקט שלך)
        private string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database.accdb;";

        protected void Page_Load(object sender, EventArgs e)
        {
            // אבטחת הדף: רק משתמש מחובר שהוגדר ב-Session כמנהל (IsAdmin = true) יכול לצפות בדף
            if (Session["UserEmail"] == null || Session["IsAdmin"] == null || !(bool)Session["IsAdmin"])
            {
                // אם הוא לא מנהל - הוא נזרק החוצה באופן מיידי לדף הבית או לדף כניסה
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
            lblMessage.Text = "";

            // שאילתת הבסיס - שליפת הפרטים הרלוונטיים מטבלת המשתמשים (Users)
            string query = "SELECT UserEmail, FullName, TotalScore, IsAdmin FROM Users";

            // אם המנהל כתב משהו בתיבת החיפוש - נוסיף תנאי סינון (WHERE) לשאילתה
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query += " WHERE UserEmail LIKE @search OR FullName LIKE @search";
            }

            // שימוש ב-using סוגר ומנקה את הזיכרון אוטומטית במקרה של שגיאה כדי למנוע נעילת קובץ ה-Access
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

                        if (dt.Rows.Count == 0)
                        {
                            lblMessage.Text = "לא נמצאו משתמשים העונים לקריטריון החיפוש.";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "שגיאה בטעינת הנתונים: " + ex.Message;
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