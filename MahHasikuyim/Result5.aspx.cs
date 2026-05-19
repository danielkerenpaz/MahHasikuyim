using System;

namespace MahHasikuyim
{
    public partial class Result5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAnswer.Text = Session["Answer5"].ToString();
            lblScore.Text = Session["Score5"].ToString();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("Question6.aspx");
        }
    }
}