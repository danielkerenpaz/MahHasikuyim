using System;

namespace MahHasikuyim
{
    public partial class Question5 : System.Web.UI.Page
    {
        double realAnswer = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            // אבטחת הדף: אם משתמש לא מחובר, הוא מועבר לדף כניסה
            if (Session["UserEmail"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            double userAnswer;

            // הגנה חסינה מפני קריסות המרה
            if (double.TryParse(txtAnswer.Text, out userAnswer))
            {
                // חישוב הניקוד לפי נוסחת אקסטרים החדשה והקשוחה (חוק ה-פי 2)
                int score = GetStrictScore(userAnswer, realAnswer);

                // שמירת נתונים ב-Session
                Session["Answer5"] = realAnswer;
                Session["Score5"] = score;

                // עדכון הניקוד המצטבר של המשחק כולו
                if (Session["TotalScore"] == null)
                    Session["TotalScore"] = score;
                else
                    Session["TotalScore"] = (int)Session["TotalScore"] + score;

                Response.Redirect("Result5.aspx");
            }
        }
        /// <summary>
        /// אלגוריתם חכם לחישוב ניקוד ברמת קושי גבוהה
        /// </summary>
        private int GetStrictScore(double userGuess, double correctAnswer)
        {
            // הגנה מפני ערכי אפס או שליליים כדי למנוע שגיאות חלוקה באפס
            if (userGuess <= 0 || correctAnswer <= 0)
            {
                return (userGuess == correctAnswer) ? 100 : 0;
            }

            // חישוב פי כמה השחקן רחוק מהתשובה (תמיד מספר שגדול או שווה ל-1)
            double ratio = Math.Max(userGuess / correctAnswer, correctAnswer / userGuess);

            // חוק ה-פי 2: אם הניחוש גדול פי 2 ומעלה, או קטן מחצי -> פוסלים מיד ל-0 נקודות!
            if (ratio >= 2.0)
            {
                return 0;
            }

            // נוסחת עונש ריבועית על בסיס היחס:
            // ככל שהשחקן מתרחק מ-1, הקנס גדל בריבוע עד שהוא מגיע ל-100 נקודות קנס בנקודת ה-פי 2
            double penalty = Math.Pow(ratio - 1, 2) * 100;

            // חישוב הציון הסופי (ומניעת ציונים שליליים מתחת ל-0)
            int finalScore = (int)Math.Max(0, 100 - penalty);

            return finalScore;
        }
    }
}



