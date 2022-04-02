﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPatient.aspx.cs" Inherits="UTTT.Ejemplo.Persona.patients.AddPatient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Patient</title>
    <link href="../css/bootstrap.css" type="text/css" rel="Stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
    <div class="container mx-auto mt-4 col-lg-4 col-md-12 col-sm-12">
        <% if (message)
            { %>
        <div class="alert alert-dismissible alert-danger">
            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
            <strong>Error:</strong> <%=messageText %>
        </div>
        <% } %>
        <div class="card">
            <div class="card-header">
                <h3 class="card-title text-center">Add Patient
                </h3>
            </div>
            <div class="card-body">
                <form id="formSignup" runat="server">
                    <div class="form-group">
                        <label>Name:</label>
                        <asp:TextBox ID="name" runat="server" CssClass="form-control" onkeypress="return isAlphabetKey(event, 'Name')"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Lastname</label>
                        <asp:TextBox ID="lastname" runat="server" CssClass="form-control" onkeypress="return isAlphabetKey(event, 'Lastname')"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Phone number</label>
                        <asp:TextBox ID="phoneNumber" TextMode="Number" runat="server" CssClass="form-control" onkeydown="return (!(event.keyCode>=65 && event.keyCode<=90 ) && event.keyCode!=32);"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Tratamient</label>
                        <asp:TextBox ID="tratamient"  runat="server" CssClass="form-control" onkeypress="return isAlphabetKey(event, 'Tratamient')"></asp:TextBox>
                    </div>
                    <hr />
                    <div class="form-group mt-2">
                        <asp:Button ID="btnCancelar" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancelar_Click" runat="server" />
                        <asp:Button ID="btnAdd" Text="Add" CssClass="btn btn-primary" OnClick="btnAdd_Click" runat="server" />
                    </div>
                </form>
            </div>
        </div>
    </div>
    <script src="../Scripts/bootstrap.bundle.js"></script>
    <script src="../Scripts/Validations.js"></script>
</body>
</html>