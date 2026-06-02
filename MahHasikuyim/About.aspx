<%@ Page Title="אודות" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="MahHasikuyim.About" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .about-card {
            background-color: white;
            padding: 40px;
            border-radius: 20px;
            display: inline-block;
            text-align: right;
            width: 55%;
            min-width: 340px;
            box-shadow: 0 10px 25px rgba(0,0,0,0.08);
            margin-top: 20px;
        }
        .info-text {
            font-size: 19px;
            line-height: 1.8;
            color: #334155;
        }
        .game-title {
            font-weight: bold; 
            color: #0284c7;
        }
        .student-details {
            margin-bottom: 25px;
            border-bottom: 1px solid #e2e8f0;
            padding-bottom: 20px;
        }
        .student-details p {
            margin: 5px 0;
            font-size: 19px;
            color: #1e293b;
        }
        .highlight-text {
            color: #0284c7;
            font-weight: bold;
        }
    </style>
</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <h1>אודות האתר</h1>
    
    <div class="about-card">
        <div style="text-align: center; margin-bottom: 30px;">
            <svg width="240" height="240" viewBox="0 0 200 200" style="margin: 0 auto; display: block;">
                <ellipse cx="100" cy="175" rx="65" ry="10" fill="rgba(15, 23, 42, 0.08)" />
                
                <polygon points="100,25 165,58 100,91 35,58" fill="#fde047" stroke="#1e293b" stroke-width="5" stroke-linejoin="round" />
                <circle cx="100" cy="58" r="4.5" fill="#1e293b" />
                <circle cx="75" cy="46" r="4.5" fill="#1e293b" />
                <circle cx="125" cy="70" r="4.5" fill="#1e293b" />
                
                <polygon points="35,58 100,91 100,156 35,123" fill="#ec4899" stroke="#1e293b" stroke-width="5" stroke-linejoin="round" />
                <circle cx="60" cy="85" r="4.5" fill="#1e293b" />
                <circle cx="75" cy="115" r="4.5" fill="#1e293b" />
                
                <polygon points="100,91 165,58 165,123 100,156" fill="#0ea5e9" stroke="#1e293b" stroke-width="5" stroke-linejoin="round" />
                <circle cx="140" cy="85" r="4.5" fill="#1e293b" />
                <circle cx="125" cy="115" r="4.5" fill="#1e293b" />
                <circle cx="140" cy="115" r="4.5" fill="#1e293b" />
                <circle cx="125" cy="85" r="4.5" fill="#1e293b" />
                
                <g transform="translate(100, 142)">
                    <rect x="-75" y="-18" width="150" height="38" rx="10" fill="#cbd5e1" />
                    <rect x="-75" y="-22" width="150" height="38" rx="10" fill="#ffffff" stroke="#1e293b" stroke-width="4" />
                    <text x="0" y="4" fill="#1e293b" font-size="18" font-weight="bold" text-anchor="middle" font-family="Segoe UI, Arial, sans-serif">מה הסיכויים?</text>
                </g>
            </svg>
        </div>

        <div class="student-details">
            <p><strong>שם התלמיד:</strong> <span class="highlight-text">דניאל קרן פז</span></p>
            <p><strong>כיתה:</strong> <span class="highlight-text">י"א 8</span></p>
        </div>
        
        <p class="info-text">
            <strong>על הפרויקט:</strong><br />
            ברוכים הבאים לאתר <span class="game-title">"מה הסיכויים!"</span> – משחק טריוויה אינטראקטיבי, קצבי ומאתגר, הבוחן את האינטואיציה והחשיבה ההסתברותית שלכם במצבים האמיתיים של החיים.
            <br /><br />
            במהלך המשחק, תתמודדו עם שאלות מרתקות ותצטרכו **לנחש מהו האחוז המדויק או הסיכוי הסטטיסטי להתרחשותם של מקרים נדירים**, תופעות טבע יוצאות דופן ואירועים משעשעים מרחבי העולם. 
            <br /><br />
            זהירות, המשחק לא עושה הנחות! באתר מוטמע אלגוריתם חישוב קשוח ומתוחכם המודד את סטיית הניחוש שלכם (חוק ה-פי 2). פגיעה קרובה למטרה תזניק אתכם לראש טבלת המובילים, אך פספוס קטן עלול לאפס לכם את הניקוד לחלוטין!
        </p>
    </div>
 
</asp:Content>