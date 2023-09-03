<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ForgotPassword.aspx.vb" Inherits="ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="grid-form1">
        <h3>Branch Entry Form</h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                        <div class="form-group">
                            <label class="col-sm-3 control-label">User Name*</label>
                           <div class="col-sm-8">
                             <asp:TextBox ID="txtUserName" runat="server" Class="form-control2" Font-Bold="True" plaseholder="Please Enter User Name " CausesValidation="True" ValidationGroup="v1"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" * Please Enter Branch" ControlToValidate="txtName" ForeColor="Red" Display="Dynamic" ValidationGroup="v1" ></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="*Name Should  Contain Alphaber Characters" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$" ValidationGroup="v1" Display="Dynamic"></asp:RegularExpressionValidator>
                            --%>
                        </div>
                            </div>
                       
                    <div class="form-group">
                    <div class="col-lg-offset-6 col-sm-12 w3layouts-bnt">
                           <asp:Button ID="btnGetPassword" runat="server" Class="bg-warning dark pv20 text-white fw600 text-center" BorderWidth="0" Text="Get Password" ValidationGroup="v1" Width="142px" Height="66px"/>
                        </div>
                    </div>
                </form>
                </div>
            </div>
        </div>
</asp:Content>

