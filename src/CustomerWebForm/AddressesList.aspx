<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressesList.aspx.cs" Inherits="CustomerWebForm.AddressesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <a href="AddressEdit.aspx" style="margin-top: 10px; margin-bottom: 10px;" class="btn btn-success">Add</a>
    <table class="table">
            <thead class="thead-dark">
                <tr>
                    <th class="text-center" scope="col">ID</th>
                    <th class="text-center" scope="col">Customer ID</th>
                    <th class="text-center" scope="col">Address Line</th>
                    <th class="text-center" scope="col">Address Line 2</th>
                    <th class="text-center" scope="col">Address Type</th>
                    <th class="text-center" scope="col">City</th>
                    <th class="text-center" scope="col">State</th>
                    <th class="text-center" scope="col">Country</th>
                    <th class="text-center" scope="col">Postal Code</th>
                    <th class="text-center" scope="col"><i class="glyphicon glyphicon-pencil" aria-hidden="true"></i></th>
                    <th class="text-center" scope="col"><i class="glyphicon glyphicon-minus" aria-hidden="true"></i></th>
                </tr>
            </thead>
                <%foreach (var item in addresses)
                    {%>
                        <tr>
                            <td class="text-center">
                                <%=item.AddressID%>
                            </td>
                            <td class="text-center">
                                <%=item.CustomerID%>
                            </td>
                            <td class="text-center">
                                <%=item.AddressLine%>
                            </td>
                            <td class="text-center">
                                <%=item.AddressLine2%>
                            </td>
                            <td class="text-center">
                                <%=item.AddressType%>
                            </td>
                            <td class="text-center">
                                <%=item.City%>
                            </td>
                            <td class="text-center">
                                <%=item.State%>
                            </td>
                            <td class="text-center">
                                <%=item.Country%>
                            </td>
                            <td class="text-center">
                                <%=item.PostalCode%>
                            </td>
                            <td class="text-center">
                                <a href="AddressUpdate.aspx?address_ID=<%=item.AddressID%>" class="btn btn-default">Edit</a>
                            </td>
                            <td class="text-center">
                                <a href="AddressDelete.aspx?address_ID=<%=item.AddressID%>" class="btn btn-danger">Delete</a>
                            </td>
                        </tr>
                   <% } %>
        </table>
</asp:Content>
