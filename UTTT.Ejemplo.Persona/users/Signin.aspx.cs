using System;
using System.Data.Linq;
using System.Linq;
using UTTT.Ejemplo.Linq.Data.Entity;

namespace UTTT.Ejemplo.Persona.views
{
    public partial class Signin : System.Web.UI.Page
    {

        public bool message { get; set; }
        public string messageText { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null || Session["password"] != null || Session["role"] != null)
            {
                this.Response.Redirect("~/Menu.aspx", false);
            }
        }

        protected void btnSignin_Click(object sender, EventArgs e)
        {
            try
            {
                DataContext db = new DcGeneralDataContext();
                var cryptPass = MCrypt.Encrypt(this.password.Text.Trim());
                var username = db.GetTable<User>().FirstOrDefault(u => u.username == this.username.Text.Trim());
                var password = db.GetTable<User>().FirstOrDefault(u => u.password == cryptPass);
                

                if (username == null || password == null)
                {
                    message = true;
                    messageText = "The user or passwords is not correct";
                    return;
                }
                if (!username.active)
                {
                    message = true;
                    messageText = "User inactive contact with admin";
                    return;
                }

                Session["username"] = this.username.Text;
                Session["password"] = this.password.Text;
                Session["role"] = username.role;
                this.Response.Redirect("~/Menu.aspx", false);
            }
            catch (Exception ex)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }

        protected void btnForgetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                this.Response.Redirect("~/users/ForgetPassword.aspx", false);
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            try
            {
                this.Response.Redirect("~/users/Signup.aspx", false);
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }
    }
}