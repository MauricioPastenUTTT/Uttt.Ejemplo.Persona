using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Linq.Data.Entity;

namespace UTTT.Ejemplo.Persona.patients
{
    public partial class AddPatient : System.Web.UI.Page
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
                this.Response.Redirect("~/patients/Patients.aspx", false);
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
                var lastname = this.lastname.Text.Trim();
                var phoneNumber = this.phoneNumber.Text.Trim();
                var tratamient = this.tratamient.Text.Trim();

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
                if (phoneNumber.Length > 10)
                {
                    message = true;
                    messageText = "The phone number must not contain more than 10 characters";
                    return;
                }
                if (phoneNumber.Equals(String.Empty))
                {
                    message = true;
                    messageText = "The phone number is empty";
                    return;
                }
                if (tratamient.Length > 50)
                {
                    message = true;
                    messageText = "The tratamient must not contain more than 50 characters";
                    return;
                }
                if (tratamient.Equals(String.Empty))
                {
                    message = true;
                    messageText = "The tratamient is empty";
                    return;
                }
                DataContext DcGeneral = new DcGeneralDataContext();

                Patient patient = new Patient
                {
                    name = name,
                    lastname = lastname,
                    phoneNumber = phoneNumber,
                    tratamient = tratamient,
                };

                DcGeneral.GetTable<Patient>().InsertOnSubmit(patient);
                DcGeneral.SubmitChanges();
                this.Response.Redirect("~/patients/Patients.aspx", false);
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }
    }
}