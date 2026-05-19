using System;

namespace MahHasikuyim
{
    public partial class Result6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAnswer.Text = Session["Answer6"].ToString();
            lblScore.Text = Session["Score6"].ToString();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("Question7.aspx");
        }
    }
}