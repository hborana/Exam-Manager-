<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Faculty_Subject.aspx.vb" Inherits="Faculty_Subject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
<script src="check/icheck.min.js"></script>
<link href="check/skins/flat/blue.css" rel="stylesheet" />
    <div class="grid-form1">
        <h3>Faculty/Subject Entry </h3>
        <div class="tab-content">
            <div class="col-md-12">
                <div class="tab-pane active" id="horizontal-form">
                    <form class="form-horizontal" id="Form1" role="form" runat="server">
                        <asp:HiddenField ID="hdnId" runat="server" />
                        <div class="form-class">
                            <div class="row mb40">
                                <div class="col-md-6">
                                    <label class="col-sm-1 control-label">Course*</label>
                                        <%--<div class="col-sm-8">--%>
                                    <asp:DropDownList ID="ddlCourse" runat="server" Font-Bold="True" ValidationGroup="v1" class="form-control2" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                   <%-- </div>--%>
                                <div class="col-md-6">
                                    <label class="col-sm-1 control-label">Branch*</label>
                                    <asp:DropDownList ID="ddlBranch" runat="server" Font-Bold="True" ValidationGroup="v1" class="form-control2" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-class">
                            <div class="row mb40">
                                <div class="col-md-6">
                                    <label class="col-sm-1 control-label">Sem*</label>
                                    <asp:DropDownList ID="ddlSem" runat="server" Font-Bold="True" ValidationGroup="v1" class="form-control2" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="col-md-6">
                                    <label class="col-sm-1 control-label">Subject*</label>
                                    <asp:DropDownList ID="ddlSubject" runat="server" Font-Bold="True" ValidationGroup="v1" class="form-control2" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                         <div class="form-class">
                            <div class="row mb40">
                                <div class="col-md-6">
                                    <label class="col-sm-1 control-label">Faculty*</label>
                                    <asp:DropDownList ID="ddlFaculty" runat="server" Font-Bold="True" ValidationGroup="v1" class="form-control2" AutoPostBack="true"></asp:DropDownList>
                                </div>
                               
                            </div>
                        </div>
                       
                        <div class="form-group">
                    <div class="col-lg-offset-5 col-sm-12 w3layouts-bnt">
                           <asp:Button ID="btnSave" runat="server" Class="bg-warning dark pv20 text-white fw600 text-center" BorderWidth="0" Text="Save" ValidationGroup="v1" Width="142px" Height="66px"  />
                        </div>
                    </div>
                       
                </form>     
            </div>


        </div>
    </div>
    </div>
    
         
</asp:Content>

