<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="WebApp.Validator" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Validator Form</title>
</head>
<body>
<form runat="server">

    Name:
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvName" runat="server"
        ControlToValidate="txtName"
        ErrorMessage="Name required" ForeColor="Red" /><br />
    Family Name:
    <asp:TextBox ID="txtFamily" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvFamily" runat="server"
        ControlToValidate="txtFamily"
        ErrorMessage="Family Name required" ForeColor="Red" /><br />
    <asp:CompareValidator ID="cvName" runat="server"
        ControlToValidate="txtName"
        ControlToCompare="txtFamily"
        Operator="NotEqual"
        ErrorMessage="Name must be different from Family Name"
        ForeColor="Red" /><br />

    Address:
    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="revAddress" runat="server"
        ControlToValidate="txtAddress"
        ValidationExpression="^.{2,}$"
        ErrorMessage="Address must have at least 2 characters"
        ForeColor="Red" /><br />

    City:
    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="revCity" runat="server"
        ControlToValidate="txtCity"
        ValidationExpression="^.{2,}$"
        ErrorMessage="City must have at least 2 characters"
        ForeColor="Red" /><br />

    Zip Code:
    <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="revZip" runat="server"
        ControlToValidate="txtZip"
        ValidationExpression="^\d{5}$"
        ErrorMessage="Zip must be 5 digits"
        ForeColor="Red" /><br />

    Phone:
    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="revPhone" runat="server"
        ControlToValidate="txtPhone"
        ValidationExpression="^[0-9]{2}-[0-9]{7}$"
        ErrorMessage="Format: XX-XXXXXXX or XXX-XXXXXXX"
        ForeColor="Red" /><br />

    Email:
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="revEmail" runat="server"
        ControlToValidate="txtEmail"
        ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
        ErrorMessage="Invalid Email"
        ForeColor="Red" /><br /><br />

    <asp:Button ID="btnCheck" runat="server" Text="Check" /><br /><br />
</form>
</body>
</html>