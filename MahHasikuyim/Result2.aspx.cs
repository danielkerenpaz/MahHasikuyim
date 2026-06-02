using System;

namespace MahHasikuyim
{
    public partial class Result2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // הגנה מפני גישה ישירה לדף ללא נתונים בסשן
            if (Session["Answer2"] == null || Session["Score2"] == null)
            {
                Response.Redirect("Question2.aspx");
                return;
            }

            lblAnswer.Text = Session["Answer2"].ToString();
            lblScore.Text = Session["Score2"].ToString();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("Question3.aspx");
        }
    }
}