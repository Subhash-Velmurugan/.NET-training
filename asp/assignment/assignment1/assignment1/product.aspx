<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="assignment1.product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
    <asp:GridView ID="gvCategory" runat="server" AutoGenerateColumns="true"
        AutoGenerateSelectButton="true"
        OnSelectedIndexChanged="gvCategory_SelectedIndexChanged">
    </asp:GridView>
    <br />
    <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="true"
        OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
    </asp:DropDownList>
    <br /><br />
    <asp:Image ID="imgProduct" runat="server" Width="200px" /><br /><br />
    <asp:Label ID="lblPrice" runat="server" ForeColor="Green"></asp:Label>

</form>
</body>
</html>
