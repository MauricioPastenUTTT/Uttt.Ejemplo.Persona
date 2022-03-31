<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="UTTT.Ejemplo.Persona.users.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Signup</title>
    <link href="../css/bootstrap.css" type="text/css" rel="Stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container-fluid">
            <a class="navbar-brand" href="../Home.aspx">
                <img src="../Images/bootstrap.png" class="w-25"></img>
            </a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                    <li class="nav-item">
                        <a class="nav-link active" aria-current="page" href="../Home.aspx">Home</a>
                    </li>
                </ul>
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">Account
                        </a>
                        <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <li><a class="dropdown-item" href="Signin.aspx">Signin</a></li>
                            <li><a class="dropdown-item" href="Signup.aspx">Signup</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
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
                        <asp:TextBox ID="username" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Name</label>
                        <asp:TextBox ID="name" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Lastname</label>
                        <asp:TextBox ID="lastname" runat="server" CssClass="form-control"></asp:TextBox>
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
</body>
</html>
