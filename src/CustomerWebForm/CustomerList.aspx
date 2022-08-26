<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="CustomerWebForm.CustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <a href="CustomerEdit.aspx" style="margin-top: 10px; margin-bottom: 10px;" class="btn btn-success">Add</a>
    <table class="table table-bordered">
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
                            <td>
                                <a href="CustomerUpdate.aspx?customer_ID=<%=item.customerID%>" class="btn btn-primary">Edit</a>
                            </td>
                            <td>
                                <a href="CustomerDelete.aspx?customer_ID=<%=item.customerID%>" class="btn btn-danger">Delete</a>
                            </td>
                        </tr>
                   <% } %>
        </table>
</asp:Content>
