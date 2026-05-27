<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuList.aspx.cs" Inherits="Foodmanagement_assessment1.MenuList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Menu Items</h3>
            <a href='AddEditMenu.aspx?MenuId=<%# Eval("MenuId") %>'>Add</a> |
            <asp:GridView ID="gvMenu" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="MenuId" HeaderText="ID" />
                    <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
                    <asp:BoundField DataField="Category" HeaderText="Category" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <a href='AddEditMenu.aspx?MenuId=<%# Eval("MenuId") %>'>View</a> |
                            <a href='AddEditMenu.aspx?MenuId=<%# Eval("MenuId") %>'>Edit</a> |
                            <a href='MenuList.aspx?DeleteId=<%# Eval("MenuId") %>'>Delete</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
