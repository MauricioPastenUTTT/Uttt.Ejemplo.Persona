<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UTTT.Ejemplo.Persona.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="css/bootstrap.css" type="text/css" rel="Stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container-fluid">
            <a class="navbar-brand" href="Home.aspx">
                <img src="../Images/bootstrap.png" class="w-25"></img>
            </a>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                    <li class="nav-item">
                        <a class="nav-link active" aria-current="page" href="../Home.aspx">Home</a>
                    </li>
                </ul>
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item dropdown">
                        <li class="nav-item">
                            <a class="nav-link active" aria-current="page" href="../Home.aspx">Home</a>
                            <form id="formLogout" runat="server">
                                <asp:Button ID="btnLogout" Text="Logout" CssClass="nav-link" OnClick="btnLogout_Click" runat="server" />
                            </form>

                        </li>
                        <% if (!role)
                            { %>
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">Account
                        </a>
                        <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <li><a class="dropdown-item" href="users/Signin.aspx">Signin</a></li>
                            <li><a class="dropdown-item" href="users/Signup.aspx">Signup</a></li>
                        </ul>
                        <% }%>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <div class="containter mt-4 text-center">
        <div class="jumbotron">
            <h1 class="display-4">Welcome to my ASP.NET app!</h1>
            <p class="lead">My name's Mauricio Pasten Martinez, Im a software developer and TI student</p>
            <hr class="my-4">
            <p>Start to use my app using the following button!</p>
            <p class="lead">
                <a class="btn btn-primary btn-lg" href="users/Signin.aspx" role="button">Click me!</a>
            </p>
        </div>
    </div>
    <script src="Scripts/bootstrap.bundle.js"></script>
</body>
</html>
