<%@ Page Title="שאלה 4" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Question4.aspx.cs" Inherits="MahHasikuyim.Question4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        // הצגת הרמז בצד הלקוח ללא רענון הדף
        function showHintClient() {
            document.getElementById("hintDiv").style.display = "block";
            return false; // מונע שליחת הטופס לשרת
        }

        // בדיקת תקינות הקלט בקליינט למניעת שגיאות שרת
        function validateInput() {
            var txt = document.getElementById('<%= txtAnswer.ClientID %>').value.trim();
            
            if (txt === "") {
                alert("נא להזין תשובה לפני ההגשה!");
                return false;
            }
            
            if (isNaN(txt)) {
                alert("נא להזין מספרים בלבד! (ניתן להשתמש בנקודה עשרונית)");
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

    <h1>מה הסיכוי לזכות בלוטו ? (באחוזים)</h1>

    <img src="Images/lotto.png.jpg" alt="לוטו" />

    <br /><br />

    <asp:TextBox ID="txtAnswer" runat="server" CssClass="answerBox" placeholder="הכנס אחוז..."></asp:TextBox>

    <asp:Button ID="btnHint" runat="server" Text="רמז" CssClass="blueBtn" OnClientClick="return showHintClient();" />

    <asp:Button ID="btnSubmit" runat="server" Text="להגיש" CssClass="greenBtn" OnClientClick="return validateInput();" OnClick="btnSubmit_Click" />

    <br /><br />

    <div id="hintDiv" style="display:none; font-size:18px; color: #555; font-style: italic;">
        רמז: הסיכוי הוא אפסי, מספר קטנטן בצורה מטורפת שהרבה יותר קטן מ-1%!
    </div>

</asp:Content>