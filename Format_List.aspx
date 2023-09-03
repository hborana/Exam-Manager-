<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Format_List.aspx.vb" Inherits="Format_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Paper Format<i class="fa fa-angle-right"></i>List</li>
    </ol>
<div id="content">
        <div class="agile-tables">
            <div class="w3l-table-info">
                <h3>Paper Format List</h3>
                <form id="Form1" runat="server">

                    <%--<table id="table-no-resize">
                                        <thead>
                                            <tr>
                                                <th>Name</th>
                                                <th>Age</th>
                                                <th>Gender</th>
                                                <th>Height</th>
                                                <th>Province</th>
                                                <th>Sport</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>Jill Smith</td>
                                                <td>25</td>
                                                <td>Female</td>
                                                <td>5'4</td>
                                                <td>British Columbia</td>
                                                <td>Volleyball</td>
                                            </tr>
                                        </tbody>
                                  </table>--%>
 <asp:GridView ID="dgvFormat" runat="server" BorderWidth="0" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="Format Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name")  %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Marks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMarks" runat="server" Text='<%# Bind("Total_Marks")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remark">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark")  %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lblEdit" runat="server"
                                                PostBackUrl='<%# String.Format("~/FormatEntry.aspx?id={0}", Eval("Id"))%>'>
                                         <i class="icon-edit"></i> Edit
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lblDelete" runat="server"
                                                PostBackUrl='<%# String.Format("~/Format_List.aspx?id={0}", Eval("Id"))%>'>
                                                <i class="icon-remove"></i> Delete
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>

</form>
                </div>
    </div>
   </div>
         </asp:Content>

