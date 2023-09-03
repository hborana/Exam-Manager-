<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="TimetableEntry.aspx.vb" Inherits="TimetableEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>TimeTable<i class="fa fa-angle-right"></i>Formation</li>
    </ol>
    <div class="grid-form1">
        <h3>Timetable Entry</h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Branch Name*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlBranch" runat="server" Font-Bold="True" AutoPostBack="True" ValidationGroup="v12"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Semester*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlsem" runat="server" Font-Bold="True" AutoPostBack="True" ValidationGroup="v12">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Exam Name*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlExam" runat="server" Font-Bold="True" AutoPostBack="True" ValidationGroup="v12"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Exam Date*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtDate" runat="server" Class="form-control2" TextMode="Date" CausesValidation="True" ValidationGroup="v12"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage=" * Please Select Exam Date" ControlToValidate="txtDate" ForeColor="Red" Display="Dynamic" ValidationGroup="v12"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Start Time*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtStartTime" runat="server" Class="form-control2" TextMode="Time" CausesValidation="True" ValidationGroup="v12"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage=" * Please Enter Start Time " ControlToValidate="txtStartTime" ForeColor="Red" Display="Dynamic" ValidationGroup="v12"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">End Time*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtEndTime" runat="server" Class="form-control2" TextMode="Time" CausesValidation="True" ValidationGroup="v12"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage=" * Please Enter End Time " ControlToValidate="txtEndTime" ForeColor="Red" Display="Dynamic" ValidationGroup="v12"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Format Type*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlFormat" runat="server" Font-Bold="True" ValidationGroup="v12"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-sm-3 control-label">Subject Name*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlSubject" runat="server" Font-Bold="True" ValidationGroup="v12"></asp:DropDownList>
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="col-lg-offset-6 col-sm-12 w3layouts-bnt">
                            <asp:Button ID="btnSave" runat="server" Class="bg-warning dark pv20 text-white fw600 text-center" BorderWidth="0" Text="Save" ValidationGroup="v12" Width="142px" Height="66px" />
                        </div>
                    </div>

                </form>
            </div>
        </div>
    </div>
</asp:Content>

