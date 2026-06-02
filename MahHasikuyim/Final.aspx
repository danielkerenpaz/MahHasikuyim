<%@ Page Title="טבלת תוצאות" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Final.aspx.cs" Inherits="MahHasikuyim.Final" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="background-color: white; padding: 30px; display: inline-block; border-radius: 15px; box-shadow: 0 4px 8px rgba(0,0,0,0.1); margin-top: 20px; width: 85%; min-width: 320px;">
        
        <h1>🏆 טבלת המובילים 🏆</h1>
        <br />
        
        <h2 style="color: #2e7d32; font-size: 26px;">
            כל הכבוד! סיימת את המשחק עם ניקוד כולל של: 
            <asp:Label ID="lblTotalScore" runat="server" Font-Bold="true"></asp:Label> נקודות!
        </h2>
        
        <br /><br />

        <asp:GridView ID="gvResults" runat="server" AutoGenerateColumns="false" Width="90%" HorizontalAlign="Center" CellPadding="10" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
            <Columns>
                <asp:BoundField DataField="Place" HeaderText="מיקום" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" />
                <asp:BoundField DataField="Score" HeaderText="ניקוד" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="Email" HeaderText="אימייל" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="Name" HeaderText="שם מלא" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            </Columns>
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <RowStyle ForeColor="#000066" />
        </asp:GridView>

        <br /><br />
        
        <h1 style="color:black; font-size:35px;">
            מקווה שנהניתם מהאתר שלי 😉
        </h1>
        
    </div>

</asp:Content>