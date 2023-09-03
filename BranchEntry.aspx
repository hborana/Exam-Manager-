<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="BranchEntry.aspx.vb" Inherits="BranchEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Branch<i class="fa fa-angle-right"></i>Entry</li>
    </ol>

    <div class="grid-form1">
        <h3>Branch Entry </h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Course*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlCourse" runat="server" Font-Bold="True" ValidationGroup="v1" class="form-control" ></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Branch Name*</label>
                        <div class="col-sm-8">

                            <asp:TextBox ID="txtName" runat="server" RegularExpression="" class="form-control" Font-Bold="True" plaseholder="Please Enter Branch " CausesValidation="True" ValidationGroup="v1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" * Please Enter Branch" ControlToValidate="txtName" ForeColor="Red" Display="Dynamic" ValidationGroup="v1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="*Name Should  Contain Alphaber Characters" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$" ValidationGroup="v1" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Branch Code*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCode" runat="server" class="form-control" CausesValidation="True" MaxLength="5" ValidationGroup="v1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage=" * Please Enter Branch code" ControlToValidate="txtCode" ForeColor="Red" Display="Dynamic" ValidationGroup="v1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCode" ErrorMessage="*Only 1 to 5 Digits" ForeColor="Red" ValidationExpression="^[0-9]{1,2}$" ValidationGroup="v1" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Number  Of  Semester*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtSem" runat="server" class="form-control" Font-Bold="True" plaseholder="Please Enter Semester" CausesValidation="True" MaxLength="2" ValidationGroup="v1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage=" * Please Enter Semester" ControlToValidate="txtSem" ForeColor="Red" Display="Dynamic" ValidationGroup="v1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtSem" ErrorMessage="*Only 1 or 2 Digits" ForeColor="Red" ValidationExpression="^[0-9]{1,2}$" ValidationGroup="v1" Display="Dynamic"></asp:RegularExpressionValidator>
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

