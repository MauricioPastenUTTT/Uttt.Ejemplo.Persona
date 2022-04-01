<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="UTTT.Ejemplo.Persona.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu</title>
    <link href="../css/bootstrap.css" type="text/css" rel="Stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
    <div class="container mt-4">
        <div class="row">

            <div class="col-lg-6">
                <img src="Images/product.png" />
                <h2>Products</h2>
                <p>Product warehouse</p>
                <p><a class="btn btn-secondary" href="products/Products.aspx">Go »</a></p>
            </div>
            <div class="col-lg-6">
                <img src="Images/patient.png" />
                <h2>Patients</h2>
                <p>Patients management</p>
                <p><a class="btn btn-secondary" href="patients/Patients.aspx">Go »</a></p>
            </div>
        </div>
        <hr/>
        <%if (roleIsAdmin)
            { %>
        <div class="row">
            <div class="col-lg-6">
                <img src="Images/role.png" />
                <h2>Rol Catalog</h2>
                <p>User type management</p>
                <p><a class="btn btn-secondary" href="roles/Roles.aspx">Go »</a></p>
            </div>
            <div class="col-lg-6">
                <img src="Images/users.png" />
                <h2>Users</h2>
                <p>User management</p>
                <p><a class="btn btn-secondary" href="users/Users.aspx">Go »</a></p>
            </div>
        </div>
        <hr/>
        <%} %>
        <form id="formCloseSession" runat="server">
            <div>
                <asp:Button ID="btnLogout" CssClass="btn btn-danger" Text="Logout" OnClick="btnLogout_Click" runat="server"/>
            </div>
        </form>
    </div>
    <script src="../Scripts/bootstrap.bundle.js"></script>
</body>
</html>
