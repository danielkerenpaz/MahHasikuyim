using System;
using System.Web;

namespace MahHasikuyim
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // בדיקה האם קיים משתמש מחובר במערכת
                if (Session["UserEmail"] != null)
                {
                    // הסתרת תפריט אורחים והצגת תפריט משתמש רשום
                    phAnonymous.Visible = false;
                    phLoggedIn.Visible = true;
                    lnkLeaderboard.Visible = true;

                    // שליפת שם המשתמש מה-Session והצגתו בברכה העליונה
                    string name = Session["FullName"] != null ? Session["FullName"].ToString() : "שחקן";
                    lblUserGreeting.Text = name;
                }
                else
                {
                    // אם המשתמש אורח - מציגים תפריט כניסה רגיל
                    phAnonymous.Visible = true;
                    phLoggedIn.Visible = false;
                    lnkLeaderboard.Visible = false;
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // ניקוי מוחלט של כל משתני ה-Session (מנתק את המשתמש ומאפס נתונים)
            Session.Clear();
            Session.Abandon();

            // העברת המשתמש חזרה לדף ההתחברות הראשי
            Response.Redirect("Login.aspx");
        }
    }
}