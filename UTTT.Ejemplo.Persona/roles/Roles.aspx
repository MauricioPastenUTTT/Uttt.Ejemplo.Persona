<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="UTTT.Ejemplo.Persona.roles.roles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridViewRoles" DataKeyNames="id" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDcUsers" OnRowCommand="GridViewRoles_RowCommand">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"  />
                    <asp:BoundField DataField="name" HeaderText="name" ReadOnly="True" SortExpression="name" />
                    <asp:BoundField DataField="description" HeaderText="description" ReadOnly="True" SortExpression="description" />
                     <asp:TemplateField HeaderText="Update">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="imgUpdate" CommandName="Update" CommandArgument='<%#Bind("id") %>' ImageUrl="~/Images/editrecord_16x16.png" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="50px" />

                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:LinqDataSource ID="LinqDcUsers" runat="server" ContextTypeName="UTTT.Ejemplo.Linq.Data.Entity.DcGeneralDataContext" EntityTypeName="" TableName="Roles" EnableUpdate="true">
            </asp:LinqDataSource>
        </div>
    </form>
</body>
</html>
