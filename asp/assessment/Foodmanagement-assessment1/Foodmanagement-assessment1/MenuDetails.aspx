<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuDetails.aspx.cs" Inherits="Foodmanagement_assessment1.MenuDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Menu Details</h3>

                Item Name: <asp:Label ID="lblName" runat="server" /><br /><br />
                Category: <asp:Label ID="lblCategory" runat="server" /><br /><br />
                Price: <asp:Label ID="lblPrice" runat="server" /><br /><br />
                Quantity: <asp:Label ID="lblQty" runat="server" /><br /><br />
        </div>
    </form>
</body>
</html>
