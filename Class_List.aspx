<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Class_List.aspx.vb" Inherits="Class_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                  <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Exam Manager</a><i class="fa fa-angle-right"></i>Class<i class="fa fa-angle-right"></i>List</li>
    </ol>

     <div id="content">
        <div class="agile-tables">
            <div class="w3l-table-info">
                <h3>Class List</h3>
                <form id="Form1" runat="server">

                    <%--<table id="table-no-resize">
                                        <thead>
                                            <tr>
                                                <th>Name</th>
                                                <th>Age</th>
                                                <th>Gender</th>
                                                <th>Height</th>
                                                <th>Province</th>
                                                <th>Sport</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>Jill Smith</td>
                                                <td>25</td>
                                                <td>Female</td>
                                                <td>5'4</td>
                                                <td>British Columbia</td>
                                                <td>Volleyball</td>
                                            </tr>
                                        </tbody>
                                  </table>--%>
                 <asp:GridView ID="dgvClass" runat="server" AutoGenerateColumns="false" BorderWidth="0">
                            <Columns>
                                <asp:TemplateField HeaderText="Class Number">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumber" runat="server" Text='<%# Bind("Class_No")%>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Number Of Branches">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumberOfBranches" runat="server" Text='<%# Bind("Number_Of_Benches")%>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Student Per Benches">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStudentPerBenches" runat="server" Text='<%# Bind("Student_Per_Benches")%>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remark">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark")  %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                          <asp:LinkButton ID="lblEdit" runat="server"
                                                PostBackUrl='<%# String.Format("~/ClassEntry.aspx?id={0}", Eval("Id"))%>'>
                                         <i class="icon-edit"></i> Edit
                                            </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                         <asp:LinkButton ID="lblDelete" runat="server"
                    PostBackUrl='<%# String.Format("~/Class_List.aspx?id={0}", Eval("Id"))%>'  >
                                                <i class="icon-remove"></i> Delete
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                         </form>
                </div>
            </div>
         </div>
    
</asp:Content>

