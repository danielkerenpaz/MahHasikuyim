using System;

namespace MahHasikuyim
{
    public partial class Result7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // הגנה מפני גישה ישירה לדף ללא נתונים בסשן
            if (Session["Answer7"] == null || Session["Score7"] == null)
            {
                Response.Redirect("Question7.aspx");
                return;
            }

            lblAnswer.Text = Session["Answer7"].ToString();
            lblScore.Text = Session["Score7"].ToString();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("Final.aspx");
        }
    }
}