using System;

namespace MahHasikuyim
{
    public partial class Result1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // הגנה מפני גישה ישירה לדף ללא נתונים בסשן
            if (Session["Answer1"] == null || Session["Score1"] == null)
            {
                Response.Redirect("Question1.aspx");
                return;
            }

            // הצגת הנתונים
            lblAnswer.Text = Session["Answer1"].ToString();
            lblScore.Text = Session["Score1"].ToString();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("Question2.aspx");
        }
    }
}