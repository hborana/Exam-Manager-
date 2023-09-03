<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Login.aspx.vb" Inherits="Login" EnableEventValidation="false"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!--[if IE]>
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
        <![endif]-->
    <!-- GLOBAL STYLES -->
     <!-- PAGE LEVEL STYLES -->
     <link rel="stylesheet" href="assets/plugins/bootstrap/css/bootstrap.css" />
    <link rel="stylesheet" href="assets/css/login.css" />
    <link rel="stylesheet" href="assets/plugins/magic/magic.css" />
     <!-- END PAGE LEVEL STYLES -->
   <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    
       <!-- PAGE CONTENT --> 
    <div class="container">
    <div class="text-center">
        <%--<img src="assets/img/logo.png" id="logoimg" alt=" Logo" />--%>
       <%-- <img src=".\pictures\login.jpg" id="logoin" alt=" Logo" />--%>
    </div>
    <div class="tab-content">
        <div id="login" class="tab-pane active" style="text-align-last:auto">
            <form action="#" class="form-signin" runat="server"> 
                <div class="text-muted text-center btn-block btn btn-primary btn-rect" style="width:496px" >
                    Enter your username and password
                </div>
                
                <asp:TextBox ID="txtName" runat="server" placeholder="Username" class="form-control"  Width="496px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Please Enter User Name" ControlToValidate="txtName" ForeColor="Red">
                </asp:RequiredFieldValidator>
                
                <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" class="form-control" Width="496px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* Please Enter Password" ControlToValidate="txtPassword" ForeColor="Red">
                </asp:RequiredFieldValidator>
               
                <asp:Button ID="btnSave" runat="server" CssClass="btn text-muted text-center btn-success" Text="Save" CausesValidation="False" />
                  
            </form>
<%--            <div class="text-center">
                <ul class="list-inline">
                    <li><a class="text-muted" href="#login" data-toggle="tab">Login</a></li>
                    <li><a class="text-muted" href="#forgot" data-toggle="tab">Forgot Password</a></li>
                    <li><a class="text-muted" href="#signup" data-toggle="tab">Signup</a></li>
                </ul>
            </div>--%>
        </div>
        <%--<div id="forgot" class="tab-pane">
            <form action="index.html" class="form-signin">
                <p class="text-muted text-center btn-block btn btn-primary btn-rect">Enter your valid e-mail</p>
                
                <input type="email"  required="required" placeholder="Your E-mail"  class="form-control" />
                <br />
                <button class="btn text-muted text-center btn-success" type="submit">Recover Password</button>
            </form>
        </div>
        <div id="signup" class="tab-pane">
            <form action="index.html" class="form-signin">
                <p class="text-muted text-center btn-block btn btn-primary btn-rect">Please Fill Details To Register</p>
                 <input type="text" placeholder="First Name" class="form-control" />
                 <input type="text" placeholder="Last Name" class="form-control" />
                <input type="text" placeholder="Username" class="form-control" />
                <input type="email" placeholder="Your E-mail" class="form-control" />
                <input type="password" placeholder="password" class="form-control" />
                <input type="password" placeholder="Re type password" class="form-control" />
                <button class="btn text-muted text-center btn-success" type="submit">Register</button>
            </form>
        </div>--%>
    </div>
    


</div>

	  <!--END PAGE CONTENT -->     
	      
      <!-- PAGE LEVEL SCRIPTS -->
      <script src="assets/plugins/jquery-2.0.3.min.js"></script>
      <script src="assets/plugins/bootstrap/js/bootstrap.js"></script>
   <script src="assets/js/login.js"></script>
      <!--END PAGE LEVEL SCRIPTS -->




</body>
</html>
