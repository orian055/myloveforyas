var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

                
app.UseStaticFiles(new Microsoft.AspNetCore.Builder.StaticFileOptions
{
    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(app.Environment.ContentRootPath),
    RequestPath = ""
});




app.MapGet("/Yas", () =>
{
    return Results.Content("""
    <html>
    <head>
        <style>
            * {
                box-sizing: border-box;
            }
            body {
                min-height: 100vh;
                margin: 0;
                padding: 0;
                font-family: 'Inter', 'Segoe UI', sans-serif;
                color: #f7e7ff;
                background: radial-gradient(circle at 20% 15%, rgba(255, 145, 196, 0.18), transparent 20%),
                            radial-gradient(circle at 85% 20%, rgba(255, 95, 145, 0.24), transparent 18%),
                            linear-gradient(135deg, #30042d 0%, #461362 45%, #a11d7d 100%);
                overflow-x: hidden;
            }
            body::before {
                content: '';
                position: fixed;
                inset: 0;
                background-image: radial-gradient(circle at 15% 18%, rgba(255,255,255,0.12) 0, transparent 36%),
                                  radial-gradient(circle at 70% 10%, rgba(255,110,190,0.18) 0, transparent 28%);
                pointer-events: none;
            }
            .menu {
                position: fixed;
                top: 0;
                left: 0;
                height: 100vh;
                width: 280px;
                padding: 26px 22px;
                display: flex;
                flex-direction: column;
                gap: 20px;
                background: rgba(28, 8, 34, 0.88);
                border-right: 1px solid rgba(255,255,255,0.08);
                box-shadow: 12px 0 40px rgba(0,0,0,0.35);
                backdrop-filter: blur(18px);
            }
            .menu .logo {
                width: 80px;
                height: 80px;
                border-radius: 24px;
                background: linear-gradient(135deg, rgba(132, 22, 91, 0.92), rgba(212, 60, 147, 0.9));
                box-shadow: 0 18px 40px rgba(207, 53, 135, 0.34);
                margin-bottom: 12px;
                display: flex;
                align-items: center;
                justify-content: center;
                overflow: hidden;
                border: 1px solid rgba(255,255,255,0.15);
            }
            .menu .logo img {
                width: 100%;
                height: 100%;
                object-fit: cover;
                background: transparent;
            }
            .menu h2 {
                margin: 0;
                color: #ff8bc1;
                font-size: 1.08rem;
                letter-spacing: 0.14em;
                text-transform: uppercase;
            }
            .menu small {
                color: #e4c9eb;
                line-height: 1.5;
                font-size: 0.95rem;
            }
            .menu button {
                width: 100%;
                padding: 14px 16px;
                border-radius: 999px;
                border: 1px solid rgba(255,255,255,0.12);
                background: rgba(255, 255, 255, 0.08);
                color: #ffd6ff;
                font-weight: 600;
                cursor: pointer;
                transition: transform 0.25s ease, box-shadow 0.25s ease, background 0.25s ease, border-color 0.25s ease;
                box-shadow: 0 10px 22px rgba(225, 50, 135, 0.16);
            }
            .menu button:hover {
                transform: translateY(-2px);
                background: rgba(255, 255, 255, 0.14);
                border-color: rgba(255,255,255,0.18);
            }
            .content {
                margin-left: 320px;
                min-height: 100vh;
                padding: 60px 40px;
                display: flex;
                align-items: center;
                justify-content: center;
            }
            .hero-card {
                width: min(900px, 100%);
                padding: 52px 56px;
                border-radius: 40px;
                background: rgba(30, 9, 43, 0.76);
                border: 1px solid rgba(255,255,255,0.12);
                box-shadow: 0 30px 80px rgba(0, 0, 0, 0.38);
                backdrop-filter: blur(22px);
                text-align: center;
                position: relative;
                overflow: hidden;
            }
            .hero-card::before {
                content: '';
                position: absolute;
                inset: 0;
                border-radius: 40px;
                background: linear-gradient(135deg, rgba(255, 115, 185, 0.12), transparent 55%);
                pointer-events: none;
            }
            .hero-card > * {
                position: relative;
            }
            .hero-title {
                margin: 0;
                font-size: clamp(3.4rem, 5vw, 5.6rem);
                letter-spacing: -0.05em;
                line-height: 0.92;
                color: #ffd0f8;
                text-shadow: 0 20px 55px rgba(116, 15, 72, 0.4);
            }
            .hero-title span {
                display: inline-block;
                animation: wave 1.4s ease-in-out infinite;
                animation-delay: calc(var(--i) * 0.08s);
            }
            .hero-title span.space {
                animation: none;
            }
            .hero-text {
                margin: 28px auto 0;
                max-width: 760px;
                font-size: 1.2rem;
                line-height: 1.8;
                color: rgba(255,210,245,0.93);
            }
            .hero-text strong {
                color: #ffe1ff;
            }
            .hero-badge {
                display: inline-flex;
                margin-top: 18px;
                padding: 12px 20px;
                border-radius: 999px;
                background: rgba(255, 255, 255, 0.08);
                color: #ffb2e7;
                font-weight: 700;
                letter-spacing: 0.04em;
            }
            .hero-link {
                margin-top: 14px;
                color: #ffdce8;
                font-size: 0.98rem;
            }
            .hero-link a {
                color: #ffe4ff;
                text-decoration: none;
                border-bottom: 1px dashed rgba(255,255,255,0.35);
            }
            .hero-link a:hover {
                color: #ffffff;
                border-bottom-color: rgba(255,255,255,0.7);
            }
            @keyframes wave {
                0%, 100% {
                    transform: translateY(0);
                }
                50% {
                    transform: translateY(-18px);
                }
            }
            @media (max-width: 900px) {
                .menu {
                    position: relative;
                    width: 100%;
                    height: auto;
                    border-right: none;
                    box-shadow: none;
                    backdrop-filter: none;
                }
                .content {
                    margin-left: 0;
                    padding: 30px 20px 50px;
                }
            }
        </style>
    </head>
    <body>
        <div class="menu">
            <div class="logo">
                <img id="menu-logo" src="/yasmin-Photoroom.png" alt="Yasmin logo">
            </div>
            <h2>Menu</h2>
            <small>Some Cool stuff!</small>
            <button type="button" onclick="location.href='/reasons'">Reasons I Love You</button>
            <button type="button" onclick="location.href='/relationship'">Relationship Counter</button>
            <button type="button" onclick="location.href='/fun'">Just For Fun</button>
            <button type="button" onclick="location.href='/more'">I Love You More!</button>
        </div>
        <div class="content">
            <div class="hero-card">
                <h1 class="hero-title" id="wave-title">I Love You Yasmin</h1>
                <div class="hero-badge">Made By Orian</div>
                <p class="hero-text">You Are The Best! </p>
            </div>
        </div>
        <script>
            const title = document.getElementById('wave-title');
            const text = title.textContent.trim();
            title.innerHTML = [...text].map((char, idx) => {
                if (char === ' ') {
                    return `<span class="space" style="--i:${idx}">&nbsp;</span>`;
                }
                return `<span style="--i:${idx}">${char}</span>`;
            }).join('');
        </script>
    </body>
    </html>
    """, "text/html");
});

app.MapReasonsPage();

app.MapRelationshipPage();

app.MapFunPage();

app.MapMorePage();

app.MapNguPage();

app.MapBlehhPage();

app.MapHelloPage();

app.MapNoIlymPage();
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Run($"http://0.0.0.0:{port}");

