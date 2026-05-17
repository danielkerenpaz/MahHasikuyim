using System;

namespace MahHasikuyim
{
    public partial class Question6 : System.Web.UI.Page
    {
        protected void btnHint_Click(object sender, EventArgs e)
        {
            lblHint.Text = "התשובה לא חייבת להיות שלמה והיא גדולה מ־25%";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            double userAnswer = Convert.ToDouble(txtAnswer.Text);

            double realAnswer = 35;

            int score = 100 - (int)Math.Abs(realAnswer - userAnswer);

            if (score < 0)
            {
                score = 0;
            }

            Session["Answer6"] = realAnswer;
            Session["Score6"] = score;

            Response.Redirect("Result6.aspx");
        }
    }
}