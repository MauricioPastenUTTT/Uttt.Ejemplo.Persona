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
    public partial class UpdateUser : System.Web.UI.Page
    {
        public bool message { get; set; }
        public string messageText { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null || Session["password"] == null || Session["role"] == null)
                {
                    this.Response.Redirect("~/users/Signin.aspx", false);
                }
                if (Session["role"] != null && !Session["role"].Equals(1))
                {
                    this.Response.Redirect("~/Menu.aspx", false);
                }
                int userId = 0;

                if (Session["updateUser"] != null)
                {
                    userId = int.Parse(Session["updateUser"].ToString());
                }

                DataContext DcGeneral = new DcGeneralDataContext();
                User user = DcGeneral.GetTable<User>().First(r => r.id == userId);

                this.name.Text = user.name;
                this.lastname.Text = user.lastname;
                this.username.Text = user.username;
            }
        }

        protected void btnUpdateUser_Click(object sender, EventArgs e)
        {
            try
            {
                var name = this.name.Text.Trim();
                var lastname = this.lastname.Text.Trim();
                var username = this.username.Text.Trim();
                var active = Request.Form["active"];
                bool activeValue = false;

                message = false;

                if (username.Length > 16)
                {
                    message = true;
                    messageText = "The username must not contain more than 16 characters";
                    return;
                }
                if (username.Equals(String.Empty))
                {
                    message = true;
                    messageText = "The username is empty";
                    return;
                }
                if (name.Length > 16)
                {
                    message = true;
                    messageText = "The name must not contain more than 16 characters";
                    return;
                }
                if (name.Equals(String.Empty))
                {
                    message = true;
                    messageText = "The name is empty";
                    return;
                }
                if (lastname.Length > 16)
                {
                    message = true;
                    messageText = "The lastname must not contain more than 16 characters";
                    return;
                }
                if (lastname.Equals(String.Empty))
                {
                    message = true;
                    messageText = "The lastname is empty";
                    return;
                }               

                if (active == "Enabled")
                {
                    activeValue = true;

                } 
                else if ( active == "Disabled")
                {
                    activeValue = false;
                }

                int userId = 0;

                if (Session["updateUser"] != null)
                {
                    userId = int.Parse(Session["updateUser"].ToString());
                }

                DataContext DcGeneral = new DcGeneralDataContext();

                User user = DcGeneral.GetTable<User>().First(r => r.id == userId);
                user.name = name;
                user.lastname = lastname;
                user.username = username;
                //user.role = ;
                user.active = activeValue;
                DcGeneral.SubmitChanges();
                this.Response.Redirect("~/users/Users.aspx", false);
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Response.Redirect("~/users/Users.aspx", false);
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }
    }
}