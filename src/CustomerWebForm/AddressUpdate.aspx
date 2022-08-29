<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressUpdate.aspx.cs" Inherits="CustomerWebForm.AddressUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <asp:Label Text="Customer ID" runat="server" />  
        <asp:DropDownList runat="server" ID="drpDwnList" CssClass="form-control" />
    </div>
        <div class="form-group">
        <asp:Label Text="Address Line" runat="server" />
        <asp:TextBox ID="addressLineTextBox" runat="server" MaxLength="100" CssClass="form-control" />
        <asp:RequiredFieldValidator ErrorMessage="Field AddressLine is Required" ControlToValidate="addressLineTextBox" runat="server" />
        <asp:RegularExpressionValidator ErrorMessage="Should be less than 100" ValidationExpression="^.{1,100}$" ControlToValidate="addressLineTextBox" runat="server" />
    </div>
        <div class="form-group">
        <asp:Label Text="Address Line 2" runat="server" />
        <asp:TextBox ID="addressLine2TextBox" runat="server" CssClass="form-control" />
        <asp:RegularExpressionValidator ErrorMessage="Should be less than 100" ValidationExpression="^.{1,100}$" ControlToValidate="addressLine2TextBox" runat="server" />
    </div>
    <div class="form-group">
        <asp:Label Text="Address Type" runat="server" />
        <asp:TextBox ID="addressTypeTextBox" runat="server" CssClass="form-control" />  
    </div>
    <div class="form-group">
        <asp:Label Text="City" runat="server" />
        <asp:TextBox ID="cityTextBox" runat="server" CssClass="form-control" />
        <asp:RegularExpressionValidator ErrorMessage="Should be less than 50" ValidationExpression="^.{1,50}$" ControlToValidate="cityTextBox" runat="server" />
    </div>
    <div class="form-group">
        <asp:Label Text="State" runat="server" />
        <asp:TextBox ID="stateTextBox" runat="server" CssClass="form-control" />
        <asp:RegularExpressionValidator ErrorMessage="Should be less than 20" ValidationExpression="^.{1,20}$" ControlToValidate="stateTextBox" runat="server" />
    </div>
    <div class="form-group">
        <asp:Label Text="Country" runat="server" />
        <asp:DropDownList ID="countyDrpDwn" CssClass="form-control" runat="server">
            <asp:ListItem Text="Canada" />
            <asp:ListItem Text="United States" />
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <asp:Label Text="Postal Code" runat="server" />
        <asp:TextBox ID="postalCodeTextBox" runat="server" CssClass="form-control" />  
        <asp:RegularExpressionValidator ErrorMessage="Should be less than 6" ValidationExpression="^.{1,6}$" ControlToValidate="postalCodeTextBox" runat="server" />
    </div>
    <asp:Button Text="Update" ID="UpdateBtn" CssClass="btn btn-primary" runat="server" OnClick="UpdateBtn_Click" />
</asp:Content>
