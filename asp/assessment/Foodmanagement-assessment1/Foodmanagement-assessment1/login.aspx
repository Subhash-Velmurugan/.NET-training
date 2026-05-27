<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Foodmanagement_assessment1.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Username:<br />
            <asp:TextBox ID="txtUsername" runat="server" />
            <br /><br />
            Password:<br />
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" />
            <br /><br />
            <asp:Button ID="btnLogin" Text="login" runat="server" OnClick="btnLogin_Click" />
            <br /><br />
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>
