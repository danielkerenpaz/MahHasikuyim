<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Question1.aspx.cs" Inherits="MahHasikuyim.Question1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h1>מה הסיכוי שיפגע בך ברק ? (באחוזים)</h1>

<img src="Images/lightning.png" />

<br /><br />

<asp:TextBox ID="txtAnswer" runat="server" CssClass="answerBox"></asp:TextBox>

<asp:Button ID="btnHint" runat="server" Text="רמז" CssClass="blueBtn" OnClick="btnHint_Click" />

<asp:Button ID="btnSubmit" runat="server" Text="להגיש" CssClass="greenBtn" OnClick="btnSubmit_Click" />

<br /><br />

<asp:Label ID="lblHint" runat="server"></asp:Label>

</asp:Content>
