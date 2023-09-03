<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="SubjectEntry.aspx.vb" Inherits="SubjectEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Subject<i class="fa fa-angle-right"></i>List</li>
    </ol>
    <div class="grid-form1">
        <h3>Subject Entry</h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="form-group">

                        <label class="col-sm-3 control-label">Branch Name*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlBranch" runat="server" Font-Bold="True" AutoPostBack="True" ValidationGroup="v11"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label">Semester*</label>
                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddlSem" runat="server" Class="form-control2" placeholder="Please Select Semester" Font-Bold="True" AutoPostBack="True" ValidationGroup="v11"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Subject Name*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtName" runat="server" Class="form-control2" Font-Bold="True" TextMode="MultiLine" CausesValidation="True" ValidationGroup="v11"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" * Please Enter Subject" ControlToValidate="txtName" ForeColor="Red" Display="Dynamic" ValidationGroup="v11"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="*Name Should Contain  Alphabet Characters " ForeColor="Red" ValidationExpression="[a-zA-Z ]*$" ValidationGroup="v11" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Subject Code*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCode" runat="server" Class="form-control2" CausesValidation="True" MaxLength="7" ValidationGroup="v11"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage=" * Please Enter Subject code" ControlToValidate="txtCode" ForeColor="Red" Display="Dynamic" ValidationGroup="v11"></asp:RequiredFieldValidator>

                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCode" ErrorMessage="*Please Enter Proper Code" ForeColor="Red" ValidationExpression="^[0-9]{1,7}$" ValidationGroup="v11" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="col-lg-offset-6 col-sm-12 w3layouts-bnt">
                            <asp:Button ID="btnSave" runat="server" Class="bg-warning dark pv20 text-white fw600 text-center" BorderWidth="0" Text="Save" ValidationGroup="v11" Width="142px" Height="66px" />
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>

