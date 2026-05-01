var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext ctx) =>
{
    ctx.Response.Redirect("/yas");
    return Task.CompletedTask;
});

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
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link href="https://fonts.googleapis.com/css2?family=Playfair+Display:ital,wght@0,400;0,700;0,900;1,400;1,700&family=Cormorant+Garamond:ital,wght@0,300;0,400;0,600;1,300;1,400&family=Dancing+Script:wght@600;700&display=swap" rel="stylesheet">
        <style>
            :root {
                --rose: #e8406a; --rose-light: #ff7096; --rose-dark: #9e1a3a;
                --gold: #d4a843; --gold-light: #f0c96a;
                --cream: #fff5f7; --deep: #1a0610; --wine: #4a0e20; --soft-pink: #f9c4d4;
            }
            * { box-sizing: border-box; margin: 0; padding: 0; }
            body {
                min-height: 100vh;
                font-family: 'Cormorant Garamond', serif;
                background: var(--deep);
                overflow-x: hidden;
            }
            .bg-canvas {
                position: fixed; inset: 0;
                background:
                    radial-gradient(ellipse at 10% 20%, rgba(158,26,58,0.35) 0%, transparent 50%),
                    radial-gradient(ellipse at 90% 80%, rgba(74,14,32,0.5) 0%, transparent 45%),
                    linear-gradient(160deg, #1a0610 0%, #2d0a1a 40%, #1a0610 100%);
                z-index: 0;
            }
            .petal {
                position: fixed; pointer-events: none;
                animation: petalFall linear infinite; z-index: 1; opacity: 0.55;
            }
            @keyframes petalFall {
                0%   { transform: translateY(-60px) rotate(0deg); opacity: 0.6; }
                50%  { transform: translateY(50vh) rotate(180deg) translateX(30px); opacity: 0.4; }
                100% { transform: translateY(110vh) rotate(360deg) translateX(-15px); opacity: 0; }
            }

            /* ── LAYOUT ── */
            .layout { display: flex; min-height: 100vh; position: relative; z-index: 2; }

            /* ── SIDEBAR ── */
            .sidebar {
                width: 280px; flex-shrink: 0;
                display: flex; flex-direction: column;
                padding: 36px 24px;
                background: linear-gradient(180deg, rgba(26,6,16,0.96) 0%, rgba(74,14,32,0.88) 100%);
                border-right: 1px solid rgba(212,168,67,0.18);
                backdrop-filter: blur(20px);
                position: sticky; top: 0; height: 100vh; overflow-y: auto;
            }
            .logo-wrap { display: flex; flex-direction: column; align-items: center; margin-bottom: 24px; }
            .logo-frame {
                width: 86px; height: 86px; border-radius: 50%;
                border: 2px solid rgba(212,168,67,0.5); padding: 3px;
                box-shadow: 0 0 24px rgba(212,168,67,0.1), 0 8px 32px rgba(0,0,0,0.4);
            }
            .logo-frame img { width: 100%; height: 100%; border-radius: 50%; object-fit: cover; display: block; }
            .logo-name {
                font-family: 'Dancing Script', cursive; font-size: 1.4rem;
                color: var(--gold-light); margin-top: 10px; letter-spacing: 0.05em;
                text-shadow: 0 0 16px rgba(212,168,67,0.4); text-align: center;
            }
            .divider {
                width: 55%; height: 1px;
                background: linear-gradient(90deg, transparent, rgba(212,168,67,0.4), transparent);
                margin: 4px auto 20px;
            }
            .nav-label {
                font-size: 0.7rem; letter-spacing: 0.22em; text-transform: uppercase;
                color: rgba(212,168,67,0.5); margin-bottom: 10px; text-align: center;
            }
            .nav-btn {
                width: 100%; padding: 13px 18px; margin-bottom: 8px;
                border-radius: 3px; border: 1px solid rgba(212,168,67,0.13);
                background: rgba(255,255,255,0.03); color: var(--soft-pink);
                font-family: 'Cormorant Garamond', serif; font-size: 1.05rem; font-style: italic;
                cursor: pointer; transition: all 0.3s ease; text-align: left; letter-spacing: 0.02em;
                position: relative; overflow: hidden;
            }
            .nav-btn::before {
                content: ''; position: absolute; left: 0; top: 0; bottom: 0;
                width: 2px; background: linear-gradient(180deg, var(--gold), var(--rose));
                transform: scaleY(0); transition: transform 0.3s ease;
            }
            .nav-btn:hover { border-color: rgba(212,168,67,0.35); color: var(--cream); padding-left: 22px; }
            .nav-btn:hover::before { transform: scaleY(1); }

            /* daily note in sidebar */
            .daily-note {
                margin-top: auto; padding: 14px 16px;
                border: 1px solid rgba(212,168,67,0.12); border-radius: 3px;
                background: rgba(255,255,255,0.02);
            }
            .daily-note-label {
                font-size: 0.65rem; letter-spacing: 0.18em; text-transform: uppercase;
                color: rgba(212,168,67,0.45); margin-bottom: 8px; display: block;
            }
            .daily-note-text {
                font-family: 'Dancing Script', cursive; font-size: 1rem;
                color: rgba(249,196,212,0.8); line-height: 1.5;
            }

            /* ── MAIN ── */
            .main {
                flex: 1; display: flex; align-items: center; justify-content: center;
                padding: 60px 64px; min-height: 100vh;
            }
            .hero { max-width: 680px; width: 100%; }
            .hero-eyebrow {
                font-family: 'Dancing Script', cursive; font-size: 1.35rem;
                color: var(--gold-light); letter-spacing: 0.08em; margin-bottom: 14px;
                opacity: 0; animation: slideUp 0.8s ease 0.2s forwards;
            }
            .hero-title {
                font-family: 'Playfair Display', serif;
                font-size: clamp(3rem, 5.5vw, 6rem); font-weight: 900;
                line-height: 1; letter-spacing: -0.02em; color: var(--cream);
                opacity: 0; animation: slideUp 0.9s ease 0.4s forwards;
            }
            .hero-title em {
                font-style: italic; color: var(--rose-light); display: block;
                font-size: 0.62em; font-weight: 400; letter-spacing: 0.04em;
                text-shadow: 0 0 40px rgba(255,112,150,0.45);
            }
            .title-underline {
                width: 0; height: 2px;
                background: linear-gradient(90deg, var(--rose), var(--gold));
                margin-bottom: 28px; animation: expandLine 1s ease 1s forwards; border-radius: 2px;
            }
            @keyframes expandLine { to { width: 180px; } }
            .hero-body {
                font-size: 1.2rem; line-height: 1.9; color: rgba(255,220,230,0.85);
                font-weight: 300; max-width: 520px;
                opacity: 0; animation: slideUp 0.9s ease 0.7s forwards;
            }
            .hero-body strong { color: var(--soft-pink); font-weight: 600; }
            .badge {
                display: inline-flex; align-items: center; gap: 8px; margin-top: 26px;
                padding: 10px 18px; border: 1px solid rgba(212,168,67,0.28); border-radius: 2px;
                background: rgba(212,168,67,0.05); color: var(--gold-light);
                font-size: 0.85rem; letter-spacing: 0.14em; text-transform: uppercase;
                opacity: 0; animation: slideUp 0.9s ease 1s forwards;
            }

            /* floating hearts desktop only */
            .floating-hearts {
                position: fixed; right: 36px; top: 50%; transform: translateY(-50%);
                display: flex; flex-direction: column; gap: 22px;
                opacity: 0; animation: fadeIn 1s ease 1.3s forwards; z-index: 3;
            }
            .fheart {
                font-size: 1.6rem; color: var(--rose-light);
                animation: floatHeart 3s ease-in-out infinite;
                filter: drop-shadow(0 0 8px rgba(232,64,106,0.5)); display: block;
            }
            .fheart:nth-child(2) { animation-delay: 0.6s; font-size: 1.1rem; }
            .fheart:nth-child(3) { animation-delay: 1.2s; font-size: 2rem; }
            .fheart:nth-child(4) { animation-delay: 1.8s; font-size: 0.9rem; }
            @keyframes floatHeart {
                0%, 100% { transform: translateY(0) rotate(-5deg); }
                50% { transform: translateY(-18px) rotate(5deg); }
            }
            @keyframes slideUp {
                from { opacity: 0; transform: translateY(28px); }
                to { opacity: 1; transform: translateY(0); }
            }
            @keyframes fadeIn { from { opacity: 0; } to { opacity: 1; } }

            /* ── MOBILE ── */
            @media (max-width: 768px) {
                body { cursor: auto; }
                .layout { flex-direction: column; }
                .sidebar {
                    width: 100%; height: auto; position: relative;
                    border-right: none; border-bottom: 1px solid rgba(212,168,67,0.18);
                    padding: 16px 16px 14px;
                }
                .logo-wrap { flex-direction: row; gap: 12px; margin-bottom: 12px; align-items: center; }
                .logo-frame { width: 52px; height: 52px; flex-shrink: 0; }
                .logo-name { margin-top: 0; font-size: 1.2rem; text-align: left; }
                .divider { display: none; }
                .nav-label { display: none; }
                .nav-grid { display: grid; grid-template-columns: 1fr 1fr; gap: 6px; }
                .nav-btn { margin-bottom: 0; font-size: 0.88rem; padding: 10px 12px; text-align: center; }
                .nav-btn:hover { padding-left: 12px; }
                .daily-note { display: none; }
                .main { padding: 28px 18px 48px; min-height: auto; }
                .hero-title { font-size: clamp(2.4rem, 10vw, 3.5rem); }
                .hero-body { font-size: 1rem; }
                .badge { font-size: 0.75rem; padding: 8px 14px; }
                .floating-hearts { display: none; }
                .title-underline { margin-bottom: 20px; }
            }
        </style>
    </head>
    <body>
        <div class="bg-canvas"></div>
        <div id="petals"></div>

        <div class="layout">
            <aside class="sidebar">
                <div class="logo-wrap">
                    <div class="logo-frame logo-click" id="logo-click">
                        <img src="/yasmin-Photoroom.png" alt="Yasmin">
                    </div>
                    <div class="logo-name">Yasmin + Orian omgg</div>
                </div>
                <div class="divider"></div>
                <div class="nav-label">Chickenron</div>
                <div class="nav-grid">
                    <button class="nav-btn" onclick="location.href='/reasons'">&#10022; Reasons I Love You</button>
                    <button class="nav-btn" onclick="location.href='/relationship'">&#9825; Our Time Together</button>
                    <button class="nav-btn" onclick="location.href='/fun'">&#10023; Just For Fun</button>
                    <button class="nav-btn" onclick="location.href='/more'">&#10087; I Love You More!</button>
                </div>
                <div class="daily-note">
                    <span class="daily-note-label">&#10022; today's note</span>
                    <div class="daily-note-text" id="dailyNote">loading...</div>
                </div>
            </aside>

            <main class="main">
                <div class="hero">
                    <div class="hero-eyebrow">&#8212; for my beloved &#8212;</div>
                    <h1 class="hero-title">
                        I Love You
                        <em>Yasmin</em>
                    </h1>
                    <div class="title-underline"></div>
                    <p class="hero-body">
                        I built this <strong>entire world</strong> just for you.<br>
                        Every pixel placed with love.<br>
                        Every line written thinking of you.
                    </p>
                    <div class="badge">&#10022; &nbsp; Made with love by Orian &nbsp; &#10022;</div>
                </div>
            </main>
        </div>

        <div class="floating-hearts">
            <span class="fheart">&#9829;</span>
            <span class="fheart">&#9825;</span>
            <span class="fheart">&#9829;</span>
            <span class="fheart">&#9825;</span>
        </div>

        <script>
            
            document.getElementById("logo-click").addEventListener("click", () => {
            if (localStorage.getItem("secret_unlocked") === "true") {
            window.location.href = "/secret.html";
            }
            });



            const dailyNotes = [
                "You looked beautiful today, even though I didn't see you.",
                "I thought about you 47 times today. At least.",
                "Missing you is my full-time job.",
                "You're the reason I smile at my phone like an idiot.",
                "Somewhere you exist and that makes everything okay.",
                "I love you more than yesterday. Less than tomorrow.",
                "You're my favourite notification.",
                "Every day with you is my favourite day.",
                "I love you even when I'm asleep, probably.",
                "You're embarrassingly beautiful.",
                "My heart does a little jump every time I see your name.",
                "You make ordinary days feel like something special.",
                "I would pick you in every single lifetime.",
                "You're the best thing that's ever been mine.",
                "Thinking of you is basically a hobby now.",
                "You have no idea how much I love you. It's absurd.",
                "You're the warmest thought I have.",
                "I hope today was kind to you.",
                "You deserve every good thing.",
                "Being yours is my favourite thing about me.",
                "Your laugh lives in my head rent-free.",
                "You're genuinely my favourite person on this planet.",
                "I fall for you a little more every single day.",
                "You make me want to be embarrassingly soft.",
                "Everything is better because you exist.",
                "I love you in a really ridiculous, uncontrollable way.",
                "You're it for me.",
                "I like you more than makes sense.",
                "You are home.",
                "My whole world fits in the sound of your name.",
            ];
            const today = new Date();
            const idx = (today.getFullYear() * 366 + today.getMonth() * 31 + today.getDate()) % dailyNotes.length;
            document.getElementById('dailyNote').textContent = dailyNotes[idx];

            // Petals
            const pc = document.getElementById('petals');
            const petalChars = ['\u2665','\u2661','\u2764','\u273F'];
            const petalColors = ['#e8406a','#d4a843','#ff7096','#f0c96a'];
            function spawnPetal() {
                const p = document.createElement('div');
                p.className = 'petal';
                p.textContent = petalChars[Math.floor(Math.random() * petalChars.length)];
                p.style.left = Math.random() * 100 + 'vw';
                p.style.fontSize = (0.8 + Math.random() * 1.2) + 'rem';
                p.style.animationDuration = (6 + Math.random() * 8) + 's';
                p.style.animationDelay = (Math.random() * 3) + 's';
                p.style.color = petalColors[Math.floor(Math.random() * petalColors.length)];
                pc.appendChild(p);
                setTimeout(() => p.remove(), 15000);
            }
            setInterval(spawnPetal, 900);
            for (let i = 0; i < 8; i++) setTimeout(spawnPetal, i * 350);
        </script>
    </body>
    </html>
    """, "text/html", System.Text.Encoding.UTF8);
});

app.MapReasonsPage();
app.MapRelationshipPage();
app.MapMorePage();
app.MapNguPage();
app.MapBlehhPage();
app.MapHelloPage();
app.MapNoIlymPage();
app.UseStaticFiles();
app.MapFun();

var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Run($"http://0.0.0.0:{port}");