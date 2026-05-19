using System;

namespace MahHasikuyim
{
    public partial class Result2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAnswer.Text = Session["Answer2"].ToString();
            lblScore.Text = Session["Score2"].ToString();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("Question3.aspx");
        }
    }
}