<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderStats.aspx.cs" Inherits="Foodmanagement_assessment1.OrderStats" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Application Statistics</h3>

Total Visitors:
<asp:Label ID="lblVisitors" runat="server" /><br /><br />

Active Users:
<asp:Label ID="lblActive" runat="server" /><br /><br />

        </div>
    </form>
</body>
</html>
