<%@ Page Title="הרשמה" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MahHasikuyim.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        function validateRegister() {
            var firstName = document.getElementById('<%= txtFirstName.ClientID %>').value.trim();
            var lastName = document.getElementById('<%= txtLastName.ClientID %>').value.trim();
            var email = document.getElementById('<%= txtEmail.ClientID %>').value.trim();
            var password = document.getElementById('<%= txtPassword.ClientID %>').value.trim();

            // בדיקת שדות ריקים
            if (firstName === "" || lastName === "" || email === "" || password === "") {
                alert("נא למלא את כל השדות!");
                return false;
            }

            // בדיקת תקינות מבנה אימייל
            var emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
            if (!emailPattern.test(email)) {
                alert("נא להזין כתובת אימייל תקינה!");
                return false;
            }

            // בדיקת אורך סיסמה מינימלי
            if (password.length < 4) {
                alert("הסיסמה חייבת להכיל לפחות 4 תווים!");
                return false;
            }

            return true;
        }
    </script>

    <div style="background-color: white; padding: 40px; display: inline-block; border-radius: 15px; box-shadow: 0 4px 8px rgba(0,0,0,0.1); margin-top: 20px; width: 350px;">
        
        <h1>הרשמה לאתר</h1>
        <br />

        <asp:TextBox ID="txtFirstName" runat="server" CssClass="answerBox" placeholder="שם פרטי"></asp:TextBox>
        <br /><br />

        <asp:TextBox ID="txtLastName" runat="server" CssClass="answerBox" placeholder="שם משפחה"></asp:TextBox>
        <br /><br />

        <asp:TextBox ID="txtEmail" runat="server" CssClass="answerBox" placeholder="אימייל"></asp:TextBox>
        <br /><br />

        <asp:TextBox ID="txtPassword" runat="server" CssClass="answerBox" TextMode="Password" placeholder="סיסמה"></asp:TextBox>
        <br /><br />

        <asp:Button ID="btnSubmit" runat="server" Text="להרשם ולהתחיל" CssClass="greenBtn" OnClientClick="return validateRegister();" OnClick="btnSubmit_Click" />
        
        <br /><br />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>

    </div>

</asp:Content>