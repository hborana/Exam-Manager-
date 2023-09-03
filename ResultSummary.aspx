<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ResultSummary.aspx.vb" Inherits="ResultSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="grid-form1">
        <h3>Result Summary </h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Course*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlCourse" runat="server" Font-Bold="True" ValidationGroup="v1" class="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Branch*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlBranch" runat="server" Font-Bold="True" ValidationGroup="v1" class="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Semester*</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlSem" runat="server" Font-Bold="True" ValidationGroup="v1" class="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Enrolment*</label>
                        <div class="col-sm-8">
                            <%--<input type="text" placeholder="Firstname" required="" />--%>
                            <asp:TextBox ID="txtEnrol" runat="server" RegularExpression="" class="form-control2" Font-Bold="True" plaseholder="Please Enter Branch " CausesValidation="True" ValidationGroup="v1"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" * Please Enter Branch" ControlToValidate="txtName" ForeColor="Red" Display="Dynamic" ValidationGroup="v1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="*Name Should  Contain Alphaber Characters" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$" ValidationGroup="v1" Display="Dynamic"></asp:RegularExpressionValidator>--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-offset-6 col-sm-12 w3layouts-bnt">
                            <asp:Button ID="btnVeiw" runat="server" Class="bg-warning dark pv20 text-white fw600 text-center" BorderWidth="0" Text="Veiw" ValidationGroup="v1" Width="142px" Height="66px" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:GridView ID="gvResultEntry" runat="server" BorderWidth="0" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Id" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" text='<%# Bind("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Enrolment">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEnrolment" runat="server" Text='<%# Bind("Enrolment")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                        <asp:TemplateField HeaderText="Student Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("Marks")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </form>
            </div>

        </div>

    </div>

</asp:Content>

