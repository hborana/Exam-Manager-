<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PrintExamAttendance.aspx.vb" Inherits="PrintExamAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Exam Attendance<i class="fa fa-angle-right"></i>View</li>
                </ol>
    
    <div class="grid-form1">
        <h3>Print Class Allocation </h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Exam*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlExam" runat="server" Font-Bold="True" ValidationGroup="v1" class="form-control" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Class*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlClass" runat="server" Font-Bold="True" ValidationGroup="v1" class="form-control" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                     <div class="form-group">
                        <div class="col-lg-offset-6 col-sm-12 w3layouts-bnt">
                            <asp:Button ID="btnViewReport" runat="server" Class="bg-warning dark pv20 text-white fw600 text-center" BorderWidth="0" Text="View Report" ValidationGroup="v1" Width="142px" Height="66px" />
                        </div>
                    </div>
                    </form>
                </div>
            </div>
        </div>
</asp:Content>

