<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="StudentAllocation.aspx.vb" Inherits="StudentAllocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script src="check/icheck.min.js"></script>
    <link href="check/skins/flat/blue.css" rel="stylesheet" />
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Student Allocation</li>
    </ol>
    <div class="grid-form1">
        <h3>Student Allocation </h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Branch Name*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlBranch" runat="server" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Exam Name*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlExam" runat="server" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-8 col-lg-offset-3">
                            <label class="form-control2" id="lbExam" runat="server" style="width: 900px; background-color: cornsilk" visible="false">TimeTable</label>
                        <asp:GridView ID="gvExam" runat="server" BorderWidth="0" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Exam Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblExam" runat="server" Text='<%# Bind("Exam")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" SortExpression="dd/MM/yyyy">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%# Bind("tt_Date")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Branch">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranch" runat="server" Text='<%# Bind("Branch")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubject" runat="server" Text='<%# Bind("Subject")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-8 col-lg-offset-3">
                            <label class="form-control2" id="lbExamList" runat="server" style="width: 900px; background-color: cornsilk" visible="false">Parallel Exam</label>
                        <asp:GridView ID="gvExamList" runat="server" BorderWidth="0" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkExam" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Exam Name" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblExamId" runat="server" Text='<%# Bind("Id")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Exam Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblExam" runat="server" Text='<%# Bind("Exam")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%# Bind("tt_Date")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Branch">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranch" runat="server" Text='<%# Bind("Branch")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubject" runat="server" Text='<%# Bind("Subject")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-8 col-lg-offset-3">
                            <label class="form-control2" id="lbClass" runat="server" style="width: 900px; background-color: cornsilk" visible="false">Available Classes</label>
                            <asp:GridView ID="gvClass" runat="server" BorderWidth="0" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkClass" runat="server" />
                                              <script>
                                                  $(document).ready(function () {
                                                      $('input').iCheck({
                                                          checkboxClass: 'icheckbox_flat-blue',
                                                          radioClass: 'iradio_flat-blue',
                                                          increaseArea: '20%' // optional
                                                      });
                                                  });
                            </script>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Class" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClassId" runat="server" Text='<%# Bind("Id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Class">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClass" runat="server" Text='<%# Bind("Class_No")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Number Of Benches">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNumberOfBenches" runat="server" Text='<%# Bind("Number_Of_Benches")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Students Per Bench">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStudentPerBenches" runat="server" Text='<%# Bind("Student_Per_Benches")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total_Students">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtTotalStudent" runat="server" Text='<%# Bind("Stud_Cnt")%>' Enabled="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>


                    <asp:GridView ID="gvTemp" runat="server" BorderWidth="0">
                    </asp:GridView>


                    <div class="form-group">
                        <div class="col-lg-offset-5 col-sm-12 w3layouts-bnt">
                            <asp:Button ID="btnSave" runat="server" Class="bg-warning dark pv20 text-white fw600 text-center" BorderWidth="0" Text="Save" Width="142px" Height="66px" />
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>

