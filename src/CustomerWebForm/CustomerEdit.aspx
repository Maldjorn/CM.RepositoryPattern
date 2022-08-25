<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerEdit.aspx.cs" Inherits="CustomerWebForm.CustomerEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
    <div class="form-group">
        <asp:Label Text="First Name" runat="server" />
        <asp:TextBox ID="firstNameTextBox" CssClass="form-control" runat="server" />
    </div>
    <div class="form-group">
        <asp:Label Text="Last Name" runat="server" />
        <asp:TextBox ID="lastNameTextBox" CssClass="form-control" runat="server" />
    </div>
    <div class="form-group">
        <asp:Label Text="Phone Number" runat="server" />
        <asp:TextBox ID="phoneNumberTextBox" CssClass="form-control" runat="server" />
    </div>
    <div class="form-group">
        <asp:Label Text="Email" runat="server" />
        <asp:TextBox ID="emailTextBox" CssClass="form-control" runat="server" />
    </div>
    <div class="form-group">
        <asp:Label Text="Notes" runat="server" />
        <asp:TextBox ID="notesTextBox" CssClass="form-control" runat="server" />
    </div>
    <div class="form-group">
        <asp:Label Text="Total Purchases Amount" runat="server" />
        <asp:TextBox ID="amountTextBox" CssClass="form-control" runat="server" />
    </div>
        <asp:Button Text="Edit" ID="EditButton" CssClass="btn btn-primary" OnClick="EditButton_Click" runat="server" />
   </div>
</asp:Content>
