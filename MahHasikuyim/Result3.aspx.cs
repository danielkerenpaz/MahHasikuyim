using System;

namespace MahHasikuyim
{
    public partial class Result3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // הגנה מפני גישה ישירה לדף ללא נתונים בסשן
            if (Session["Answer3"] == null || Session["Score3"] == null)
            {
                Response.Redirect("Question3.aspx");
                return;
            }

            lblAnswer.Text = Session["Answer3"].ToString();
            lblScore.Text = Session["Score3"].ToString();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("Question4.aspx");
        }
    }
}