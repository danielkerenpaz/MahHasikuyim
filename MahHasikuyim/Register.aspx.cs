using System;

namespace MahHasikuyim
{
    public partial class Register : System.Web.UI.Page
    {
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Session["FullName"] = txtFirstName.Text + " " + txtLastName.Text;
            Session["Email"] = txtEmail.Text;

            Response.Redirect("Question1.aspx");
        }
    }
}