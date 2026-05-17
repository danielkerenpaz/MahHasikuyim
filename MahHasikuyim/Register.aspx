
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MahHasikuyim.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>הרשמה לאתר</h1>

    <asp:TextBox ID="txtFirstName" runat="server" CssClass="answerBox" placeholder="שם פרטי"></asp:TextBox>
    <br /><br />

    <asp:TextBox ID="txtLastName" runat="server" CssClass="answerBox" placeholder="שם משפחה"></asp:TextBox>
    <br /><br />

    <asp:TextBox ID="txtEmail" runat="server" CssClass="answerBox" placeholder="אימייל"></asp:TextBox>
    <br /><br />

    <asp:TextBox ID="txtPassword" runat="server" CssClass="answerBox" TextMode="Password" placeholder="סיסמה"></asp:TextBox>
    <br /><br />

    <asp:Button ID="btnSubmit" runat="server" Text="להגיש" CssClass="greenBtn" OnClick="btnSubmit_Click" />

</asp:Content>
