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
    public partial class Users : System.Web.UI.Page
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

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                this.Response.Redirect("~/users/AddUser.aspx", false);
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }

        private void update(int _idUser)
        {
            try
            {
                Session["updateUser"] = _idUser.ToString();
                this.Response.Redirect("~/users/UpdateUser.aspx", false);

            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }

        private void Eliminar(int _idUser)
        {
            try
            {
                DataContext dcDelete = new DcGeneralDataContext();
                User user = dcDelete.GetTable<User>().First(c => c.id == _idUser);
                dcDelete.GetTable<User>().DeleteOnSubmit(user);
                dcDelete.SubmitChanges();
                this.LinqDcUsers.RaiseViewChanged();
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }

        protected void GridViewUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int _idUser = int.Parse(e.CommandArgument.ToString());
                switch (e.CommandName)
                {
                    case "Update":
                        this.update(_idUser);
                        break;
                    case "Eliminar":
                        this.Eliminar(_idUser);
                        break;
                }
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }
    }
}