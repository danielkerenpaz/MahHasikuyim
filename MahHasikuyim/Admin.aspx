<%@ Page Title="פאנל ניהול" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="MahHasikuyim.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .admin-box {
            background-color: white;
            padding: 40px;
            border-radius: 15px;
            display: inline-block;
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
            margin-top: 20px;
            width: 80%;
            max-width: 900px;
            text-align: right;
        }
        .search-row {
            margin-bottom: 20px;
            display: flex;
            gap: 10px;
            justify-content: flex-start;
            align-items: center;
        }
        /* עיצוב מקצועי לטבלת המשתמשים */
        .admin-grid {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
            font-size: 16px;
        }
        .admin-grid th {
            background-color: #2a2a35;
            color: white;
            padding: 12px;
            text-align: center;
        }
        .admin-grid td {
            padding: 10px;
            border: 1px solid #ddd;
            text-align: center;
            color: #333;
        }
        .admin-grid tr:nth-child(even) {
            background-color: #f9f9f9;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="admin-box">
        <h2>ניהול משתמשי המערכת 🛠️</h2>
        <p style="color: #666; font-size: 16px;">כאן תוכל לצפות בכל השחקנים הרשומים באתר ולבצע חיפושים.</p>
        <br />

        <div class="search-row">
            <asp:TextBox ID="txtSearch" runat="server" CssClass="answerBox" placeholder="חפש לפי אימייל או שם..."></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="חפש" CssClass="blueBtn" OnClick="btnSearch_Click" />
            <asp:Button ID="btnClear" runat="server" Text="הצג הכל" CssClass="yellowBtn" OnClick="btnClear_Click" />
        </div>

        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" CssClass="admin-grid">
            <Columns>
                <asp:BoundField DataField="UserEmail" HeaderText="כתובת אימייל" />
                <asp:BoundField DataField="FullName" HeaderText="שם מלא" />
            </Columns>
        </asp:GridView>

        <br />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Size="16px" Font-Bold="true"></asp:Label>
    </div>
</asp:Content>