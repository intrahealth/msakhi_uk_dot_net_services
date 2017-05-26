<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head id="Head1" runat="server">
    <title>Log In</title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/textinput.css" rel="stylesheet" type="text/css" />


    <script type="text/javascript">
        function showloginmsg(msg) {
            alert(msg);
            return false;
        }
    </script>
</head>

<body>
 
    <div class="loginHeader" style="border: Solid 1px #9bc77d;background-color:#130202; box-shadow: 0px 2px 4px #ddd;margin-top: 0px";>
    <td align="left">
        <img src="images/logo.png" height="25%"  alt="logo" style="width: 24%;margin-left: 0.56%;"/>
        </td>
     <td align="right">
        <img src="images/msakhi.png" height="25%"  alt="logo" style="width: 11%;margin-left: 51.56%;"/>
        </td>
    </div>
   
    <form id="Form1" runat="server">
   

    <div  style="height: auto;margin-top: 14%;text-align:inherit;margin-right: 2%;width: 90%;box-shadow: 0px 0px 0px #ddd;float: right;"  >
        <div style="height: auto; width: 30%; float: inherit; box-shadow: 0px 2px 4px #ddd">
            <asp:validationsummary id="LoginUserValidationSummary" runat="server" cssclass="failureNotification"
                validationgroup="LoginUserValidationGroup" showmessagebox="true" showsummary="false" />
            <div style="text-align: left; box-shadow: 0px 2px 4px #ddd">
                <div style="border: Solid 1px #9bc77d; background-color: #f3ae1b; height: 70px; color: White;
                    text-align: center;">
                    <h2 style="color: White">
                        LOGIN
                    </h2>
                    <p>
                     Please enter your username and password.
                    </p>
                </div>
                <div style="border-top: Solid 1px #2A80B9; border-right: Solid 1px #9bc77d; border-left: Solid 1px #9bc77d;
                    padding: 10px; color: black;">
                    <legend>Account Information</legend>
                
                    <p>
                    <img src="Images/User.png" style="width: 24px; height: 24px;" />
                    <asp:label id="lbluser" runat="server" associatedcontrolid="txt_uid">Username:</asp:label>
                    <asp:requiredfieldvalidator id="UserNameRequired" display="Dynamic" runat="server"
                    controltovalidate="txt_uid" cssclass="failureNotification" errormessage="User Name is required."
                    forecolor="Red" tooltip="User Name is required." validationgroup="LoginUserValidationGroup">*</asp:requiredfieldvalidator>
                    <asp:textbox id="txt_uid" runat="server" cssclass="textbox"></asp:textbox>
                    </p>
                    <p>
                    <img src="Images/Lock-icon.png" style="width: 24px; height: 24px;" />
                    <asp:label id="lblpassword" runat="server" associatedcontrolid="txt_pwd">Password:</asp:label>
                    <asp:requiredfieldvalidator id="PasswordRequired" runat="server" controltovalidate="txt_pwd"
                    cssclass="failureNotification" display="Dynamic" errormessage="Password is required."
                    forecolor="Red" tooltip="Password is required." validationgroup="LoginUserValidationGroup">*</asp:requiredfieldvalidator>
                    <asp:textbox id="txt_pwd" runat="server" cssclass="password" textmode="Password"></asp:textbox>
                    </p>
                </div>
                <div style="border: Solid 1px #9bc77d; color: black; padding-top: 10px;">
                  
                    <p style="text-align: center; padding-top: 12px;">
                        <asp:button id="LoginButton" runat="server" commandname="Login" text="Log In" cssclass="buttono"
                            validationgroup="LoginUserValidationGroup" onclick="tbn_login_Click" width="90%"
                            font-bold="true" />
                    </p>
                    <p style="text-align: right;">
                        <asp:label id="lbl_msg" runat="server" forecolor="White"></asp:label>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="Masterfooter">
        <div class="footer_sec1">
            <div class="copy_rightnew">
                Copyright © 2016</div>
        </div>
        <div style="width: 40%; float: right; font-size: 10px; text-align: right; margin-right: 3px;">
            Developed by : Microware Computing & Consulting Pvt. Ltd.
        </div>
    </div>
    </form>
</body>
</html>
