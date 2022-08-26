<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressEdit.aspx.cs" Inherits="CustomerWebForm.AddressEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <asp:Label Text="Customer ID" runat="server" />  
        <asp:DropDownList runat="server" ID="drpDwnList" CssClass="form-control" />
    </div>
        <div class="form-group">
        <asp:Label Text="Address Line" runat="server" />
        <asp:TextBox ID="addressLineTextBox" runat="server" CssClass="form-control" />  
    </div>
        <div class="form-group">
        <asp:Label Text="Address Line 2" runat="server" />
        <asp:TextBox ID="addressLine2TextBox" runat="server" CssClass="form-control" />  
    </div>
    <div class="form-group">
        <asp:Label Text="Address Type" runat="server" />
        <asp:TextBox ID="addressTypeTextBox" runat="server" CssClass="form-control" />  
    </div>
    <div class="form-group">
        <asp:Label Text="City" runat="server" />
        <asp:TextBox ID="cityTextBox" runat="server" CssClass="form-control" />  
    </div>
    <div class="form-group">
        <asp:Label Text="State" runat="server" />
        <asp:TextBox ID="stateTextBox" runat="server" CssClass="form-control" />  
    </div>
    <div class="form-group">
        <asp:Label Text="Country" runat="server" />
        <asp:TextBox ID="countryTextBox" runat="server" CssClass="form-control" />  
    </div>
    <div class="form-group">
        <asp:Label Text="Postal Code" runat="server" />
        <asp:TextBox ID="postalCodeTextBox" runat="server" CssClass="form-control" />  
    </div>
    <asp:Button Text="Edit" CssClass="btn btn-primary" ID="Edit" OnClick="Edit_Click" runat="server" />
</asp:Content>
