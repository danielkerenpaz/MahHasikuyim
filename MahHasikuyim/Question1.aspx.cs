using System;

namespace MahHasikuyim
{
    public partial class Question1 : System.Web.UI.Page
    {
        double realAnswer = 0.0065;

        protected void btnHint_Click(object sender, EventArgs e)
        {
            lblHint.Text = "התשובה לא חייבת להיות שלמה והיא לא בהכרח גדולה מ-1%";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            double userAnswer = Convert.ToDouble(txtAnswer.Text);

            int score = 100 - (int)(Math.Abs(realAnswer - userAnswer) * 10);

            if (score < 0)
            {
                score = 0;
            }

            Session["Answer1"] = realAnswer;
            Session["Score1"] = score;

            Response.Redirect("Result1.aspx");
        }
    }
}