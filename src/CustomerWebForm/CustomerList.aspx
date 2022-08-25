<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="CustomerWebForm.CustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table table-dark">
            <thead class="thead-dark">
                <tr>
                    <th scope="col">ID</th>
                    <th scope="col">First Name</th>
                    <th scope="col">Last Name</th>
                    <th scope="col">Phone Number</th>
                    <th scope="col">Email</th>
                    <th scope="col">Notes</th>
                    <th scope="col">total Purchases Amount</th>
                </tr>
            </thead>
                <%foreach (var item in customers)
                    {%>
                        <tr>
                            <td>
                                <%=item.customerID%>
                            </td>
                            <td>
                                <%=item.firstName%>
                            </td>
                            <td>
                                <%=item.lastName%>
                            </td>
                            <td>
                                <%=item.phoneNumber%>
                            </td>
                            <td>
                                <%=item.email%>
                            </td>
                            <td>
                                <%=item.notes%>
                            </td>
                            <td>
                                <%=item.totalPurchaseAmount%>
                            </td>
                        </tr>
                   <% } %>
        </table>
</asp:Content>
