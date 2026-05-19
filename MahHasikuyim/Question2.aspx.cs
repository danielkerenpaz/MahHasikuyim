using System;

namespace MahHasikuyim
{
    public partial class Question2 : System.Web.UI.Page
    {
        double realAnswer = 5;

        protected void btnHint_Click(object sender, EventArgs e)
        {
            lblHint.Text = "התשובה היא גדולה מ־1%";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            double userAnswer = Convert.ToDouble(txtAnswer.Text);

            int score = 100 - (int)(Math.Abs(realAnswer - userAnswer) * 10);

            if (score < 0)
            {
                score = 0;
            }

            Session["Answer2"] = realAnswer;
            Session["Score2"] = score;

            Response.Redirect("Result2.aspx");
        }
    }
}
