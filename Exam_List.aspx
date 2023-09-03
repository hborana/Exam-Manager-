<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Exam_List.aspx.vb" Inherits="Exam_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Exam<i class="fa fa-angle-right"></i>List</li>
    </ol>
     <div class="grid-form1">
        <h3>Exam List</h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Branch Name*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control" ID="ddlBranch" runat="server" Font-Bold="True" AutoPostBack="True" ValidationGroup="v1"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Semester*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control" ID="ddlSem" runat="server" Font-Bold="True" AutoPostBack="True" ValidationGroup="v1"></asp:DropDownList>
                        </div>
                    </div>
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
                    <asp:GridView ID="dgvExam" runat="server" AutoGenerateColumns="false" BorderWidth="0">
                        <Columns>
                            <asp:TemplateField HeaderText="Exam Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           <%-- <asp:TemplateField HeaderText="Branch">
                                <ItemTemplate>
                                    <asp:Label ID="lblBranch" runat="server" Text='<%# Bind("Branch")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Semester">
                                <ItemTemplate>
                                    <asp:Label ID="lblSem" runat="server" Text='<%# Bind("Seme")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Remark">
                                <ItemTemplate>
                                    <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Close">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbClose" runat="server"
                                        PostBackUrl='<%# String.Format("~/Exam_List.aspx?Close={0}", Eval("Id"))%>'>
                                         <i class="icon-edit"></i> Close
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblEdit" runat="server"
                                        PostBackUrl='<%# String.Format("~/ExamEntry.aspx?id={0}", Eval("Id"))%>'>
                                         <i class="icon-edit"></i> Edit
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblDelete" runat="server"
                                        PostBackUrl='<%# String.Format("~/Exam_List.aspx?id={0}", Eval("Id"))%>'>
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

