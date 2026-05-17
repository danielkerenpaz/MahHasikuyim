using System;
using System.Data;
using System;
using System.Data;

namespace MahHasikuyim
{
    public partial class Final : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Place");
            dt.Columns.Add("Score");
            dt.Columns.Add("Email");
            dt.Columns.Add("Name");

            int total =
                Convert.ToInt32(Session["Score1"]) +
                Convert.ToInt32(Session["Score2"]) +
                Convert.ToInt32(Session["Score3"]) +
                Convert.ToInt32(Session["Score4"]) +
                Convert.ToInt32(Session["Score5"]) +
                Convert.ToInt32(Session["Score6"]) +
                Convert.ToInt32(Session["Score7"]);

            dt.Rows.Add(
                "🥇 1",
                total,
                Session["Email"],
                Session["FullName"]
            );

            gvResults.DataSource = dt;
            gvResults.DataBind();
        }
    }
}