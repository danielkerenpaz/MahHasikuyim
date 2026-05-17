using System;

namespace MahHasikuyim
{
    public partial class Question5 : System.Web.UI.Page
    {
        protected void btnHint_Click(object sender, EventArgs e)
        {
            lblHint.Text = "התשובה לא חייבת להיות שלמה והיא גדולה מ־1%";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            double userAnswer = Convert.ToDouble(txtAnswer.Text);

            double realAnswer = 1;

            int score = 100 - (int)Math.Abs(realAnswer - userAnswer);

            if (score < 0)
            {
                score = 0;
            }

            Session["Answer5"] = realAnswer;
            Session["Score5"] = score;

            Response.Redirect("Result5.aspx");
        }
    }
}