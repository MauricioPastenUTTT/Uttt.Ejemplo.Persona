using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UTTT.Ejemplo.Persona
{
    public partial class Menu : System.Web.UI.Page
    {
        public bool roleIsAdmin { get; set; } 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["password"] == null || Session["role"] == null)
            {
                this.Response.Redirect("~/users/Signin.aspx", false);
            }
            if (Session["role"] != null && Session["role"].Equals(1))
            {
                roleIsAdmin = true;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Session["password"] = null;
            Session["role"] = null;
            this.Response.Redirect("~/users/Signin.aspx", false);
        }
    }
}