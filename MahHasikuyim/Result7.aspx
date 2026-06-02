<%@ Page Title="תוצאה 7" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Result7.aspx.cs" Inherits="MahHasikuyim.Result7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="background-color: white; padding: 30px; display: inline-block; border-radius: 15px; box-shadow: 0 4px 8px rgba(0,0,0,0.1); margin-top: 20px;">
        <div class="result">
            האחוז הנכון הוא:
            <br />
            <asp:Label ID="lblAnswer" runat="server"></asp:Label>%
        </div>

        <br />

        <h2>
            קיבלת:
            <asp:Label ID="lblScore" runat="server" ForeColor="Green"></asp:Label>
            נקודות מתוך 100
        </h2>

        <br /><br />

        <asp:Button ID="btnNext" runat="server" Text="← לסיום המשחק" CssClass="yellowBtn" OnClick="btnNext_Click" />
    </div>

</asp:Content>