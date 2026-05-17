using System;

namespace MahHasikuyim
{
    public partial class Question3 : System.Web.UI.Page
    {
        protected void btnHint_Click(object sender, EventArgs e)
        {
            lblHint.Text = "התשובה לא חייבת להיות שלמה והיא גדולה מ־1%";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            double userAnswer = Convert.ToDouble(txtAnswer.Text);

            double realAnswer = 3;

            int score = 100 - (int)Math.Abs(realAnswer - userAnswer);

            if (score < 0)
            {
                score = 0;
            }

            Session["Answer3"] = realAnswer;
            Session["Score3"] = score;

            Response.Redirect("Result3.aspx");
        }
    }
}