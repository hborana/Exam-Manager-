<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="StudentAllocation_List.aspx.vb" Inherits="StudentAllocation_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Student Allocation<i class="fa fa-angle-right"></i>View</li>
    </ol>
    <div class="grid-form1">
        <h3>StudentAllocation List </h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Class*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlClass" runat="server" Font-Bold="True" AutoPostBack="True" ValidationGroup="v1"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Exam*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlExam" runat="server" Font-Bold="True" AutoPostBack="True" ValidationGroup="v1"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Branch Name*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtName" runat="server" Class="form-control2" Font-Bold="True" Enabled="false" Width="397px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Semester*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtSem" runat="server" Class="form-control2" Font-Bold="True" Enabled="false" Width="397px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-8 col-lg-offset-2">
                            <label class="form-control2" id="lbExam" runat="server" style="width: 701px; background-color: cornsilk" visible="false">Class</label>
                            <asp:GridView ID="dgvClass" runat="server" BorderWidth="0" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="Seat_No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSeat_No" runat="server" Text='<%# Bind("Seat_No")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Enrolment">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEnrol" runat="server" Text='<%# Bind("Enrolment")  %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--  <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lblEdit" runat="server"
                                                PostBackUrl='<%# String.Format("~/BranchEntry.aspx?id={0}", Eval("Id"))%>'>
                                         <i class="icon-edit"></i> Edit
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                           <asp:LinkButton ID="lblDelete" runat="server"
                                                PostBackUrl='<%# String.Format("~/Branch_List.aspx?id={0}", Eval("Id"))%>'  >
                                                <i class="icon-remove"></i> Delete
                                        </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Total Student*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtStudent" runat="server" Class="form-control2" Font-Bold="True" Enabled="false"></asp:TextBox>
                        </div>
                    </div>

                </form>
            </div>
        </div>
    </div>
</asp:Content>

