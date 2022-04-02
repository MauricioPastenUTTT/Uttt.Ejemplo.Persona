<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="UTTT.Ejemplo.Persona.products.UpdateProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Product</title>
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
                <h3 class="card-title text-center">Add Product
                </h3>
            </div>
            <div class="card-body">
                <form id="formSignup" runat="server">
                    <div class="form-group">
                        <label>Product name:</label>
                        <asp:TextBox ID="name" runat="server" CssClass="form-control" onkeypress="return isAlphabetKey(event, 'Product name')"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Description</label>
                        <asp:TextBox ID="description" runat="server" CssClass="form-control" onkeypress="return isAlphabetKey(event, 'Description')"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Price</label>
                        <asp:TextBox ID="price" runat="server" CssClass="form-control" onkeydown="return (!(event.keyCode>=65 && event.keyCode<=90 ) && event.keyCode!=32);"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Stock</label>
                        <asp:TextBox ID="inStock" TextMode="Number" runat="server" CssClass="form-control" onkeydown="return (!(event.keyCode>=65 && event.keyCode<=90 ) && event.keyCode!=32);"></asp:TextBox>
                    </div>
                    <hr />
                    <div class="form-group mt-2">
                        <asp:Button ID="btnCancelar" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancelar_Click" runat="server" />
                        <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-warning" OnClick="btnUpdate_Click" runat="server" />
                    </div>
                </form>
            </div>
        </div>
    </div>
    <script src="../Scripts/bootstrap.bundle.js"></script>
    <script src="../Scripts/Validations.js"></script>
</body>
</html>
