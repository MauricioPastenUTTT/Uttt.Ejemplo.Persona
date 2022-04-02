﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Linq.Data.Entity;

namespace UTTT.Ejemplo.Persona.products
{
    public partial class AddProduct : System.Web.UI.Page
    {
        public bool message { get; set; }
        public string messageText { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["password"] == null || Session["role"] == null)
            {
                this.Response.Redirect("~/users/Signin.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Response.Redirect("~/products/Products.aspx", false);
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var name = this.name.Text.Trim();
                var description = this.description.Text.Trim();
                var price = this.price.Text.Trim();
                var inStock = this.inStock.Text.Trim();

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
                if (price.Length > 5)
                {
                    message = true;
                    messageText = "The price must not contain more than 5 characters";
                    return;
                }
                if (price.Equals(String.Empty))
                {
                    message = true;
                    messageText = "The price is empty";
                    return;
                }
                if (inStock.Length > 3)
                {
                    message = true;
                    messageText = "The Stock must not contain more than 3 characters";
                    return;
                }
                if (inStock.Equals(String.Empty))
                {
                    message = true;
                    messageText = "The Stock is empty";
                    return;
                }
                DataContext DcGeneral = new DcGeneralDataContext();
                Product product = new Product
                {
                    name = name,
                    description = description,
                    price = float.Parse(price),
                    inStock = int.Parse(inStock),
                };

                DcGeneral.GetTable<Product>().InsertOnSubmit(product);
                DcGeneral.SubmitChanges();
                this.Response.Redirect("~/products/Products.aspx", false);
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }
    }
}