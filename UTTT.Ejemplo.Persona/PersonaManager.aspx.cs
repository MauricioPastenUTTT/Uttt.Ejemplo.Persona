#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Linq.Data.Entity;
using System.Data.Linq;
using System.Linq.Expressions;
using System.Collections;
using UTTT.Ejemplo.Persona.Control;
using UTTT.Ejemplo.Persona.Control.Ctrl;

using System.Net.Mail;
using System.Configuration;
using System.Web.Configuration;
using System.Net.Configuration;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

#endregion

namespace UTTT.Ejemplo.Persona
{
    public partial class PersonaManager : System.Web.UI.Page
    {
        #region Variables

        private SessionManager session = new SessionManager();
        private int idPersona = 0;
        private UTTT.Ejemplo.Linq.Data.Entity.Persona baseEntity;
        private DataContext dcGlobal = new DcGeneralDataContext();
        private int tipoAccion = 0;

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.Response.Buffer = true;
                this.session = (SessionManager)this.Session["SessionManager"];
                this.idPersona = this.session.Parametros["idPersona"] != null ?
                    int.Parse(this.session.Parametros["idPersona"].ToString()) : 0;
                if (this.idPersona == 0)
                {
                    this.baseEntity = new Linq.Data.Entity.Persona();
                    this.tipoAccion = 1;
                }
                else
                {
                    this.baseEntity = dcGlobal.GetTable<Linq.Data.Entity.Persona>().First(c => c.id == this.idPersona);
                    this.tipoAccion = 2;
                }

