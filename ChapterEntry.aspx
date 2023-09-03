<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ChapterEntry.aspx.vb" Inherits="ChapterEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Chapter<i class="fa fa-angle-right"></i>Entry</li>
    </ol>

    <div class="grid-form1">
        <h3>Chapter Entry</h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Subject*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control" ID="ddlSubject" runat="server" Font-Bold="True" ValidationGroup="v2"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Chapter Name*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtName" runat="server" Class="form-control" placeholder="Chapter Name" Font-Bold="True" ValidationGroup="v2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" * Please Enter Chapter " ControlToValidate="txtName" ForeColor="Red" ValidationGroup="v2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <div class="col-lg-offset-6 col-sm-12 w3layouts-bnt">
                            <asp:Button ID="btnSave" runat="server" Class="bg-warning dark pv20 text-white fw600 text-center" BorderWidth="0" Text="Save" ValidationGroup="v2"  Width="142px" Height="66px"  />
                        </div>
                    </div>
                </form>
            </div>

        </div>

    </div>
</asp:Content>

