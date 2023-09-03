<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Faculty_List.aspx.vb" Inherits="Faculty_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Faculty<i class="fa fa-angle-right"></i>List</li>
    </ol>
    
    <div class="row">
        <div class="col-lg-12">
            <form id="Form1" runat="server">
    
                    <div class="panel-body">
                        <div class="table-responsive">
                           <%-- <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                            <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>Remark</th>
                                    <th>Edit</th>
                                    <th>Delete</th>
                                </tr>
                            </thead>
                            <tbody>
                                <td>asdf</td>
                                <td>Internet Explorer 4.0</td>
                                <td>Win 95+</td>
                            </tbody>
                        </table>--%>
                            <asp:GridView ID="dgvFaculty" runat="server"  BorderWidth="0" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="Faculty Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name")  %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Enrolment">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEnrl" runat="server" Text='<%# Bind("Enrolment")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Designation">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDesignation" runat="server" Text='<%# Bind("Designation")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranch" runat="server" Text='<%# Bind("Branch")%>'></asp:Label>
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
                                                PostBackUrl='<%# String.Format("~/FacultyEntry.aspx?id={0}", Eval("Id"))%>'>
                                         <i class="icon-edit"></i> Edit
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lblDelete" runat="server"
                                                PostBackUrl='<%# String.Format("~/Faculty_List.aspx?id={0}", Eval("Id"))%>'>
                                                <i class="icon-remove"></i> Delete
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Generate Credential">
                            <ItemTemplate>
                                  <asp:LinkButton ID="lblCre" runat="server"  Text="Generate Credential"
                                    PostBackUrl='<%# String.Format("Staff_List.aspx?gid={0}", Eval("id"))%>' ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>

</asp:Content>

