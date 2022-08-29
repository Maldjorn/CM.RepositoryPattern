<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerEdit.aspx.cs" Inherits="CustomerWebForm.CustomerEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <style>
        .form-group{
            margin-bottom: 2px;
        }
        </style>
    <div class="container">
    <div class="form-group">
        <asp:Label Text="First Name" runat="server" />
        <asp:TextBox ID="firstNameTextBox" CssClass="form-control" runat="server" />
        <asp:RequiredFieldValidator  ErrorMessage="First name field is required" ControlToValidate="firstNameTextBox" runat="server" Display="Dynamic" ForeColor="Red" >*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator  ErrorMessage="Should be less than 50" ValidationExpression="^.{1,50}$"  ControlToValidate="firstNameTextBox" runat="server" Display="Dynamic" ForeColor="Red" >*</asp:RegularExpressionValidator>
    </div>
    <div class="form-group">
        <asp:Label Text="Last Name" runat="server" />
        <asp:TextBox ID="lastNameTextBox" CssClass="form-control" runat="server" />
        <asp:RegularExpressionValidator ErrorMessage="Should be less than 50" ValidationExpression="^.{0,50}$" ControlToValidate="lastNameTextBox" runat="server" Display="Dynamic" ForeColor="Red" >*</asp:RegularExpressionValidator>
    </div>
    <div class="form-group">
        <asp:Label Text="Phone Number" runat="server" />
        <asp:TextBox ID="phoneNumberTextBox" CssClass="form-control" runat="server" />
        <asp:RegularExpressionValidator ErrorMessage="Invalid phone number" ValidationExpression="^\+?\d{6,7}[2-9]\d{3}$" ControlToValidate="phoneNumberTextBox" runat="server" Display="Dynamic" ForeColor="Red" >*</asp:RegularExpressionValidator>
    </div>
    <div class="form-group">
        <asp:Label Text="Email" runat="server" />
        <asp:TextBox ID="emailTextBox" CssClass="form-control" runat="server" />
        <asp:RegularExpressionValidator ErrorMessage="Invalid email" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ControlToValidate="emailTextBox" runat="server" Display="Dynamic" ForeColor="Red" >*</asp:RegularExpressionValidator>
    </div>
    <div class="form-group">
        <asp:Label Text="Notes" runat="server" />
        <asp:TextBox ID="notesTextBox" CssClass="form-control" runat="server" />
        <asp:RequiredFieldValidator ErrorMessage="Notes field is required" ControlToValidate="notesTextBox" runat="server" Display="Dynamic" ForeColor="Red" >*</asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <asp:Label Text="Total Purchases Amount" runat="server" />
        <asp:TextBox ID="amountTextBox" CssClass="form-control" runat="server" />
        <asp:RequiredFieldValidator ErrorMessage="Total purchases amount is required" ControlToValidate="amountTextBox" runat="server" Display="Dynamic" ForeColor="Red" >*</asp:RequiredFieldValidator>
    </div>
        <asp:Button Text="Edit" ID="EditButton" CssClass="btn btn-primary" OnClick="EditButton_Click" runat="server" />
        <asp:ValidationSummary runat="server" />
   </div>
</asp:Content>
