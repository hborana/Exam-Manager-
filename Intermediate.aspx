<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Intermediate.aspx.vb" Inherits="Intermediate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="grid-form1">
        <h3>Intermediate</h3>
        <div class="tab-content">
            <div class="tab-pane active" id="horizontal-form">
                <form class="form-horizontal" id="Form1" role="form" runat="server">
                    <asp:HiddenField ID="hdnId" runat="server" />
                     <div class="form-group">
                         <label class="col-sm-3 control-label">Course*</label>
                         <div class="col-sm-8">
                                <asp:DropDownList class="form-control2" ID="ddlCourse" runat="server" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>
                           </div>
                              </div>
                    <div class="form-group">
                         <label class="col-sm-3 control-label">Branch*</label>
                         <div class="col-sm-8">
                          
                                <asp:DropDownList class="form-control2" ID="ddlBranch" runat="server" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>
                             </div>
                        </div>
                    <div class="form-group">
                         <label class="col-sm-3 control-label">Semester*</label>
                         <div class="col-sm-8">
                                <asp:DropDownList class="form-control2" ID="ddlSem" runat="server" Font-Bold="True" AutoPostBack="True"></asp:DropDownList>
                               
                         
                         </div>
                        </div>
                     <div class="form-group">
                         <label class="col-sm-3 control-label">Exam*</label>
                         <div class="col-sm-8">
                             <asp:DropDownList class="form-control2" ID="ddlExam" runat="server" AutoPostBack="True"></asp:DropDownList>
                             </div>
                         </div>
                    
                    <div class="form-group">
                    <asp:GridView ID="gvIntermediate" runat="server" BorderWidth="0" AutoGenerateColumns="False" >
                        <Columns>
                             <asp:TemplateField HeaderText="Student Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkStudent" runat="server" />
                                </ItemTemplate>
                                 </asp:TemplateField>
                            </Columns>
                            </asp:GridView>
                        </div>
               
            <div class="form-group">
                    <div class="col-lg-offset-6 col-sm-12 w3layouts-bnt">
                           <asp:Button ID="btnSave" runat="server" Class="bg-warning dark pv20 text-white fw600 text-center" BorderWidth="0" Text="Save" ValidationGroup="v1" Width="142px" Height="66px"  />
                        </div>




                    



                </div>
                    </form>
                         </div>
 
            
                    
                </div>
        
            </div>
    
 

</asp:Content>

