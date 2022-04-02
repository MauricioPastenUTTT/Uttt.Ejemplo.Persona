﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="UTTT.Ejemplo.Persona.users.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Signup</title>
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
                <h3 class="card-title text-center">Signup
                </h3>
            </div>
            <div class="card-body">
                <form id="formSignup" runat="server">
                    <div class="form-group">
                        <label>Username</label>
                        <asp:TextBox ID="username" runat="server" CssClass="form-control" onkeypress="return isAlphabetKey(event, 'username')" ></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Name</label>
                        <asp:TextBox ID="name" runat="server" CssClass="form-control" onkeypress="return isAlphabetKey(event, 'name')" ></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Lastname</label>
                        <asp:TextBox ID="lastname" runat="server" CssClass="form-control" onkeypress="return isAlphabetKey(event, 'lastname')" ></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Password</label>
                        <asp:TextBox TextMode="Password" ID="password" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Confirm Password</label>
                        <asp:TextBox TextMode="Password" ID="passwordConfirm" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <hr />
                    <div class="form-group mt-2">
                        <asp:Button ID="btnCancelar" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancelar_Click" runat="server" />
                        <asp:Button ID="btnSignup" Text="Signup" CssClass="btn btn-info" OnClick="BtnSignup_Click" runat="server" />
                    </div>
                </form>
            </div>
        </div>
    </div>
    <script src="../Scripts/bootstrap.bundle.js"></script>
    <script src="../Scripts/Validations.js"></script>
</body>
</html>