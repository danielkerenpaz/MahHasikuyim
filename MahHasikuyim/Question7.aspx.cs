using System;

namespace MahHasikuyim
{
    public partial class Question7 : System.Web.UI.Page
    {
        protected void btnHint_Click(object sender, EventArgs e)
        {
            lblHint.Text = "התשובה לא חייבת להיות שלמה והיא גדולה מ־0.1%";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            double userAnswer = Convert.ToDouble(txtAnswer.Text);

            double realAnswer = 0.3;

            int score = 100 - (int)Math.Abs(realAnswer - userAnswer);

            if (score < 0)
            {
                score = 0;
            }

            Session["Answer7"] = realAnswer;
            Session["Score7"] = score;

            Response.Redirect("Result7.aspx");
        }
    }
}