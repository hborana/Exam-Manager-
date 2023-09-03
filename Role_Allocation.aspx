<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Role_Allocation.aspx.vb" Inherits="Role_Allocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Role Allocation</li>
    </ol>
    <div class="grid-form1">
        <h3>Role Allocation</h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Role*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList class="form-control2" ID="ddlRole" runat="server" AutoPostBack="True" ValidationGroup="v9"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-offset-6 col-sm-12 w3layouts-bnt">
                            <asp:Button ID="btn_load" runat="server" Class="bg-warning dark pv20 text-white fw600 text-center" BorderWidth="0" Text="Load" ValidationGroup="v9" Width="142px" Height="66px" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-8 col-lg-offset-2">
                            <label class="form-control2" id="lbFunction" runat="server" style="width: 701px; background-color: cornsilk" visible="false"><b>Function</b></label>
                            <asp:GridView ID="dgvRole_Allocation" runat="server" BorderWidth="0" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_functionid" runat="server" Text='<%# Bind("Id")%>' Visible="False"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Function Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_functionname" runat="server" Text='<%# Bind("Function_id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="is_allowed">
                                        <ItemTemplate>

                                            <asp:CheckBox ID="chk_isallowed" runat="server" Text='<%# Bind("is_allow")%>' Checked="True" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-offset-6 col-sm-12 w3layouts-bnt">
                            <asp:Button ID="btnSave" runat="server" Class="bg-warning dark pv20 text-white fw600 text-center" BorderWidth="0" Text="Save" ValidationGroup="v9" Width="142px" Height="66px" />
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>

