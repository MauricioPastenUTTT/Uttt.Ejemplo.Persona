using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Linq.Data.Entity;

namespace UTTT.Ejemplo.Persona.users
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        public bool message { get; set; }
        public string messageText { get; set; }
        public bool userExists { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null || Session["password"] != null)
            {
                this.Response.Redirect("~/Home.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Response.Redirect("~/users/Signin.aspx", false);
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }

        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            try
            {
                var password = this.password.Text.Trim();
                var passwordConfirm = this.passwordConfirm.Text.Trim();

                message = false;

                if (password.Length > 16)
                {
                    message = true;
                    messageText = "The password must not contain more than 16 characters";
                    return;
                }
                if (password.Equals(String.Empty))
                {
                    message = true;
                    messageText = "The password is empty";
                    return;
                }
                if (passwordConfirm.Equals(String.Empty))
                {
                    message = true;
                    messageText = "The password confirm is empty";
                    return;
                }
                if (!password.Equals(passwordConfirm))
                {
                    message = true;
                    messageText = "The password do not match";
                    return;
                }
                var UserName = username.Text.Trim();
                DataContext DcGeneral = new DcGeneralDataContext();
                User user = DcGeneral.GetTable<User>().First(u => u.username == UserName);
                user.password = MCrypt.Encrypt(password);
                DcGeneral.SubmitChanges();
                this.Response.Redirect("~/users/Signin.aspx", false);

            }
            catch (Exception ex)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }

        protected void btnSearchUser_Click(object sender, EventArgs e)
        {
            try
            {
                var UserName = username.Text.Trim();
                if (UserName.Equals(String.Empty))
                {
                    message = true;
                    messageText = "The user is empty";
                    return;
                }
                DataContext DcGeneral = new DcGeneralDataContext();
                User user = DcGeneral.GetTable<User>().FirstOrDefault(u => u.username == UserName);
                if (user != null)
                {
                    userExists = true;
                    this.username.Enabled = false;
                } else
                {
                    message = true;
                    messageText = "The user not exists";
                    return;
                }
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }
    }
}