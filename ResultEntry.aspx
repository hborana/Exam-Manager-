<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ResultEntry.aspx.vb" Inherits="ResultEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Result<i class="fa fa-angle-right"></i>Entry</li>
    </ol>
    <div class="grid-form1">
        <h3>Result Entry </h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Course*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control" ID="ddlCourse" runat="server" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Branch*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control" ID="ddlBranch" runat="server" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Subject*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control" ID="ddlSubject" runat="server" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Semester*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control" ID="ddlSem" runat="server" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Exam*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control" ID="ddlExam" runat="server" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-offset-6 col-sm-12 w3layouts-bnt">
                            <asp:Button ID="btnLoad" runat="server" Class="bg-warning dark pv20 text-white fw600 text-center" BorderWidth="0" Text="Load" ValidationGroup="v1" Width="142px" Height="66px" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-8 col-lg-offset-2">
                            <asp:GridView ID="gvResultEntry" runat="server" BorderWidth="0" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%# Bind("Student_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Enrolment">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEnrolment" runat="server" Text='<%# Bind("Enrolment")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Student Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtMarks" runat="server" OnTextChanged="txtMarks_TextChanged" Class="form-control" CausesValidation="True" MaxLength="2" AutoPostBack="true" Text='<%# Bind("Marks")%>' align="center"></asp:TextBox>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-offset-6 col-sm-12 w3layouts-bnt">
                            <asp:Button ID="btnSave" runat="server" Class="bg-warning dark pv20 text-white fw600 text-center" BorderWidth="0" Text="Save" ValidationGroup="v1" Width="142px" Height="66px" />
                        </div>
                    </div>

                </form>
            </div>
        </div>
    </div>




</asp:Content>

