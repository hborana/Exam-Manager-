<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FormatEntry.aspx.vb" Inherits="FormatEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Paper Format<i class="fa fa-angle-right"></i>Entry</li>
    </ol>
     <div class="grid-form1">
        <h3>Paper Format Entry</h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Name*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtName" runat="server" Class="form-control2" placeholder="Format Name" Font-Bold="True" CausesValidation="True" ValidationGroup="v6"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" * Please Enter  Paper Format" ControlToValidate="txtName" ForeColor="Red" Display="Dynamic" ValidationGroup="v6"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="*Name Should Contain Alphanumeric Characters " ForeColor="Red" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="v6" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Marks*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtMarks" runat="server" Class="form-control2" placeholder="Marks" Font-Bold="True" CausesValidation="True"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-offset-6 col-sm-12 w3layouts-bnt">
                            <asp:Button ID="btnSave" runat="server" Class="bg-warning dark pv20 text-white fw600 text-center" BorderWidth="0" Text="Save" ValidationGroup="v6" Width="142px" Height="66px" />
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>

