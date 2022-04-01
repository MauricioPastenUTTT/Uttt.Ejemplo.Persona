using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Linq.Data.Entity;
using UTTT.Ejemplo.Persona.Control;

namespace UTTT.Ejemplo.Persona.roles
{
    public partial class UpdateRole : System.Web.UI.Page
    {
        private SessionManager session = new SessionManager();
        public bool message { get; set; }
        public string messageText { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["username"] == null || Session["password"] == null || Session["role"] == null)
                {
                    this.Response.Redirect("~/users/Signin.aspx", false);
                }
                if (Session["role"] != null && !Session["role"].Equals(1))
                {
                    this.Response.Redirect("~/Menu.aspx", false);
                }

                int roleId = 0;

                if (Session["updateRol"] != null)
                {
                    roleId = int.Parse(Session["updateRol"].ToString());
                }

                DataContext DcGeneral = new DcGeneralDataContext();
                Role role = DcGeneral.GetTable<Role>().First(r => r.id == roleId);

                this.role.Text = role.name;
                this.description.Text = role.description;
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
                int roleId = 0;

                if (Session["updateRol"] != null)
                {
                    roleId = int.Parse(Session["updateRol"].ToString());
                }
                DataContext DcGeneral = new DcGeneralDataContext();
                Role role = DcGeneral.GetTable<Role>().First(r => r.id == roleId);
                role.name = name;
                role.description = this.description.Text.Trim();
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