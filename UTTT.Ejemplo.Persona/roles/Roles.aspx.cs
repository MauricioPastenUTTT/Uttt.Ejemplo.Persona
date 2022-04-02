using System;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Persona.Control;

namespace UTTT.Ejemplo.Persona.roles
{
    public partial class roles : System.Web.UI.Page
    {
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

        private void update(int _idRole)
        {
            try
            {
                Session["updateRol"] = _idRole.ToString();
                this.Response.Redirect("~/roles/UpdateRole.aspx", false);

            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }

        protected void GridViewRoles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int idRole = int.Parse(e.CommandArgument.ToString());
                switch (e.CommandName)
                {
                    case "Update":
                        this.update(idRole);
                        break;
                }
            }
            catch (Exception _e)
            {
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                this.Response.Redirect("~/Menu.aspx", false);
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }

        protected void btnAddRole_Click(object sender, EventArgs e)
        {
            try
            {
                this.Response.Redirect("~/roles/AddRole.aspx", false);
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }
    }
}