using System;

namespace MahHasikuyim
{
    public partial class Result3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAnswer.Text = Session["Answer3"].ToString();
            lblScore.Text = Session["Score3"].ToString();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("Question4.aspx");
        }
    }
}