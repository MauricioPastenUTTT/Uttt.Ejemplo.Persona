<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonaManager.aspx.cs" Inherits="UTTT.Ejemplo.Persona.PersonaManager" Debug="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" type="text/css" rel="Stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1"
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <div class="container-fluid">
            <h1>Persona</h1>
        </div>
        <div class="container-fluid">
            <h4>
                <asp:Label ID="lblAccion" runat="server" Text="Accion" Font-Bold="True"></asp:Label>
            </h4>
        </div>
        <hr />
        <div class="containter">
            <div class="row m-2">
                <div class="col">
                    <label>
                        Sexo:
                    </label>
                </div>
                <div class="col-12">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlSexo" runat="server"
                                class="btn btn-info dropdown-toggle w-75">
                            </asp:DropDownList>
                            <asp:RangeValidator ID="rvdSexo" runat="server" ControlToValidate="ddlSexo" ErrorMessage="Se debe seleccionar el sexo" MaximumValue="2" MinimumValue="1" Type="Integer" ValidationGroup="vGFinal"></asp:RangeValidator>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlSexo" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="row m-2">
                <div class="col">
                    <label>Clave Unica:</label>
                </div>
                <div class="col-12">
                    <asp:TextBox ID="txtClaveUnica" runat="server"
                        Width="249px" ViewStateMode="Disabled"
                        onkeypress="return validacionNumeros(event);" pattern=".{1,3}"
                        title="1 a 3 es la longitud que se permite ingresar"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:RangeValidator ValidationGroup="vGFinal" ID="rvClaveUnica" runat="server" ControlToValidate="txtClaveUnica" ErrorMessage="*La clave unica debe estar entre 100 y 999" MaximumValue="999" MinimumValue="100" Type="Integer"></asp:RangeValidator>
                </div>
                <div class="col">
                    <asp:RequiredFieldValidator ValidationGroup="vGFinal" ID="rfvClaveUnica" runat="server" ControlToValidate="txtClaveUnica" ErrorMessage="El campo es obligatorio"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row m-2">
                <div class="col">
                    <label>Nombre:</label>
                </div>
                <div class="col-12">
                    <asp:TextBox ID="txtNombre" runat="server" Width="249px" ViewStateMode="Disabled" onkeypress="return  validaLetrasNombre(event);"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:RequiredFieldValidator ValidationGroup="vGFinal" ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="El campo es obligatorio"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row m-2">
                <div class="col">
                    <label>A Paterno:</label>
                </div>
                <div class="col-12">
                    <asp:TextBox ID="txtAPaterno" runat="server" Width="249px" ViewStateMode="Disabled" onkeypress="return  validaLetras(event);"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:RequiredFieldValidator ValidationGroup="vGFinal" ID="rfvAPaterno" runat="server" ControlToValidate="txtAPaterno" ErrorMessage="El campo es obligatorio"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row m-2">
                <div class="col">
                    <label>A Materno:</label>
                </div>
                <div class="col-12">
                    <asp:TextBox ID="txtAMaterno" runat="server" Width="248px"
                        ViewStateMode="Disabled" onkeypress="return  validaLetras(event);"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:RequiredFieldValidator ValidationGroup="vGFinal" ID="rfvAMaterno" runat="server" ControlToValidate="txtAMaterno" ErrorMessage="El campo es obligatorio"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row m-2">
                <div class="col">
                    <label>CURP:</label>
                </div>
                <div class="col-12">
                    <asp:TextBox ID="txtCurp" runat="server" Width="248px"
                        ViewStateMode="Disabled" onkeypress="return  validaCaracteresEspeciales(event);"
                        pattern=".{1,18}" title="El curp solo admite hasta 18 caracteres"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:RegularExpressionValidator ValidationGroup="vGFinal" ID="regexCurp" runat="server" ControlToValidate="txtCurp" ErrorMessage="El formato del CURP es incorrecto" ValidationExpression="^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$"></asp:RegularExpressionValidator>
                </div>
                <div class="col">
                    <asp:RequiredFieldValidator ValidationGroup="vGFinal" ID="rfvCurp" runat="server" ControlToValidate="txtCurp" ErrorMessage="El campo es obligatorio"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row m-2">
                <div class="col">
                    <label>Fecha de nacimiento:</label>
                </div>
                <div class="col-12">
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="w-75"></asp:TextBox>
                </div>
                <div class="col-12">
                    <asp:ImageButton ID="imgPopup" ImageUrl="Images/calendar.png"
                        runat="server" CausesValidation="False" Width="25px" />
                </div>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgPopup" Format="dd/MM/yyyy"
                    runat="server" TargetControlID="txtFechaNacimiento" />
            </div>
            <br />
            <div class="col m-3">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar"
                    OnClick="btnAceptar_Click" ViewStateMode="Disabled"
                    ValidationGroup="vGFinal" CausesValidation="False" class="btn btn-outline-success m-1" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"
                    OnClick="btnCancelar_Click" ViewStateMode="Disabled" CausesValidation="False" class="btn btn-outline-danger m-1" />
            </div>
        </div>
        <p>
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Visible="False"></asp:Label>
        </p>
    </form>
