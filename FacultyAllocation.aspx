<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FacultyAllocation.aspx.vb" Inherits="FacultyAllocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Faculty Allocation</li>
    </ol>
     <div class="grid-form1">
        <h3>Faculty Allocation </h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Exam*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlExam" runat="server" Font-Bold="True" AutoPostBack="True" ValidationGroup="v1"></asp:DropDownList>
                        </div>
                    </div>
                  <div class="form-group">
                        <div class="col-sm-8 col-lg-offset-2" >
                           <label class="form-control2" id="lbExam" runat="server" style="width:701px;background-color:cornsilk" visible="false">timetable List</label>
                    </div>
                        </div>
                    <div class="form-group">
                        <div class="col-sm-8 col-lg-offset-2">
                            <asp:GridView ID="gvExam" runat="server" BorderWidth="0" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkExam" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                        <div class="col-sm-8 col-lg-offset-2" >
                           <label class="form-control2" id="lbClass" runat="server" style="width:701px;background-color:cornsilk" visible="false">Class List</label>
                    </div>
                        </div>
                    <div class="form-group">
                        <div class="col-sm-8 col-lg-offset-2">
                            <asp:GridView ID="gvClass" runat="server" BorderWidth="0" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkClass" runat="server" Checked="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Class" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClassId" runat="server" Text='<%# Bind("Id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Class Number">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClass" runat="server" Text='<%# Bind("Class")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-8 col-lg-offset-2">
                            <label class="form-control2" id="lbFaculty" runat="server" style="width: 701px; background-color: cornsilk">Faculty List</label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-8 col-lg-offset-2">
                            <asp:GridView ID="gvFaculty" runat="server" BorderWidth="0" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkFaculty" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFaculty" runat="server" Text='<%# Bind("Id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Enrolment">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEnrol" runat="server" Text='<%# Bind("Enrolment")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranch" runat="server" Text='<%# Bind("Branch")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Designation">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDesignation" runat="server" Text='<%# Bind("Designation")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-offset-5 col-sm-12 w3layouts-bnt">
                            <asp:Button ID="btnSave" runat="server" Class="bg-warning dark pv20 text-white fw600 text-center " BorderWidth="0" Text="Save" Width="142px" Height="66px" />
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>

