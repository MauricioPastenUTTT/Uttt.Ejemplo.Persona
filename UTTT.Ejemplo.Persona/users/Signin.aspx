<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="UTTT.Ejemplo.Persona.views.Signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
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
                <h3 class="card-title text-center">Signin
                </h3>
            </div>
            <div class="card-body">
                <form id="formSignin" runat="server">
                    <div class="d-flex justify-content-center align-items-center">
                        <img src="../Images/user.png" />
                    </div>
                    <div class="form-group">
                        <label>Username</label>
                        <asp:TextBox ID="username" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Password</label>
                        <asp:TextBox TextMode="Password" ID="password" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <hr />
                    <div class="form-group mt-2">
                        <asp:Button ID="btnSignin" Text="Signin" CssClass="btn btn-primary" OnClick="btnSignin_Click" runat="server" />
                        <asp:Button ID="btnSignup" Text="Signup" CssClass="btn btn-warning" OnClick="btnSignup_Click" runat="server" />
                        <asp:Button ID="btnForgetPassword" Text="Forget your password?" CssClass="btn btn-outline-info" OnClick="btnForgetPassword_Click" runat="server" />
                    </div>
                </form>
            </div>
        </div>
    </div>
    <script src="../Scripts/bootstrap.bundle.js"></script>
</body>
</html>
