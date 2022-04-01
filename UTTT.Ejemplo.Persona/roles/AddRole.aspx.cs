using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Linq.Data.Entity;

namespace UTTT.Ejemplo.Persona.roles
{
    public partial class AddRole : System.Web.UI.Page
    {
        public bool message { get; set; }
        public string messageText { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["password"] == null || Session["role"] == null)
            {
                this.Response.Redirect("~/users/Signin.aspx", false);
            }
            if (Session["role"] != null && !Session["role"].Equals(1))
            {
                this.Response.Redirect("~/Menu.aspx", false);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var name = this.role.Text.Trim();
                var description = this.description.Text.Trim();

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
                if (description.Length > 50)
                {
                    message = true;
                    messageText = "The description must not contain more than 50 characters";
                    return;
                }
                if (description.Equals(String.Empty))
                {
                    message = true;
                    messageText = "The description is empty";
                    return;
                }
                DataContext DcGeneral = new DcGeneralDataContext();
                Role role = new Role
                {
                    name = name,
                    description = description,
                };

                DcGeneral.GetTable<Role>().InsertOnSubmit(role);
                DcGeneral.SubmitChanges();
                this.Response.Redirect("~/roles/Roles.aspx", false);
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
                this.Response.Redirect("~/roles/Roles.aspx", false);
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }
    }
}