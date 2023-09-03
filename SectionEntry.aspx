<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="SectionEntry.aspx.vb" Inherits="SectionEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Section<i class="fa fa-angle-right"></i>Entry</li>
    </ol>
    <div class="grid-form1">
        <h3>Section Entry</h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Course Name*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlCourse" runat="server" Font-Bold="True" ValidationGroup="v10" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Branch Name*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlBranch" runat="server" Font-Bold="True" ValidationGroup="v10" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div>
                        <label class="col-sm-3 control-label">Semester*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlSem" runat="server" Font-Bold="True" ValidationGroup="v10" AutoPostBack="True"></asp:DropDownList>
                        </div>


                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Section*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtSection" runat="server" Class="form-control2" ValidationGroup="v10" CausesValidation="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage=" *Please Enter Section" ControlToValidate="txtSection" ForeColor="Red" ValidationGroup="v10" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSection" ErrorMessage="*Enter Proper Section Name" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$" ValidationGroup="v10" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Number Of Student* </label>
                        <div class="col-sm-8">
                            &nbsp;<asp:TextBox ID="txtNo_Of_Student" runat="server" Class="form-control2" Font-Bold="True" plaseholder="Please Enter Semester" ValidationGroup="v10" CausesValidation="True" MaxLength="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage=" * Please Enter Student" ControlToValidate="txtNo_Of_Student" ForeColor="Red" ValidationGroup="v10" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtNo_Of_Student" ErrorMessage="*Enter Only  Numeric Value" ForeColor="Red" ValidationExpression="^[0-9]{1,2}$" ValidationGroup="v10" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Academic Year*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtAcademic_Year" runat="server" Class="form-control2" Font-Bold="True" plaseholder="Please Enter Academic Year" ValidationGroup="v10" CausesValidation="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage=" *Please Enter Academic Year" ControlToValidate="txtAcademic_Year" ForeColor="Red" ValidationGroup="v10" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtAcademic_Year" ErrorMessage="*Enter Proper Year" ForeColor="Red" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="v10" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-lg-offset-6 col-sm-12 w3layouts-bnt">
                            <asp:Button ID="btnSave" runat="server" Class="bg-warning dark pv20 text-white fw600 text-center" BorderWidth="0" Text="Save" ValidationGroup="v10" Width="142px" Height="66px" />

                        </div>
                    </div>



                </form>
            </div>
        </div>
    </div>
</asp:Content>

