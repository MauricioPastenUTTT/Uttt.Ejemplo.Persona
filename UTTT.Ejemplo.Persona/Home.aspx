<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UTTT.Ejemplo.Persona.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="css/bootstrap.css" type="text/css" rel="Stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
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
