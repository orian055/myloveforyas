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
        <link href="https://fonts.googleapis.com/css2?family=Playfair+Display:ital,wght@0,400;0,700;0,900;1,400;1,700&family=Cormorant+Garamond:ital,wght@0,300;0,400;0,600;1,300;1,400&family=Dancing+Script:wght@600;700&display=swap" rel="stylesheet">
        <style>
            :root {
                --rose: #e8406a;
                --rose-light: #ff7096;
                --rose-dark: #9e1a3a;
                --gold: #d4a843;
                --gold-light: #f0c96a;
                --cream: #fff5f7;
                --blush: #fde8ef;
                --deep: #1a0610;
                --wine: #4a0e20;
                --soft-pink: #f9c4d4;
            }
            * { box-sizing: border-box; margin: 0; padding: 0; }

            body {
                min-height: 100vh;
                font-family: 'Cormorant Garamond', serif;
                background: var(--deep);
                overflow-x: hidden;
                cursor: none;
            }

            /* Custom cursor */
            .cursor {
                width: 20px; height: 20px;
                background: var(--rose-light);
                border-radius: 50%;
                position: fixed;
                pointer-events: none;
                z-index: 9999;
                transform: translate(-50%, -50%);
                transition: transform 0.1s ease, width 0.2s, height 0.2s, opacity 0.2s;
                mix-blend-mode: screen;
            }
            .cursor-ring {
                width: 44px; height: 44px;
                border: 1px solid rgba(232,64,106,0.5);
                border-radius: 50%;
                position: fixed;
                pointer-events: none;
                z-index: 9998;
                transform: translate(-50%, -50%);
                transition: transform 0.25s ease, width 0.3s, height 0.3s;
            }

            /* Floating petals */
            .petal {
                position: fixed;
                pointer-events: none;
                font-size: 1.2rem;
                animation: petalFall linear infinite;
                z-index: 1;
                opacity: 0.6;
            }
            @keyframes petalFall {
                0% { transform: translateY(-60px) rotate(0deg) translateX(0); opacity: 0.7; }
                50% { transform: translateY(50vh) rotate(180deg) translateX(40px); opacity: 0.5; }
                100% { transform: translateY(110vh) rotate(360deg) translateX(-20px); opacity: 0; }
            }

            /* Background canvas */
            .bg-canvas {
                position: fixed;
                inset: 0;
                background:
                    radial-gradient(ellipse at 10% 20%, rgba(158, 26, 58, 0.35) 0%, transparent 50%),
                    radial-gradient(ellipse at 90% 80%, rgba(74, 14, 32, 0.5) 0%, transparent 45%),
                    radial-gradient(ellipse at 50% 50%, rgba(26, 6, 16, 0.9) 0%, transparent 70%),
                    linear-gradient(160deg, #1a0610 0%, #2d0a1a 40%, #1a0610 100%);
                z-index: 0;
            }
            .bg-canvas::after {
                content: '';
                position: absolute;
                inset: 0;
                background-image: 
                    radial-gradient(1px 1px at 20% 30%, rgba(255,200,200,0.4) 0%, transparent 100%),
                    radial-gradient(1px 1px at 60% 70%, rgba(255,180,180,0.3) 0%, transparent 100%),
                    radial-gradient(1px 1px at 80% 20%, rgba(255,220,220,0.3) 0%, transparent 100%);
                animation: twinkle 4s ease-in-out infinite alternate;
            }
            @keyframes twinkle {
                0% { opacity: 0.4; }
                100% { opacity: 1; }
            }

            /* Sidebar */
            .sidebar {
                position: fixed;
                top: 0; left: 0;
                height: 100vh;
                width: 300px;
                z-index: 100;
                display: flex;
                flex-direction: column;
                padding: 40px 28px;
                background: linear-gradient(180deg, rgba(26,6,16,0.95) 0%, rgba(74,14,32,0.85) 100%);
                border-right: 1px solid rgba(212,168,67,0.2);
                backdrop-filter: blur(20px);
            }
            .sidebar::after {
                content: '';
                position: absolute;
                top: 0; right: 0;
                width: 1px; height: 100%;
                background: linear-gradient(180deg, transparent, rgba(212,168,67,0.6), rgba(232,64,106,0.4), transparent);
                animation: shimmerLine 3s ease-in-out infinite;
            }
            @keyframes shimmerLine {
                0%, 100% { opacity: 0.4; }
                50% { opacity: 1; }
            }

            .logo-wrap {
                display: flex;
                flex-direction: column;
                align-items: center;
                margin-bottom: 32px;
            }
            .logo-frame {
            width: 96px; 
            height: 96px;
            border-radius: 50%;
            border: 2px solid var(--gold); /* This keeps a thin gold circle */
            padding: 3px;
            position: relative;
            background: transparent; /* This removes the rainbow colors */
            }
            @keyframes rotateBorder {
            from { filter: hue-rotate(0deg); }
            to { filter: hue-rotate(360deg); }
            }
            .logo-frame img {
                width: 100%; height: 100%;
                border-radius: 50%;
                object-fit: cover;
                display: block;
            }
            .logo-name {
                font-family: 'Dancing Script', cursive;
                font-size: 1.6rem;
                color: var(--gold-light);
                margin-top: 12px;
                text-align: center;
                letter-spacing: 0.05em;
                text-shadow: 0 0 20px rgba(212,168,67,0.5);
            }

            .divider {
                width: 60%;
                height: 1px;
                background: linear-gradient(90deg, transparent, rgba(212,168,67,0.5), transparent);
                margin: 8px auto 24px;
            }

            .nav-label {
                font-family: 'Cormorant Garamond', serif;
                font-size: 0.75rem;
                letter-spacing: 0.2em;
                text-transform: uppercase;
                color: rgba(212,168,67,0.6);
                margin-bottom: 14px;
                text-align: center;
            }

            .nav-btn {
                width: 100%;
                padding: 14px 20px;
                margin-bottom: 10px;
                border-radius: 4px;
                border: 1px solid rgba(212,168,67,0.15);
                background: rgba(255,255,255,0.03);
                color: var(--soft-pink);
                font-family: 'Cormorant Garamond', serif;
                font-size: 1.1rem;
                font-style: italic;
                cursor: pointer;
                transition: all 0.35s ease;
                position: relative;
                overflow: hidden;
                text-align: left;
                letter-spacing: 0.03em;
            }
            .nav-btn::before {
                content: '';
                position: absolute;
                left: 0; top: 0; bottom: 0;
                width: 3px;
                background: linear-gradient(180deg, var(--gold), var(--rose));
                transform: scaleY(0);
                transform-origin: center;
                transition: transform 0.3s ease;
            }
            .nav-btn::after {
                content: '';
                position: absolute;
                inset: 0;
                background: linear-gradient(135deg, rgba(232,64,106,0.08), transparent);
                opacity: 0;
                transition: opacity 0.3s ease;
            }
            .nav-btn:hover {
                border-color: rgba(212,168,67,0.4);
                color: var(--cream);
                padding-left: 26px;
                transform: translateX(4px);
            }
            .nav-btn:hover::before { transform: scaleY(1); }
            .nav-btn:hover::after { opacity: 1; }

            .nav-icon { margin-right: 10px; font-size: 0.9rem; }

            /* Main content */
            .main {
                margin-left: 300px;
                min-height: 100vh;
                position: relative;
                z-index: 10;
                display: flex;
                align-items: center;
                justify-content: center;
                padding: 60px 60px 60px 80px;
            }

            .hero {
                max-width: 780px;
                width: 100%;
            }

            .hero-eyebrow {
                font-family: 'Dancing Script', cursive;
                font-size: 1.4rem;
                color: var(--gold-light);
                letter-spacing: 0.1em;
                margin-bottom: 16px;
                opacity: 0;
                animation: slideUp 0.8s ease 0.2s forwards;
            }

            .hero-title {
                font-family: 'Playfair Display', serif;
                font-size: clamp(3.5rem, 6vw, 6.5rem);
                font-weight: 900;
                line-height: 1;
                letter-spacing: -0.02em;
                margin-bottom: 8px;
                color: var(--cream);
                opacity: 0;
                animation: slideUp 0.9s ease 0.4s forwards;
            }
            .hero-title em {
                font-style: italic;
                color: var(--rose-light);
                display: block;
                font-size: 0.65em;
                font-weight: 400;
                letter-spacing: 0.05em;
                text-shadow: 0 0 40px rgba(255, 112, 150, 0.5);
            }

            .title-underline {
                width: 0;
                height: 2px;
                background: linear-gradient(90deg, var(--rose), var(--gold));
                margin-bottom: 32px;
                animation: expandLine 1s ease 1s forwards;
                border-radius: 2px;
            }
            @keyframes expandLine {
                to { width: 200px; }
            }

            .hero-body {
                font-size: 1.3rem;
                line-height: 1.9;
                color: rgba(255, 220, 230, 0.85);
                font-weight: 300;
                max-width: 560px;
                opacity: 0;
                animation: slideUp 0.9s ease 0.7s forwards;
            }
            .hero-body strong {
                color: var(--soft-pink);
                font-weight: 600;
            }

            .badge {
                display: inline-flex;
                align-items: center;
                gap: 8px;
                margin-top: 28px;
                padding: 10px 20px;
                border: 1px solid rgba(212,168,67,0.3);
                border-radius: 2px;
                background: rgba(212,168,67,0.05);
                color: var(--gold-light);
                font-family: 'Cormorant Garamond', serif;
                font-size: 0.9rem;
                letter-spacing: 0.15em;
                text-transform: uppercase;
                opacity: 0;
                animation: slideUp 0.9s ease 1s forwards;
            }

            .floating-hearts {
                position: absolute;
                right: 60px;
                top: 50%;
                transform: translateY(-50%);
                display: flex;
                flex-direction: column;
                gap: 24px;
                opacity: 0;
                animation: fadeIn 1s ease 1.3s forwards;
            }
            .fheart {
                font-size: 1.8rem;
                animation: floatHeart 3s ease-in-out infinite;
                filter: drop-shadow(0 0 8px rgba(232,64,106,0.6));
            }
            .fheart:nth-child(2) { animation-delay: 0.5s; font-size: 1.3rem; }
            .fheart:nth-child(3) { animation-delay: 1s; font-size: 2.2rem; }
            .fheart:nth-child(4) { animation-delay: 1.5s; font-size: 1rem; }
            @keyframes floatHeart {
                0%, 100% { transform: translateY(0) rotate(-5deg); }
                50% { transform: translateY(-20px) rotate(5deg); }
            }

            @keyframes slideUp {
                from { opacity: 0; transform: translateY(30px); }
                to { opacity: 1; transform: translateY(0); }
            }
            @keyframes fadeIn {
                from { opacity: 0; }
                to { opacity: 1; }
            }

            @media (max-width: 900px) {
                .sidebar {
                    position: relative;
                    width: 100%;
                    height: auto;
                    border-right: none;
                    border-bottom: 1px solid rgba(212,168,67,0.2);
                    padding: 28px 20px;
                }
                .main {
                    margin-left: 0;
                    padding: 40px 24px;
                }
                .floating-hearts { display: none; }
            }
        </style>
    </head>
    <body>
        <div class="cursor" id="cursor"></div>
        <div class="cursor-ring" id="cursorRing"></div>
        <div class="bg-canvas"></div>

        <!-- Petals -->
        <div id="petals"></div>

        <div class="sidebar">
            <div class="logo-wrap">
                <div class="logo-frame">
                    <img src="/yasmin-Photoroom.png" alt="Yasmin">
                </div>
                <div class="logo-name">Yasmin + Orian omgg</div>
            </div>
            <div class="divider"></div>
            <div class="nav-label">Chickenron</div>
            <button class="nav-btn" onclick="location.href='/reasons'"><span class="nav-icon">✦</span> Reasons I Love You</button>
            <button class="nav-btn" onclick="location.href='/relationship'"><span class="nav-icon">♡</span> Our Time Together</button>
            <button class="nav-btn" onclick="location.href='/fun'"><span class="nav-icon">✧</span> Just For Fun</button>
            <button class="nav-btn" onclick="location.href='/more'"><span class="nav-icon">❧</span> I Love You More!</button>
        </div>

        <div class="main">
            <div class="hero">
                <div class="hero-eyebrow">— for my beloved —</div>
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
                <div class="badge">✦ &nbsp; Made with love by Orian &nbsp; ✦</div>
            </div>
            <div class="floating-hearts">
                <span class="fheart">♥</span>
                <span class="fheart">♡</span>
                <span class="fheart">♥</span>
                <span class="fheart">♡</span>
            </div>
        </div>

        <script>
            // Custom cursor
            const cursor = document.getElementById('cursor');
            const ring = document.getElementById('cursorRing');
            let mx = 0, my = 0, rx = 0, ry = 0;
            document.addEventListener('mousemove', e => { mx = e.clientX; my = e.clientY; });
            function animateCursor() {
                cursor.style.left = mx + 'px';
                cursor.style.top = my + 'px';
                rx += (mx - rx) * 0.12;
                ry += (my - ry) * 0.12;
                ring.style.left = rx + 'px';
                ring.style.top = ry + 'px';
                requestAnimationFrame(animateCursor);
            }
            animateCursor();

            // Petals
            const petalContainer = document.getElementById('petals');
            const petalChars = ['🌸','❤️','🌹'];
            function spawnPetal() {
                const p = document.createElement('div');
                p.className = 'petal';
                p.textContent = petalChars[Math.floor(Math.random() * petalChars.length)];
                p.style.left = Math.random() * 100 + 'vw';
                p.style.fontSize = (0.8 + Math.random() * 1.4) + 'rem';
                p.style.animationDuration = (6 + Math.random() * 8) + 's';
                p.style.animationDelay = (Math.random() * 4) + 's';
                petalContainer.appendChild(p);
                setTimeout(() => p.remove(), 15000);
            }
            setInterval(spawnPetal, 800);
            for (let i = 0; i < 8; i++) setTimeout(spawnPetal, i * 400);
        </script>
    </body>
    </html>
    """, "text/html", System.Text.Encoding.UTF8);
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