                if (!this.IsPostBack)
                {
                    if (this.session.Parametros["baseEntity"] == null)
                    {
                        this.session.Parametros.Add("baseEntity", this.baseEntity);
                    }

                    List<CatSexo> lista = dcGlobal.GetTable<CatSexo>().ToList();
                    this.ddlSexo.DataTextField = "strValor";
                    this.ddlSexo.DataValueField = "id";

                    if (this.idPersona == 0)
                    {
                        this.lblAccion.Text = "Agregar";
                        CalendarExtender1.SelectedDate = DateTime.Now;

                        CatSexo catTemp = new CatSexo();
                        catTemp.id = -1;
                        catTemp.strValor = "Seleccionar";
                        lista.Insert(0, catTemp);
                        this.ddlSexo.DataSource = lista;
                        this.ddlSexo.DataBind();

                    }
                    else
                    {
                        this.lblAccion.Text = "Editar";
                        this.txtNombre.Text = this.baseEntity.strNombre;
                        this.txtAPaterno.Text = this.baseEntity.strAPaterno;
                        this.txtAMaterno.Text = this.baseEntity.strAMaterno;
                        this.txtClaveUnica.Text = this.baseEntity.strClaveUnica;
                        this.txtCurp.Text = this.baseEntity.strCurp;

                        CalendarExtender1.SelectedDate = this.baseEntity.dteFechaNacimiento.Value.Date;

                        this.ddlSexo.DataSource = lista;
                        this.ddlSexo.DataBind();
                        this.setItem(ref this.ddlSexo, baseEntity.CatSexo.strValor);
                    }
                    this.ddlSexo.SelectedIndexChanged += new EventHandler(ddlSexo_SelectedIndexChanged);
                    this.ddlSexo.AutoPostBack = true;
                }

            }
            catch (Exception _e)
            {
                // Qué ha sucedido
                var mensaje = "Error message: " + _e.Message;

                // Información sobre la excepción interna
                if (_e.InnerException != null)
                {
                    mensaje = mensaje + " Inner exception: " + _e.InnerException.Message;
                }

                // Dónde ha sucedido
                mensaje = mensaje + " Stack trace: " + _e.StackTrace;

                envioDeCorreo("Excepcion cargar pagina", "Ah ocurrido un error inesperado al cargar la pagina del aplicativo UTTT.Ejemplo.Persona:" + mensaje);
                this.Response.Redirect("~/PersonaPrincipal.aspx", false);
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.txtClaveUnica.Text.Trim() == String.Empty && this.txtNombre.Text.Trim() == String.Empty &&
                this.txtAMaterno.Text.Trim() == String.Empty && this.txtAPaterno.Text.Trim() == String.Empty &&
                this.txtCurp.Text.Trim() == String.Empty && int.Parse(this.ddlSexo.Text).Equals(-1))
            {
                this.Response.Redirect("~/PersonaPrincipal.aspx", true);
            }
            else
            {
                btnAceptar.ValidationGroup = "vGFinal";
                Page.Validate("vGFinal");
            }
            if (!Page.IsValid)
            {
                return;
            }
            try
            {
                // se obtiene la fecha de nacimiento
                string date = Request.Form[this.txtFechaNacimiento.UniqueID];
                DateTime fechaNacimiento = Convert.ToDateTime(date);

                DataContext dcGuardar = new DcGeneralDataContext();
                UTTT.Ejemplo.Linq.Data.Entity.Persona persona = new Linq.Data.Entity.Persona();
                if (this.idPersona == 0)
                {
                    persona.strClaveUnica = this.txtClaveUnica.Text.Trim();
                    persona.strNombre = this.txtNombre.Text.Trim();
                    persona.strAMaterno = this.txtAMaterno.Text.Trim();
                    persona.strAPaterno = this.txtAPaterno.Text.Trim();
                    persona.strCurp = this.txtCurp.Text.Trim();
                    persona.idCatSexo = int.Parse(this.ddlSexo.Text);

                    // se asigna la fecha de nacimiento
                    persona.dteFechaNacimiento = fechaNacimiento;

                    String mensaje = String.Empty;
                    if (!this.validacion(persona, ref mensaje))
                    {
                        this.lblMensaje.Text = mensaje;
                        this.lblMensaje.Visible = true;
                        return;
                    }

                    dcGuardar.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Persona>().InsertOnSubmit(persona);
                    dcGuardar.SubmitChanges();
                    this.showMessage("El registro se agrego correctamente.");
                    this.Response.Redirect("~/PersonaPrincipal.aspx", false);
                    
                }
                if (this.idPersona > 0)
                {
                    persona = dcGuardar.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Persona>().First(c => c.id == idPersona);
                    persona.strClaveUnica = this.txtClaveUnica.Text.Trim();
                    persona.strNombre = this.txtNombre.Text.Trim();
                    persona.strAMaterno = this.txtAMaterno.Text.Trim();
                    persona.strAPaterno = this.txtAPaterno.Text.Trim();
                    persona.strCurp = this.txtCurp.Text.Trim();
                    persona.idCatSexo = int.Parse(this.ddlSexo.Text);

                    // se asigna fecha de nacimiento
                    persona.dteFechaNacimiento = fechaNacimiento;

                    String mensaje = String.Empty;
                    if (!this.validacion(persona, ref mensaje))
                    {
                        this.lblMensaje.Text = mensaje;
                        this.lblMensaje.Visible = true;
                        return;
                    }

                    dcGuardar.SubmitChanges();
                    this.showMessage("El registro se edito correctamente.");
                    this.Response.Redirect("~/PersonaPrincipal.aspx", false);
                }
            }
            catch (Exception _e)
            {
                // Qué ha sucedido
                var mensaje = "Error message: " + _e.Message;

                // Información sobre la excepción interna
                if (_e.InnerException != null)
                {
                    mensaje = mensaje + " Inner exception: " + _e.InnerException.Message;
                }

                // Dónde ha sucedido
                mensaje = mensaje + " Stack trace: " + _e.StackTrace;
                envioDeCorreo("Excepcion Guardar", "Ah ocurrido un error inesperado al guardar persona en el aplicativo UTTT.Ejemplo.Persona: " + mensaje);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Response.Redirect("~/PersonaPrincipal.aspx", false);
            }
            catch (Exception _e)
            {
                this.showMessage("Ha ocurrido un error inesperado");
            }
        }

        protected void ddlSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idSexo = int.Parse(this.ddlSexo.Text);
                Expression<Func<CatSexo, bool>> predicateSexo = c => c.id == idSexo;
                predicateSexo.Compile();
                List<CatSexo> lista = dcGlobal.GetTable<CatSexo>().Where(predicateSexo).ToList();
                CatSexo catTemp = new CatSexo();            
                this.ddlSexo.DataTextField = "strValor";
                this.ddlSexo.DataValueField = "id";
                this.ddlSexo.DataSource = lista;
                this.ddlSexo.DataBind();
            }
            catch (Exception _e)
            {
                // Qué ha sucedido
                var mensaje = "Error message: " + _e.Message;

                // Información sobre la excepción interna
                if (_e.InnerException != null)
                {
                    mensaje = mensaje + " Inner exception: " + _e.InnerException.Message;
                }

                // Dónde ha sucedido
                mensaje = mensaje + " Stack trace: " + _e.StackTrace;
                this.showMessage("Ha ocurrido un error inesperado");
                envioDeCorreo("Excepcion Guardar", "Ah ocurrido un error inesperado al guardar persona en el aplicativo UTTT.Ejemplo.Persona: " + mensaje);

            }
        }

        #endregion

        #region Metodos

        public void setItem(ref DropDownList _control, String _value)
        {
            foreach (ListItem item in _control.Items)
            {
                if (item.Value == _value)
                {
                    item.Selected = true;
                    break;
                }
            }
            _control.Items.FindByText(_value).Selected = true;
        }

        public bool validacion(Linq.Data.Entity.Persona _persona, ref string _mensaje)
        {
            if(_persona.idCatSexo == -1)
            {
                _mensaje = "Selecciona Masculino o Femenino";
                return false;
            }

            int i = 0;
            if(int.TryParse(_persona.strClaveUnica, out i) == false)
            {
                _mensaje = "La clave unica no es un numero";
                return false;
            }
            
            if(int.Parse(_persona.strClaveUnica) < 100 && int.Parse(_persona.strClaveUnica) > 999)
            {
                _mensaje = "La clave unica esta fuera de rango";
                return false;
            }

            if (_persona.strNombre.Equals(String.Empty))
            {
                _mensaje = "El nombre esta vacio";
                return false;
            }

            if(_persona.strNombre.Length > 50)
            {
                _mensaje = "El nombre sale del rango establecido de caracteres";
                return false;
            }

            if (_persona.strAPaterno.Equals(String.Empty))
            {
                _mensaje = "El apelido paterno esta vacio";
                return false;
            }

            if (_persona.strAPaterno.Length > 50)
            {
                _mensaje = "El apellido paterno sale del rango establecido de caracteres";
                return false;
            }

            if (_persona.strAMaterno.Equals(String.Empty))
            {
                _mensaje = "El apelido materno esta vacio";
                return false;
            }

            if (_persona.strAMaterno.Length > 50)
            {
                _mensaje = "El apellido materno sale del rango establecido de caracteres";
                return false;
            }

            if (_persona.strCurp.Equals(String.Empty))
            {
                _mensaje = "El CURP esta vacio";
                return false;
            }

            if (_persona.strCurp.Length > 18)
            {
                _mensaje = "El CURP sale del rango establecido de caracteres";
                return false;
            }

            if (_persona.strNombre.Length < 3)
            {
                _mensaje = "Proporciona un nombre valido";
                return false;
            }
            if (_persona.strAMaterno.Length < 3)
            {
                _mensaje = "Proporciona un apellido materno valido";
                return false;
            }
            if (_persona.strAPaterno.Length < 3)
            {
                _mensaje = "Proporciona un apellido paterno valido";
                return false;
            }

            return true;
        }

        public void envioDeCorreo(String subject, String body)
        { 
            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                mailMessage.From = new MailAddress("19300782@uttt.edu.mx");
                mailMessage.To.Add(new MailAddress("mauricio.pasten.martinez@gmail.com"));
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = body;
                smtpClient.Port = 587;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("19300782@uttt.edu.mx", "MPM1305M");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                this.showMessage(ex.Message);
            }
        }
        #endregion
    }
}