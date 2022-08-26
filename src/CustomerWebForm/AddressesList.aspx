<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressesList.aspx.cs" Inherits="CustomerWebForm.AddressesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <a href="AddressEdit.aspx" style="margin-top: 10px; margin-bottom: 10px;" class="btn btn-success">Add</a>
    <table class="table table-bordered">
            <thead class="thead-dark">
                <tr>
                    <th scope="col">ID</th>
                    <th scope="col">Customer ID</th>
                    <th scope="col">Address Line</th>
                    <th scope="col">Address Line 2</th>
                    <th scope="col">Address Type</th>
                    <th scope="col">City</th>
                    <th scope="col">State</th>
                    <th scope="col">Country</th>
                    <th scope="col">Postal Code</th>
                </tr>
            </thead>
                <%foreach (var item in addresses)
                    {%>
                        <tr>
                            <td>
                                <%=item.AddressID%>
                            </td>
                            <td>
                                <%=item.CustomerID%>
                            </td>
                            <td>
                                <%=item.AddressLine%>
                            </td>
                            <td>
                                <%=item.AddressLine2%>
                            </td>
                            <td>
                                <%=item.AddressType%>
                            </td>
                            <td>
                                <%=item.City%>
                            </td>
                            <td>
                                <%=item.State%>
                            </td>
                            <td>
                                <%=item.Country%>
                            </td>
                            <td>
                                <%=item.PostalCode%>
                            </td>
                            <td>
                                <a href="AddressUpdate.aspx?address_ID=<%=item.AddressID%>" class="btn btn-primary">Edit</a>
                            </td>
                            <td>
                                <a href="AddressDelete.aspx?address_ID=<%=item.AddressID%>" class="btn btn-danger">Delete</a>
                            </td>
                        </tr>
                   <% } %>
        </table>
</asp:Content>
