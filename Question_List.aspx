<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Question_List.aspx.vb" Inherits="Question_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Question<i class="fa fa-angle-right"></i>List</li>
    </ol>  
     <div class="grid-form1">
        <h3>Question Entry</h3>
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
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Subject*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlSubject" runat="server" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Chapter*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control" ID="ddlChapter" runat="server" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-8 col-lg-offset-2">
                        <%--<table class="table table-striped table-bordered table-hover" id="dataTables-example">
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
                        <asp:GridView ID="dgvQuestion" runat="server" BorderWidth="0" AutoGenerateColumns="false">
                            <Columns>
<%--                                <asp:TemplateField HeaderText="Format Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFormat" runat="server" Text='<%# Bind("Format")%>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Branch Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranch" runat="server" Text='<%# Bind("Branch")%>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Semester">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSem" runat="server" Text='<%# Bind("Sem_ID")%>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Subject Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubject" runat="server" Text='<%# Bind("Subject")%>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chapter">
                                    <ItemTemplate>
                                        <asp:Label ID="lblChapter" runat="server" Text='<%# Bind("Chapter")%>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                 <asp:TemplateField HeaderText="Question">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuestion" runat="server" Text='<%# Bind("Question")%>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Marks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMarks" runat="server" Text='<%# Bind("Marks")%>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Edit">
                                   <ItemTemplate>
                                            <asp:LinkButton ID="lblEdit" runat="server"
                                                PostBackUrl='<%# String.Format("~/QyestionEntry.aspx?id={0}", Eval("Id"))%>'>
                                         <i class="icon-edit"></i> Edit
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                         <asp:LinkButton ID="lblDelete" runat="server"
                    PostBackUrl='<%# String.Format("~/Question_List.aspx?id={0}", Eval("Id"))%>' >
                                             <i class="icon-remove"></i> Delete
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                            </div>
                        </div>
           </form>
        </div>
    </div>
           </div>
</asp:Content>

