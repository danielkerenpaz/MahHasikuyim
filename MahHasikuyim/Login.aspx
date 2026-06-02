<%@ Page Title="התחברות" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MahHasikuyim.Login" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .login-box {
            background-color: white;
            padding: 40px;
            border-radius: 15px;
            display: inline-block;
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
            margin-top: 20px;
            width: 350px;
        }
        .form-row {
            margin-bottom: 20px;
        }
    </style>
</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <script type="text/javascript">
        // בדיקת תקינות קלט בצד הלקוח
        function validateLogin() {
            var email = document.getElementById('<%= txtEmail.ClientID %>').value.trim();
            var password = document.getElementById('<%= txtPassword.ClientID %>').value.trim();

            if (email === "" || password === "") {
                alert("נא למלא את כל השדות כדי להתחבר!");
                return false;
            }

            var emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
            if (!emailPattern.test(email)) {
                alert("נא להזין כתובת אימייל במבנה תקין!");
                return false;
            }

            return true;
        }
    </script>
 
    <div class="login-box">
        <h2>התחברות למערכת</h2>
        <br />
        
        <div class="form-row">
            <asp:TextBox ID="txtEmail" runat="server" CssClass="answerBox" placeholder="הכנס אימייל..."></asp:TextBox>
        </div>
        
        <div class="form-row">
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="answerBox" placeholder="הכנס סיסמה..."></asp:TextBox>
        </div>
        
        <div class="form-row">
            <asp:Button ID="btnLogin" runat="server" Text="כניסה למשחק" CssClass="greenBtn" OnClientClick="return validateLogin();" OnClick="btnLogin_Click" />
        </div>
 
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Size="18px" Font-Bold="true"></asp:Label>
        
        <p style="margin-top: 20px; font-size: 16px;">
            עדיין לא רשומים? <a href="Register.aspx" style="color: royalblue; font-weight: bold;">לחצו כאן להרשמה</a>
        </p>
    </div>
</asp:Content>