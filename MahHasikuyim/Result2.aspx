<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Result2.aspx.cs" Inherits="MahHasikuyim.Result2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="result">
    האחוז הנכון הוא:
    <br />

    <asp:Label ID="lblAnswer" runat="server"></asp:Label>%
</div>

<br /><br />

<h1>
    קיבלת:
    <asp:Label ID="lblScore" runat="server"></asp:Label>
    נקודות מתוך 100
</h1>

<br /><br />

<asp:Button ID="btnNext" runat="server" Text="← עמוד הבא" CssClass="yellowBtn" OnClick="btnNext_Click" />

</asp:Content>