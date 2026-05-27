<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditMenu.aspx.cs" Inherits="Foodmanagement_assessment1.AddEditMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <h3>Add / Edit Menu Item</h3>
        Item Name:<br />
        <asp:TextBox ID="txtItemName" runat="server" />
        <asp:RequiredFieldValidator 
            ControlToValidate="txtItemName"
            ErrorMessage="Item Name is required"
            ForeColor="Red"
            runat="server" />
        <br /><br />
        Category:<br />
        <asp:TextBox ID="txtCategory" runat="server" />
        <asp:RegularExpressionValidator 
            ControlToValidate="txtCategory"
            ValidationExpression="^[a-zA-Z ]+$"
            ErrorMessage="Only letters allowed"
            ForeColor="Red"
            runat="server" />
        <br /><br />
        Price:<br />
        <asp:TextBox ID="txtPrice" runat="server" />
        <asp:RequiredFieldValidator 
            ControlToValidate="txtPrice"
            ErrorMessage="Price is required"
            ForeColor="Red"
            runat="server" />

        <asp:RangeValidator 
            ControlToValidate="txtPrice"
            MinimumValue="1"
            MaximumValue="1000"
            Type="Double"
            ErrorMessage="Price must be between 1 and 1000"
            ForeColor="Red"
            runat="server" />
        <br /><br />
        Quantity:<br />
        <asp:TextBox ID="txtQty" runat="server" />
        <asp:CompareValidator 
            ControlToValidate="txtQty"
            Operator="DataTypeCheck"
            Type="Integer"
            ErrorMessage="Enter valid number"
            ForeColor="Red"
            runat="server" />
        <br /><br />
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        <br /><br />
        <asp:ValidationSummary 
            ShowSummary="true"
            HeaderText="Please fix these errors:"
            ForeColor="Red"
            runat="server" />
        </div>
    </form>
</body>
</html>
