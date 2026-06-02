<%@ Page Title="שאלה 2" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Question2.aspx.cs" Inherits="MahHasikuyim.Question2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        // הצגת הרמז בצד הלקוח ללא רענון הדף
        function showHintClient() {
            document.getElementById("hintDiv").style.display = "block";
            return false; // מונע שליחת הטופס לשרת
        }

        // בדיקת תקינות הקלט בקליינט למניעת קריסת השרת
        function validateInput() {
            var txt = document.getElementById('<%= txtAnswer.ClientID %>').value.trim();
            
            if (txt === "") {
                alert("נא להזין תשובה לפני ההגשה!");
                return false;
            }
            
            if (isNaN(txt)) {
                alert("נא להזין מספרים בלבד!");
                return false;
            }
            
            var num = parseFloat(txt);
            if (num < 0 || num > 100) {
                alert("האחוז חייב להיות בין 0 ל-100!");
                return false;
            }
            
            return true; // הכל תקין
        }
    </script>

    <h1>מה הסיכוי שתשרוד התרסקות מטוס ? (באחוזים)</h1>

    <img src="Images/plane.png.jpg" alt="מטוס" />

    <br /><br />

    <asp:TextBox ID="txtAnswer" runat="server" CssClass="answerBox" placeholder="הכנס אחוז..."></asp:TextBox>

    <asp:Button ID="btnHint" runat="server" Text="רמז" CssClass="blueBtn" OnClientClick="return showHintClient();" />

    <asp:Button ID="btnSubmit" runat="server" Text="להגיש" CssClass="greenBtn" OnClientClick="return validateInput();" OnClick="btnSubmit_Click" />

    <br /><br />

    <div id="hintDiv" style="display:none; font-size:18px; color: #555; font-style: italic;">
        התשובה היא גדולה מ-1%
    </div>

</asp:Content>