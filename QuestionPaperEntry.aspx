<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="QuestionPaperEntry.aspx.vb" Inherits="QuestionPaperEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>QuestionPaper<i class="fa fa-angle-right"></i>Genration</li>
    </ol>
    <div class="grid-form1">
        <h3>Question Paper Entry</h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="form-group">
                        <label class="col-sm-3 control-label">QuestionPaper Name*</label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Font-Bold="True" plaseholder="Please Enter Name" CausesValidation="True" ValidationGroup="v1"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" * Please Enter Branch" ControlToValidate="txtName" ForeColor="Red" Display="Dynamic" ValidationGroup="v1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="*Name Should  Contain Alphaber Characters" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$" ValidationGroup="v1" Display="Dynamic"></asp:RegularExpressionValidator>
                            --%>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Course*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlCourse" runat="server" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Branch*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlBranch" runat="server" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Semester*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlSem" runat="server" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Exam*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control" ID="ddlExam" runat="server" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Paper Format*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlFormat" runat="server" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Total Duretion*</label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtTotalDuretion" runat="server" Class="form-control"  Font-Bold="True" plaseholder="Please Enter Total Duretion" CausesValidation="True" ValidationGroup="v1" TextMode="time"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" * Please Enter Branch" ControlToValidate="txtName" ForeColor="Red" Display="Dynamic" ValidationGroup="v1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="*Name Should  Contain Alphaber Characters" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$" ValidationGroup="v1" Display="Dynamic"></asp:RegularExpressionValidator>
                            --%>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Subject*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlSubject" runat="server" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-8 col-lg-offset-2">
                            <label class="form-control2" id="lbExam" runat="server" style="width: 701px; background-color: cornsilk" visible="false"><b>TimeTable List</b></label>
                            <asp:GridView ID="gvChapter" runat="server" BorderWidth="0" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkExam" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chapter Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChapter" runat="server" Text='<%# Bind("Name")%>'></asp:Label>
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

