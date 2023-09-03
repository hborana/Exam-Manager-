<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FacultyEntry.aspx.vb" Inherits="FacultyEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Faculty<i class="fa fa-angle-right"></i>Entry</li>
    </ol>
      <div class="grid-form1">
        <h3>Faculty Entry</h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Course Name*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control" ID="ddlCourse" runat="server" AutoPostBack="True" ValidationGroup="v14"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Branch Name*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control" ID="ddlBranch" runat="server" AutoPostBack="True" ValidationGroup="v14"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Faculty Name*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtName" runat="server" Class="form-control" placeholder="Enter your name" CausesValidation="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage=" * Enter your Name" ControlToValidate="txtName" ForeColor="Red" ValidationGroup="v14" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="*Name Should Contain Alphabets  Only" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$" ValidationGroup="v14" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Enrolment*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtEnrl" runat="server" Class="form-control" placeholder="Enter your enrollnment" CausesValidation="True" MaxLength="12" onkeypress="return isNumber(event)"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage=" * Please Enter your Enrollnment " ControlToValidate="txtEnrl" ForeColor="Red" Display="Dynamic" ValidationGroup="v14"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEnrl" ErrorMessage="*Please Enter 12 Digits only" ForeColor="Red" ValidationExpression="^[0-9]{1,12}$" ValidationGroup="v14" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Designation*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlDesignation" runat="server" Class="form-control" CausesValidation="True">
                                <asp:ListItem>HOD</asp:ListItem>
                                <asp:ListItem>Exam-coordinator</asp:ListItem>
                                <asp:ListItem>Adminstrator</asp:ListItem>
                                <asp:ListItem>Faculty</asp:ListItem>
                                <asp:ListItem>Visiting Faculty</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Contact  Number*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtContact_No" runat="server" Class="form-control" placeholder="enter your contact number" CausesValidation="True" MaxLength="10" onkeypress="return isNumber(event)"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage=" * Please Enter Contact Number " ControlToValidate="txtContact_No" ForeColor="Red" Display="Dynamic" ValidationGroup="v14"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtContact_No" ErrorMessage="*Please Enter 10 Digits Only" ForeColor="Red" ValidationExpression="^[0-9]{1,10}$" ValidationGroup="v14" Display="Dynamic"></asp:RegularExpressionValidator>
                            <script type="text/javascript">
                                function isNumber(evt) {
                                    evt = (evt) ? evt : window.event;
                                    var charCode = (evt.which) ? evt.which : evt.keyCode;
                                    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                                        return false;
                                    }
                                    return true;
                                }
                            </script>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">E-Mail*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtEMail" runat="server" Class="form-control" placeholder="samplename@gmail.com" CausesValidation="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage=" * Please Enter Your E-Mail" ControlToValidate="txtEMail" ForeColor="Red" Display="Dynamic" ValidationGroup="v14"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Enter Proper Email" ControlToValidate="txtEMail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" ValidationGroup="v14"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-offset-6 col-sm-12 w3layouts-bnt">
                            <asp:Button ID="btnSave" runat="server" Class="bg-warning dark pv20 text-white fw600 text-center" BorderWidth="0" Text="Save" ValidationGroup="v14" Width="142px" Height="66px" />
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>