</body>
<script>
    function validacionNoob() {
        let nombre = document.getElementById('<%= txtNombre.ClientID %>').value
        let apellidoMaterno = document.getElementById('<%= txtAPaterno.ClientID %>').value;
        let apellidoPaterno = document.getElementById('<%= txtAMaterno.ClientID %>').value;
        let curp = document.getElementById('<%= txtCurp.ClientID %>').value;
        let ddlSexo = document.getElementById('<%= ddlSexo.ClientID %>').value;
        let claveUnica = document.getElementById('<%=txtClaveUnica.ClientID %>').value;

        if (nombre == "" && apellidoMaterno == "" && apellidoPaterno == "" && ddlSexo == -1 && curp == "" && claveUnica == "") {

            window.location.href = "/PersonaPrincipal.aspx";
        }
    }

    function validacionNumeros(evt) {
        let code = (evt.which) ? evt.which : evt.keyCode;
        if (code == 0) {
            return true;
        } else if (code >= 48 && code <= 57) {
            return true;
        } else {
            return false;
        }
    }

    function validaLetras(evt) {
        let key = evt.keyCode || evt.which;
        let tecla = String.fromCharCode(key).toLowerCase();
        let letras = 'áéíóúabcdefghijklmnñopqrstuvwxyz';
        let especiales = '8-37-39-46';
        let tecla_especial = false;
        for (let i in especiales) {
            if (key == especiales[i]) {
                tecla_especial = true;
                break;
            }
            if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                return false;
            }
        }
    }

    function validaLetrasNombre(evt) {
        let key = evt.keyCode || evt.which;
        let tecla = String.fromCharCode(key).toLowerCase();
        let letras = 'áéíóúabcdefghijklmnñopqrstuvwxyz ';
        let especiales = '8-37-39-46';
        let tecla_especial = false;
        for (let i in especiales) {
            if (key == especiales[i]) {
                tecla_especial = true;
                break;
            }
            if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                return false;
            }
        }
    }

    function validaCaracteresEspeciales(evt) {
        let key = evt.keyCode || evt.which;
        let tecla = String.fromCharCode(key).toUpperCase();
        let caracteres = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890';
        let especiales = '8-37-39-46';
        let tecla_especial = false;
        for (let i in especiales) {
            if (key == especiales[i]) {
                tecla_especial = true;
                break;
            }
            if (caracteres.indexOf(tecla) == -1 && !tecla_especial) {
                return false;
            }
        }
    }
</script>
<script src="Scripts/bootstrap.js"></script>
<script src="Scripts/bootstrap.bundle.js"></script>
</html>
