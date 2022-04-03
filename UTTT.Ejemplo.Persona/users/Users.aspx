<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="UTTT.Ejemplo.Persona.users.Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Users</title>
    <link href="../css/bootstrap.css" type="text/css" rel="Stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-4">
        <div class="form-group">
            <label>Username</label>
            <asp:TextBox ID="username" runat="server" CssClass="form-control" onkeypress="return isAlphabetKey(event, 'lastname')"></asp:TextBox>
            <label>Role</label>
            <asp:DropDownList ID="ddlRole" runat="server" class="btn btn-info dropdown-toggle">
            </asp:DropDownList>
            <asp:Button ID="btnSearchUser" Text="Seach Patient" CssClass="btn btn-success" OnClick="btnSearchUser_Click" runat="server" />
        </div>
        <div class="table-responsive mt-4">
            <asp:GridView ID="GridViewUsers" DataKeyNames="id" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDcUsers" OnRowCommand="GridViewUsers_RowCommand"
                AllowPaging="True" Width="1067px" CellPadding="3" GridLines="Horizontal" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" ViewStateMode="Disabled" BackColor="White">
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" InsertVisible="False" />
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="lastname" HeaderText="lastname" SortExpression="lastname" />
                    <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
                    <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                    <asp:BoundField DataField="role" HeaderText="role" SortExpression="role" />
                    <asp:CheckBoxField DataField="active" HeaderText="active" SortExpression="active" />
                    <asp:TemplateField HeaderText="Update">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="imgUpdate" CommandName="Update" CommandArgument='<%#Bind("id") %>' ImageUrl="~/Images/editrecord_16x16.png" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="50px" />

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Eliminar" Visible="True">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="imgEliminar" CommandName="Eliminar" CommandArgument='<%#Bind("id") %>' ImageUrl="~/Images/delrecord_16x16.png" OnClientClick="javascript:return confirm('¿Está seguro de querer eliminar el registro seleccionado?', 'Mensaje de sistema')" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
            </asp:GridView>
            <asp:LinqDataSource ID="LinqDcUsers" runat="server" ContextTypeName="UTTT.Ejemplo.Linq.Data.Entity.DcGeneralDataContext" EntityTypeName="" TableName="Users" EnableUpdate="True" OnSelecting="LinqDcUsers_Selecting" Where="username != @username">
                <WhereParameters>
                    <asp:SessionParameter Name="username" SessionField="username" Type="String" />
                </WhereParameters>
            </asp:LinqDataSource>
        </div>
        <div class="mt-2">
            <asp:Button ID="btnBack" Text="Back" CssClass="btn btn-primary" OnClick="btnBack_Click" runat="server" />
            <asp:Button ID="btnAddUser" Text="Add" CssClass="btn btn-secondary" OnClick="btnAddUser_Click" runat="server" />
        </div>
    </form>
    <script src="../Scripts/bootstrap.bundle.js"></script>
</body>
</html>
