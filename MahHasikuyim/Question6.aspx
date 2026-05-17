<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Question6.aspx.cs" Inherits="MahHasikuyim.Question6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h1>מה הסיכוי להיוולד בעל מטר 80 במדינת ישראל ? (באחוזים)</h1>

<img src="Images/height.png.jpg" />

<br /><br />

<asp:TextBox ID="txtAnswer" runat="server" CssClass="answerBox"></asp:TextBox>

<asp:Button ID="btnHint" runat="server" Text="רמז" CssClass="blueBtn" OnClick="btnHint_Click" />

<asp:Button ID="btnSubmit" runat="server" Text="להגיש" CssClass="greenBtn" OnClick="btnSubmit_Click" />

<br /><br />

<asp:Label ID="lblHint" runat="server"></asp:Label>

</asp:Content>