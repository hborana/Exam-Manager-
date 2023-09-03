<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="QuestionFormat_Entry.aspx.vb" Inherits="QuestionFormat_Entry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script src="check/icheck.min.js"></script>
    <link href="check/skins/flat/blue.css" rel="stylesheet" />
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>QuestionPaper Format<i class="fa fa-angle-right"></i>Entry</li>
    </ol>
    <div class="grid-form1">
        <h3>Question Format</h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="form-group">
                        <label class="col-sm-3 control-label">*Format Type</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control" ID="ddlFormat" runat="server" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Parent Question*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control" ID="ddlParentQuestion" runat="server" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>
                            <%--  <asp:TextBox ID="txtparentQuestion" runat="server" Class="form-control2" placeholder="Question Number" Font-Bold="True" TextMode="Singleline" CausesValidation="True"></asp:TextBox>
                            --%>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Question Number*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtQuestion_No" runat="server" Class="form-control" MaxLength="2" placeholder="Question Number" Font-Bold="True" TextMode="Singleline" CausesValidation="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Please Enter Question Number" ControlToValidate="txtQuestion_No" ForeColor="Red" ValidationGroup="v13" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtQuestion_No" Display="Dynamic" ErrorMessage="*Only 2 Digits is allowed" ForeColor="Red" ValidationExpression=" ^[0-9]{1,2}$" ValidationGroup="v13"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Question Number Heading*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtHeading" runat="server" Class="form-control" placeholder="Question Number Heading Eg.(Q.1)" Font-Bold="True" TextMode="Singleline" CausesValidation="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Please Enter Question Heading" ControlToValidate="txtQuestion_No" ForeColor="Red" ValidationGroup="v13" Display="Dynamic"></asp:RequiredFieldValidator>
                            <br />
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtQuestion_No" Display="Dynamic" ErrorMessage="*Only 2 Digits is allowed" ForeColor="Red" ValidationExpression=" ^[0-9]{1,2}$" ValidationGroup="v13"></asp:RegularExpressionValidator>--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Heading*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtHeading_Que" runat="server" Class="form-control" placeholder="Question Heading Eg.(Five out of ten)" Font-Bold="True" TextMode="Singleline" CausesValidation="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Please Enter Heading" ControlToValidate="txtQuestion_No" ForeColor="Red" ValidationGroup="v13" Display="Dynamic"></asp:RequiredFieldValidator>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtQuestion_No" Display="Dynamic" ErrorMessage="*Only 2 Digits is allowed" ForeColor="Red" ValidationExpression=" ^[0-9]{1,2}$" ValidationGroup="v13"></asp:RegularExpressionValidator>--%>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-sm-3 control-label">Required Question*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtRequired_No" runat="server" Class="form-control" placeholder="Required Number Of Question  " Font-Bold="True" MaxLength="2" CausesValidation="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Please Enter Required Number of Question" ControlToValidate="txtRequired_No" ForeColor="Red" ValidationGroup="v13" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtRequired_No" Display="Dynamic" ErrorMessage="*Only 2 Digits is Allowed" ForeColor="Red" ValidationExpression=" ^[0-9]{1,2}$" ValidationGroup="v13"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Maximum Question* </label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtOut_Of" runat="server" Class="form-control" placeholder="Maximum Number of Question  " Font-Bold="True" MaxLength="2" CausesValidation="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Please Enter Maximum Question Number" ControlToValidate="txtOut_Of" ForeColor="Red" ValidationGroup="v13" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtOut_Of" Display="Dynamic" ErrorMessage="*Only 2 Digits are Allowed " ForeColor="Red" ValidationExpression=" ^[0-9]{1,2}$" ValidationGroup="v13"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Weightage of the Question* </label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtMarks" runat="server" MaxLength="2" Class="form-control" placeholder="Enter Marks " Font-Bold="True" TextMode="Singleline" CausesValidation="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Enter Marks" ControlToValidate="txtMarks" ForeColor="Red" ValidationGroup="v13" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtMarks" Display="Dynamic" ErrorMessage="*Only 2 Digits are Allowed" ForeColor="Red" ValidationExpression=" ^[0-9]{1,2}$" ValidationGroup="v13"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Same Mark Question*</label>
                        <div class="col-sm-8">
                            <asp:CheckBox ID="ChkIs_Of_Same_Mark" runat="server" />
                            <script>
                                $(document).ready(function () {
                                    $('input').iCheck({
                                        checkboxClass: 'icheckbox_flat-blue',
                                        radioClass: 'iradio_flat-blue',
                                        increaseArea: '20%' // optional
                                    });
                                });
                            </script>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-offset-6 col-sm-12 w3layouts-bnt">
                            <asp:Button ID="btnSave" runat="server" Class="bg-warning dark pv20 text-white fw600 text-center" BorderWidth="0" Text="Save" ValidationGroup="v13" Width="142px" Height="66px" />
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>

