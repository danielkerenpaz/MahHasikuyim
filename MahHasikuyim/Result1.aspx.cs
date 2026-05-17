using System;

namespace MahHasikuyim
{
    public partial class Result1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAnswer.Text = Session["Answer1"].ToString();
            lblScore.Text = Session["Score1"].ToString();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("Question2.aspx");
        }
    }
}