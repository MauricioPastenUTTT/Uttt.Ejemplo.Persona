using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Linq.Data.Entity;

namespace UTTT.Ejemplo.Persona.products
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["password"] == null || Session["role"] == null)
            {
                this.Response.Redirect("~/users/Signin.aspx", false);
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

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                this.Response.Redirect("~/products/AddProduct.aspx", false);
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }

        private void update(int _idProduct)
        {
            try
            {
                Session["updateProduct"] = _idProduct.ToString();
                this.Response.Redirect("~/products/UpdateProduct.aspx", false);

            }
            catch (Exception _e)
            {
                throw _e;
            }
        }

        private void Eliminar(int _idProduct)
        {
            try
            {
                DataContext dcDelete = new DcGeneralDataContext();
                Product product = dcDelete.GetTable<Product>().First(c => c.id == _idProduct);
                dcDelete.GetTable<Product>().DeleteOnSubmit(product);
                dcDelete.SubmitChanges();
                this.LinqDcUsers.RaiseViewChanged();
            }
            catch (Exception _e)
            {
                throw _e;
            }
        }

        protected void GridViewProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int _idProduct = int.Parse(e.CommandArgument.ToString());
                switch (e.CommandName)
                {
                    case "Update":
                        this.update(_idProduct);
                        break;
                    case "Eliminar":
                        this.Eliminar(_idProduct);
                        break;
                }
            }
            catch (Exception _e)
            {
            }
        }
    }
}