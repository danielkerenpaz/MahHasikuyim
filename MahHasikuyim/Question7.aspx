<%@ Page Title="שאלה 7" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Question7.aspx.cs" Inherits="MahHasikuyim.Question7" %>

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

    <h1>מה הסיכוי שתזכה בהגרלה שבה יש 1000 משתתפים ושלושה זוכים ? (באחוזים)</h1>

    <img src="Images/winners.png.jpg" alt="זוכים" />

    <br /><br />

    <asp:TextBox ID="txtAnswer" runat="server" CssClass="answerBox" placeholder="הכנס אחוז..."></asp:TextBox>

    <asp:Button ID="btnHint" runat="server" Text="רמז" CssClass="blueBtn" OnClientClick="return showHintClient();" />

    <asp:Button ID="btnSubmit" runat="server" Text="להגיש" CssClass="greenBtn" OnClientClick="return validateInput();" OnClick="btnSubmit_Click" />

    <br /><br />

    <div id="hintDiv" style="display:none; font-size:18px; color: #555; font-style: italic;">
        רמז: התשובה לא חייבת להיות שלמה והיא גדולה מ-0.1%
    </div>

</asp:Content>