<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Final.aspx.cs" Inherits="MahHasikuyim.Final" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h1>טבלת תוצאות</h1>

<asp:GridView ID="gvResults" runat="server" AutoGenerateColumns="false" Width="80%" HorizontalAlign="Center">

    <Columns>

        <asp:BoundField DataField="Place" HeaderText="מיקום" />
        <asp:BoundField DataField="Score" HeaderText="ניקוד" />
        <asp:BoundField DataField="Email" HeaderText="אימייל" />
        <asp:BoundField DataField="Name" HeaderText="שם מלא" />

    </Columns>

</asp:GridView>

<br /><br />

<h1 style="color:black; font-size:40px;">
    מקווה שנהנתם מהאתר שלי 😉
</h1>

</asp:Content>