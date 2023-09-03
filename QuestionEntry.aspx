<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="QuestionEntry.aspx.vb" Inherits="QuestionEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Question<i class="fa fa-angle-right"></i>Entry</li>
    </ol>
    <div class="grid-form1">
        <h3>Question Entry </h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <%-- <div class="form-group">
                        <label>*Format Name</label><asp:DropDownList class="form-control" ID="ddlFormat" runat="server" Width="199px" Font-Bold="True" AutoPostBack="True" ValidationGroup="v8"></asp:DropDownList>
                    </div>--%>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">*Branch Name</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlBranch" runat="server" Class="form-control" placeholder="Enter Select Semester" Font-Bold="True" AutoPostBack="True" ValidationGroup="v8"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">*Semester</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlSem" runat="server" Class="form-control" placeholder="Enter Select Semester" Font-Bold="True" AutoPostBack="True" ValidationGroup="v8"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">*Subject</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlSubject" runat="server" Class="form-control" placeholder="Enter Select Semester" Font-Bold="True" AutoPostBack="True" ValidationGroup="v8"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">*Chapter</label>
                       <div class="col-sm-8">
                            <asp:DropDownList ID="ddlChapter" runat="server" Class="form-control" placeholder="Enter Select Semester" Font-Bold="True" AutoPostBack="True" ValidationGroup="v8"></asp:DropDownList>
                        </div>

                    </div>
                    <%--<div class="col-lg-12">
                        <div class="col-lg-6">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" ValidationGroup="v8" />
                        </div>--%>
                    <div class="form-group">
                        <div class="col-lg-offset-6 col-sm-12 w3layouts-bnt">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <br />
                            <asp:Button ID="btnUpload" runat="server" Class="bg-warning dark pv20 text-white fw600 text-center" BorderWidth="0" Text="Upload" Width="142px" Height="66px" />
                            <asp:DropDownList ID="ddlSheets" runat="server" AppendDataBoundItems="true" Visible="false"></asp:DropDownList>
                            <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" />
                            <asp:Label ID="lblFileName" runat="server" Text="Enter Source Table Name" Visible="false" />
                            <asp:TextBox ID="txtTable" runat="server" Visible="false"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" Text="Has Header ?" Visible="false" />
                            <asp:RadioButtonList ID="rbHDR" runat="server" Visible="false">
                                <asp:ListItem Text="Yes" Value="Yes" Selected="True">
                                </asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="col-sm-8">
                        <asp:LinkButton ID="LinkButton1" Class="form-control2" runat="server">Click Here to Download Format</asp:LinkButton>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-8 col-lg-offset-2">
                            <asp:GridView ID="gvUpload" runat="server" BorderWidth="0" AllowPaging="false" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="Question">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuestion" runat="server" Text='<%# Bind("Question")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMarks" runat="server" Text='<%# Bind("Marks")%>'></asp:Label>
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

