<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Student_List.aspx.vb" Inherits="Student_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Student<i class="fa fa-angle-right"></i>List</li>
    </ol>
    <div id="content">
        <div class="agile-tables">
            <div class="w3l-table-info">
                <h3>Student List</h3>
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
                    <asp:GridView ID="dgvStudent" runat="server" BorderWidth="0" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Student Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Enrolment">
                                <ItemTemplate>
                                    <asp:Label ID="lblEnrl" runat="server" Text='<%# Bind("Enrolment")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Branch">
                                <ItemTemplate>
                                    <asp:Label ID="lblBranch" runat="server" Text='<%# Bind("Branch")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Course">
                                <ItemTemplate>
                                    <asp:Label ID="lblCourse" runat="server" Text='<%# Bind("Course")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Semester">
                                <ItemTemplate>
                                    <asp:Label ID="lblSem" runat="server" Text='<%# Bind("Seme")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact_No">
                                <ItemTemplate>
                                    <asp:Label ID="lblContact_No" runat="server" Text='<%# Bind("Contact_No")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EMail">
                                <ItemTemplate>
                                    <asp:Label ID="lblEMail" runat="server" Text='<%# Bind("EMail")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblEdit" runat="server"
                                        PostBackUrl='<%# String.Format("~/StudentEntry.aspx?id={0}", Eval("Id"))%>'>
                                         <i class="icon-edit"></i> Edit
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblDelete" runat="server"
                                        PostBackUrl='<%# String.Format("~/Student_List.aspx?id={0}", Eval("Id"))%>'>
                                                <i class="icon-remove"></i> Delete
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Generate Credential">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblCre" runat="server" Text="Generate Credential"
                                        PostBackUrl='<%# String.Format("~/Student_List.aspx?gid={0}", Eval("id"))%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>

                </form>
            </div>
        </div>
    </div>
</asp:Content>

