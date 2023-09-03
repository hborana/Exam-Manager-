<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login2.aspx.vb" Inherits="Login2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  
     <meta charset="utf-8"/>
        <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
        <title>LogIn Page</title>

        <!-- CSS -->
        <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500"/>
        <link rel="stylesheet" href="logu/bootstrap/css/bootstrap.min.css"/>
        <link rel="stylesheet" href="logu/font-awesome/css/font-awesome.min.css"/>
		<link rel="stylesheet" href="logu/css/form-elements.css"/>
        <link rel="stylesheet" href="logu/css/style.css"/>

        <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
            <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
            <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
        <![endif]-->

        <!-- Favicon and touch icons -->
        <link rel="shortcut icon" href="logu/ico/favicon.png"/>
        <link rel="apple-touch-icon-precomposed" sizes="144x144" href="logu/ico/apple-touch-icon-144-precomposed.png"/>
        <link rel="apple-touch-icon-precomposed" sizes="114x114" href="logu/ico/apple-touch-icon-114-precomposed.png"/>
        <link rel="apple-touch-icon-precomposed" sizes="72x72" href="logu/ico/apple-touch-icon-72-precomposed.png"/>
        <link rel="apple-touch-icon-precomposed" href="logu/ico/apple-touch-icon-57-precomposed.png"/>

</head>
<body>
    <form id="form1" runat="server">
    <div>
       <!-- Top content -->
        <div class="top-content">
        	
            <div class="inner-bg">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-8 col-sm-offset-2 text">
                           <%-- <h1><strong>Bootstrap</strong> Login Form</h1>--%>
                           
                            <div class="description">
                            	<p>
	                            	    	</p>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 col-sm-offset-3 form-box">
                        	<div class="form-top">
                        		<div class="form-top-left">
                                     <img src=".\pictures\exam.png" id="logoin" alt=" Logo" />
                        			<h3>Login To Exam Manager</h3>
                            		<p>Enter your username and password to log on:</p>
                        		</div>
                        		<div class="form-top-right">
                        			<i class="fa fa-key"></i>
                        		</div>
                            </div>
                            <div class="form-bottom">
			                    <form role="form" action="" method="post" class="login-form">
			                    	<div class="form-group">
			                    		<label class="sr-only" for="form-username">Username</label>
			                        	<%--<input type="text" name="form-username"  id="form-username">--%>
                                        <asp:TextBox ID="txtName" runat="server" placeholder="Username..." class="form-username form-control" ValidationGroup="v7"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Please Enter User Name" ControlToValidate="txtName" ForeColor="Red" Display="Dynamic" ValidationGroup="v7"></asp:RequiredFieldValidator>
                                         </div>
                                    <asp:HiddenField id="hdnId" runat="server" />
			                        <div class="form-group">
			                        	<label class="sr-only" for="form-password">Password</label>
			                        	<%--<input type="password" name="form-password" placeholder="Password..." class="form-password form-control" id="form-password">--%>
			                       <asp:TextBox ID="txtPassword" runat="server" placeholder="Password..." TextMode="Password" class="form-username form-control" ValidationGroup="v7"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* Please Enter Password" ControlToValidate="txtPassword" ForeColor="Red" Display="Dynamic" ValidationGroup="v7"></asp:RequiredFieldValidator>
                                          </div>
			                       <%-- <button type="submit" class="btn">Sign in!</button>--%>
                                    <asp:Button ID="btnSubmit" runat="server" Text="Sign In" Class="btn btn-success col-lg-offset-4" ValidationGroup="v7" />
                                    <asp:LinkButton ID="lnkForgot" runat="server" Text="Forget Password"  Class="btn btn-success" ValidationGroup="v7"></asp:LinkButton>
                                </form>
		                    </div>
                        </div>
                    </div>
                   <%-- <div class="row">
                        <div class="col-sm-6 col-sm-offset-3 social-login">
                        	<h3>...or login with:</h3>
                        	<div class="social-login-buttons">
	                        	<a class="btn btn-link-1 btn-link-1-facebook" href="#">
	                        		<i class="fa fa-facebook"></i> Facebook
	                        	</a>
	                        	<a class="btn btn-link-1 btn-link-1-twitter" href="#">
	                        		<i class="fa fa-twitter"></i> Twitter
	                        	</a>
	                        	<a class="btn btn-link-1 btn-link-1-google-plus" href="#">
	                        		<i class="fa fa-google-plus"></i> Google Plus
	                        	</a>
                        	</div>
                        </div>
                    </div>--%>
                </div>
            </div>
            
        </div>


        <!-- Javascript -->
        <script src="logu/js/jquery-1.11.1.min.js"></script>
        <script src="logu/bootstrap/js/bootstrap.min.js"></script>
        <script src="logu/js/jquery.backstretch.min.js"></script>
        <script src="logu/js/scripts.js"></script>
        
        <!--[if lt IE 10]>
            <script src="logu/js/placeholder.js"></script>
        <![endif]-->

    </div>
    </form>
</body>
</html>
