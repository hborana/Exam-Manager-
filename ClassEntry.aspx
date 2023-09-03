<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ClassEntry.aspx.vb" Inherits="ClassEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Class<i class="fa fa-angle-right"></i>Entry</li>
    </ol>

    <div class="grid-form1">
        <h3>Class Entry </h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Class Number*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtName" runat="server" Class="form-control" Font-Bold="True" ValidationGroup="v3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" * Please Enter Class" ControlToValidate="txtName" ForeColor="Red" Display="Dynamic" ValidationGroup="v3"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="*Please Enter Numeric Value" ForeColor="Red" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="v3" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Number Of  Benches*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtNumberOfBenches" runat="server" Class="form-control" ValidationGroup="v3" MaxLength="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage=" * Please Enter Number  Of  Benches" ControlToValidate="txtNumberOfBenches" ForeColor="Red" Display="Dynamic" ValidationGroup="v3"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Please Enter Numeric Value" ForeColor="Red" ValidationExpression="^[0-9]{1,3}$" ValidationGroup="v3" ControlToValidate="txtNumberOfBenches" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Student  Per  Bench*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtstudentPerBenches" runat="server" Class="form-control" MaxLength="1" ValidationGroup="v3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage=" * Please Enter Student  Per Benches" ControlToValidate="txtstudentPerBenches" ForeColor="Red" Display="Dynamic" ValidationGroup="v3"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Please Enter Numeric Value" ForeColor="Red" ValidationExpression="^[0-9]{1,2}$" ValidationGroup="v3" ControlToValidate="txtstudentPerBenches" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Remark</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtRemark" runat="server" Class="form-control" placeholder="Remark" Font-Bold="True" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-offset-6 col-sm-12 w3layouts-bnt">
                            <asp:Button ID="btnSave" runat="server" Class="bg-warning dark pv20 text-white fw600 text-center" BorderWidth="0" Text="Save" ValidationGroup="v3"  Width="142px" Height="66px"  />
                        </div>
                    </div>

                </form>
            </div>
        </div>
    </div>

</asp:Content>

