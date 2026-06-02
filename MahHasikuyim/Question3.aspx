<%@ Page Title="שאלה 3" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Question3.aspx.cs" Inherits="MahHasikuyim.Question3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        // הצגת הרמז בצד הלקוח ללא רענון הדף המיותר
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

    <h1>מה הסיכוי ללדת תאומים ? (באחוזים)</h1>

    <img src="Images/twins.png.jpg" alt="תאומים" />

    <br /><br />

    <asp:TextBox ID="txtAnswer" runat="server" CssClass="answerBox" placeholder="הכנס אחוז..."></asp:TextBox>

    <asp:Button ID="btnHint" runat="server" Text="רמז" CssClass="blueBtn" OnClientClick="return showHintClient();" />

    <asp:Button ID="btnSubmit" runat="server" Text="להגיש" CssClass="greenBtn" OnClientClick="return validateInput();" OnClick="btnSubmit_Click" />

    <br /><br />

    <div id="hintDiv" style="display:none; font-size:18px; color: #555; font-style: italic;">
        התשובה לא חייבת להיות שלמה והיא גדולה מ-1%
    </div>

</asp:Content>
