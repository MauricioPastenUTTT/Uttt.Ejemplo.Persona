using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Linq.Data.Entity;

namespace UTTT.Ejemplo.Persona.patients
{
    public partial class Patients : System.Web.UI.Page
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

        protected void btnAddPatient_Click(object sender, EventArgs e)
        {
            try
            {
                this.Response.Redirect("~/patients/AddPatient.aspx", false);
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }

        private void update(int _idPatient)
        {
            try
            {
                Session["updatePatient"] = _idPatient.ToString();
                this.Response.Redirect("~/patients/UpdatePatient.aspx", false);

            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }

        private void Eliminar(int _idPatient)
        {
            try
            {
                DataContext dcDelete = new DcGeneralDataContext();
                Patient patient = dcDelete.GetTable<Patient>().First(c => c.id == _idPatient);
                dcDelete.GetTable<Patient>().DeleteOnSubmit(patient);
                dcDelete.SubmitChanges();
                this.LinqDcUsers.RaiseViewChanged();
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }

        protected void GridViewPatients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int _idPatient = int.Parse(e.CommandArgument.ToString());
                switch (e.CommandName)
                {
                    case "Update":
                        this.update(_idPatient);
                        break;
                    case "Eliminar":
                        this.Eliminar(_idPatient);
                        break;
                }
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }

        protected void LinqDcUsers_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            try
            {
                DataContext dcSearch = new DcGeneralDataContext();
                bool lastnameBool = false;
                if (!this.lastname.Text.Equals(String.Empty))
                {
                    lastnameBool = true;
                }

                Expression<Func<Patient, bool>>
                    predicate = (p => (lastnameBool) ? (((lastnameBool) ?
                        p.lastname.Contains(this.lastname.Text.Trim()) : false)) : true);

                predicate.Compile();

                List<Patient> patientList = dcSearch.GetTable<Patient>().Where(predicate).ToList();
                e.Result = patientList;
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }

        protected void btnSearchPatient_Click(object sender, EventArgs e)
        {
            try
            {
                this.LinqDcUsers.RaiseViewChanged();
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/PantallaError.aspx");
            }
        }
    }
}