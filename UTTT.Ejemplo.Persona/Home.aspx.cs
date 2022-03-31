using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UTTT.Ejemplo.Persona
{
    public partial class Home : System.Web.UI.Page
    {
        public bool role { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var sessionRole = Session["role"];
            if (sessionRole != null && sessionRole.Equals(1))
            {
                role = true;
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