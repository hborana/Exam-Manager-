<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FacultyAllocation_List.aspx.vb" Inherits="FacultyAllocation_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="agile-tables">
            <div class="w3l-table-info">
                <h3>Faculty Allocation List</h3>
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
                    <asp:GridView ID="dgvFacultyAllocation" runat="server" AutoGenerateColumns="false" BorderWidth="0">
                        <Columns>
                            <asp:TemplateField HeaderText="Class ">
                                <ItemTemplate>
                                    <asp:Label ID="lblClass" runat="server" Text='<%# Bind("Class")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Faculty Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblFaculty" runat="server" Text='<%# Bind("Faculty")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblEdit" runat="server"
                                        PostBackUrl='<%# String.Format("~/BranchEntry.aspx?id={0}", Eval("Id"))%>'>
                                         <i class="icon-edit"></i> Edit
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblDelete" runat="server"
                                        PostBackUrl='<%# String.Format("~/Branch_List.aspx?id={0}", Eval("Id"))%>'>
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

