<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="CustomerWebForm.CustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <a href="CustomerEdit.aspx" style="margin-top: 10px; margin-bottom: 10px;" class="btn btn-success">Add</a>
    <table class="table">
            <thead class="thead-dark">
                <tr>
                    <th class="text-center" scope="col">ID</th>
                    <th class="text-center" scope="col">First Name</th>
                    <th class="text-center" scope="col">Last Name</th>
                    <th class="text-center" scope="col">Phone Number</th>
                    <th class="text-center" scope="col">Email</th>
                    <th class="text-center" scope="col">Notes</th>
                    <th class="text-center" scope="col">total Purchases Amount</th>
                    <th class="text-center" scope="col"><i class="glyphicon glyphicon-pencil" aria-hidden="true"></i></th>
                    <th class="text-center" scope="col"><i class="glyphicon glyphicon-minus" aria-hidden="true"></i></th>
                </tr>
            </thead>
                <%foreach (var item in customers)
                    {%>
                        <tr class="text-center">
                            <td >
                                <%=item.customerID%>
                            </td>
                            <td >
                                <%=item.firstName%>
                            </td>
                            <td >
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
                            <td>
                                <a href="CustomerUpdate.aspx?customer_ID=<%=item.customerID%>" class="btn btn-default">Edit</a>
                            </td>
                            <td>
                                <a href="CustomerDelete.aspx?customer_ID=<%=item.customerID%>" class="btn btn-danger">Delete</a>
                            </td>
                        </tr>
                   <% } %>
        </table>
</asp:Content>
