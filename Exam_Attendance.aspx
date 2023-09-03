<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Exam_Attendance.aspx.vb" Inherits="Exam_Attendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script src="check/icheck.min.js"></script>
    <link href="check/skins/flat/blue.css" rel="stylesheet" />
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Exam Attendance</li>
    </ol>

    <div class="grid-form1">
        <h3>Exam Attendance</h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Branch*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlBranch" runat="server" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Semester*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlSem" runat="server" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Exam*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlExam" runat="server" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>

                        </div>
                    </div>
                     <div class="form-group">
                        <div class="col-sm-8 col-lg-offset-2">
                        <asp:GridView ID="gvExamAttendance" runat="server" BorderWidth="0" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkHeader" runat="server" Checked="false" OnCheckedChanged="chkHeader_CheckedChanged" AutoPostBack="true" />
                    <script>
                        $(document).ready(function () {
                            $('input').iCheck({
                                checkboxClass: 'icheckbox_flat-blue',
                                radioClass: 'iradio_flat-blue',
                                increaseArea: '20%' // optional
                            });
                        });
                            </script>
                                                          </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkIsPresent" runat="server" Checked="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("Student_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Student Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Enrollnment">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEnroll" runat="server" Text='<%# Bind("Enrolment")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- <asp:TemplateField HeaderText="Branch Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblBranch" runat="server" Text='<%# Bind("Branch")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Course Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblCourse" runat="server" Text='<%# Bind("Course")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Semester">
                                <ItemTemplate>
                                    <asp:Label ID="lblSem" runat="server" Text='<%# Bind("Sem")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
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

