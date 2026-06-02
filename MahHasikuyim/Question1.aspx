<%@ Page Title="שאלה 1" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Question1.aspx.cs" Inherits="MahHasikuyim.Question1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        // הצגת הרמז בצד הלקוח ללא רענון הדף (דרישת חובה בפרויקט!)
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
                alert("נא להזין מספרים בלבד! (ניתן להשתמש בנקודה עשרונית)");
                return false;
            }
            
            var num = parseFloat(txt);
            if (num < 0 || num > 100) {
                alert("האחוז חייב להיות בין 0 ל-100!");
                return false;
            }
            
            return true; // הכל תקין, מעביר לשרת
        }
    </script>

    <h1>מה הסיכוי שיפגע בך ברק ? (באחוזים)</h1>

    <img src="Images/lightning.png.jpg" alt="ברק" />

    <br /><br />

    <asp:TextBox ID="txtAnswer" runat="server" CssClass="answerBox" placeholder="הכנס אחוז..."></asp:TextBox>

    <asp:Button ID="btnHint" runat="server" Text="רמז" CssClass="blueBtn" OnClientClick="return showHintClient();" />

    <asp:Button ID="btnSubmit" runat="server" Text="להגיש" CssClass="greenBtn" OnClientClick="return validateInput();" OnClick="btnSubmit_Click" />

    <br /><br />

    <div id="hintDiv" style="display:none; font-size:18px; color: #555; font-style: italic;">
        התשובה לא חייבת להיות שלמה והיא לא בהכרח גדולה מ-1%
    </div>

</asp:Content>