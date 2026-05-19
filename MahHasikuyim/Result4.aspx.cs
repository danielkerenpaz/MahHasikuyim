using System;

namespace MahHasikuyim
{
    public partial class Result4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAnswer.Text = Session["Answer4"].ToString();
            lblScore.Text = Session["Score4"].ToString();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("Question5.aspx");
        }
    }
}