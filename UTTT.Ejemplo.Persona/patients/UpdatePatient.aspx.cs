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
    public partial class UpdatePatient : System.Web.UI.Page
    {
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

                int patientId = 0;

                if (Session["updatePatient"] != null)
                {
                    patientId = int.Parse(Session["updatePatient"].ToString());
                }

                DataContext DcGeneral = new DcGeneralDataContext();
                Patient patient = DcGeneral.GetTable<Patient>().First(r => r.id == patientId);

                this.name.Text = patient.name;
                this.lastname.Text = patient.lastname;
                this.phoneNumber.Text = patient.phoneNumber.ToString();
                this.tratamient.Text = patient.tratamient.ToString();
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

        protected void btnUpdatePatient_Click(object sender, EventArgs e)
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
                    messageText = "The phoneNumber must not contain more than 10 characters";
                    return;
                }
                if (phoneNumber.Equals(String.Empty))
                {
                    message = true;
                    messageText = "The phoneNumber is empty";
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

                int patientId = 0;

                if (Session["updatePatient"] != null)
                {
                    patientId = int.Parse(Session["updatePatient"].ToString());
                }

                DataContext DcGeneral = new DcGeneralDataContext();

                Patient patient = DcGeneral.GetTable<Patient>().First(r => r.id == patientId);
                patient.name = name;
                patient.lastname = lastname;
                patient.phoneNumber = phoneNumber;
                patient.tratamient = tratamient;
                DcGeneral.SubmitChanges();
                this.Response.Redirect("~/patients/Patients.aspx", false);
            }
            catch (Exception _e)
            {

            }
        }
    }
}