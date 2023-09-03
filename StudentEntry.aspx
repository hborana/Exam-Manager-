<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="StudentEntry.aspx.vb" Inherits="StudentEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Student<i class="fa fa-angle-right"></i>Entry</li>
    </ol>
    <div class="grid-form1">
        <h3>Student Entry </h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Course Name*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlCourse" runat="server" Width="198px" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Branch Name*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2 validate[required]" ID="ddlBranch" runat="server" Width="199px" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-sm-3 control-label">Semester*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlSem" runat="server" Class="validate[required] form-control2 " placeholder="Select Semester" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Student Name*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtName" runat="server" Class="validate[required] form-control2" placeholder="Enter Your Name" Font-Bold="True" CausesValidation="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="R3" runat="server" ErrorMessage=" * Please Enter Your Name" ControlToValidate="txtName" ForeColor="Red" ValidationGroup="v1" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtName" ErrorMessage="*Name Should Contain Alphabet Characters" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$" ValidationGroup="v1" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Enrolment*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtEnroll" runat="server" Class="form-control2" placeholder="Enter Your Enrollment" Font-Bold="True" CausesValidation="True" ValidationGroup="v1" onkeypress="return isNumber(event)" MaxLength="12"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="R4" runat="server" ErrorMessage=" * Please Enter Your Enrollment" ControlToValidate="txtEnroll" ForeColor="Red" ValidationGroup="v1" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEnroll" ErrorMessage="*Enter Only 12 Digits" ForeColor="Red" ValidationGroup="v1" ValidationExpression="^([7-9]{1})([0-9]{9})$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-sm-3 control-label">Contact  No*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtContact_No" runat="server" Class="form-control2" placeholder="Enter Your Contact Number" Font-Bold="True" CausesValidation="True" MaxLength="10" onkeypress="return isNumber(event)"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="R5" runat="server" ErrorMessage=" * Please Enter Your Contac Number" ControlToValidate="txtContact_No" ForeColor="Red" ValidationGroup="v1" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtContact_No" ErrorMessage="*Enter Only 10 Digits" ForeColor="Red" ValidationExpression="^([7-9]{1})([0-9]{9})$" ValidationGroup="v1" Display="Dynamic"></asp:RegularExpressionValidator>

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
                            <asp:TextBox ID="txtEMail" runat="server" Class="form-control2" placeholder="samplename@gmail.com" Font-Bold="True" CausesValidation="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="R6" runat="server" ErrorMessage=" * Please Enter Your E-Mail" ControlToValidate="txtEMail" ForeColor="Red" ValidationGroup="v1" Display="Dynamic"></asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage=" * Enter Proper E-Mail " ControlToValidate="txtEMail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="v1" Display="Dynamic"></asp:RegularExpressionValidator>
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

