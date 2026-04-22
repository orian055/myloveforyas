public static class FunPage
{
    public static void MapFunPage(this WebApplication app)
    {
        app.MapGet("/fun", () =>
        {
            return Results.Content("""
            <html>
            <head>
            <meta charset="UTF-8">
                <link href="https://fonts.googleapis.com/css2?family=Playfair+Display:ital,wght@0,400;0,700;0,900;1,400;1,700&family=Cormorant+Garamond:ital,wght@0,300;0,400;0,600;1,300;1,400&family=Dancing+Script:wght@600;700&display=swap" rel="stylesheet">
                <style>
                    :root {
                        --rose: #e8406a; --rose-light: #ff7096;
                        --gold: #d4a843; --gold-light: #f0c96a;
                        --cream: #fff5f7; --deep: #1a0610; --soft-pink: #f9c4d4;
                    }
                    * { box-sizing: border-box; margin: 0; padding: 0; }
                    body {
                        min-height: 100vh;
                        font-family: 'Cormorant Garamond', serif;
                        background:
                            radial-gradient(ellipse at 15% 25%, rgba(158,26,58,0.28) 0%, transparent 50%),
                            radial-gradient(ellipse at 85% 75%, rgba(74,14,32,0.35) 0%, transparent 45%),
                            linear-gradient(160deg, #1a0610 0%, #2d0a1a 40%, #1a0610 100%);
                        color: var(--cream); overflow-x: hidden;
                        display: flex; align-items: center; justify-content: center; min-height: 100vh;
                    }
                    .petal { position: fixed; pointer-events: none; animation: petalFall linear infinite; z-index: 0; opacity: 0.45; }
                    @keyframes petalFall {
                        0% { transform: translateY(-40px) rotate(0deg); opacity: 0.5; }
                        100% { transform: translateY(105vh) rotate(540deg) translateX(25px); opacity: 0; }
                    }
                    .card {
                        width: min(600px, 90%);
                        padding: 64px 52px 52px;
                        border-radius: 4px;
                        background: rgba(22,5,14,0.88);
                        border: 1px solid rgba(212,168,67,0.2);
                        box-shadow: 0 50px 120px rgba(0,0,0,0.6), inset 0 1px 0 rgba(212,168,67,0.12);
                        backdrop-filter: blur(28px);
                        text-align: center; position: relative; overflow: hidden; z-index: 1;
                        animation: cardIn 0.8s ease forwards;
                    }
                    @keyframes cardIn {
                        from { opacity: 0; transform: translateY(40px); }
                        to { opacity: 1; transform: translateY(0); }
                    }
                    .card::before {
                        content: ''; position: absolute; top: 0; left: 0; right: 0; height: 2px;
                        background: linear-gradient(90deg, transparent, var(--gold), var(--rose-light), var(--gold), transparent);
                        background-size: 200% 100%; animation: shimmer 3s linear infinite;
                    }
                    @keyframes shimmer { from { background-position: 200% 0; } to { background-position: -200% 0; } }

                    .eyebrow {
                        font-family: 'Dancing Script', cursive;
                        font-size: 1.3rem; color: var(--gold-light); margin-bottom: 12px;
                        opacity: 0; animation: slideUp 0.6s ease 0.2s forwards;
                    }
                    h1 {
                        font-family: 'Playfair Display', serif;
                        font-size: clamp(2.6rem, 6vw, 4rem); font-weight: 700; font-style: italic;
                        color: var(--cream); letter-spacing: -0.02em;
                        opacity: 0; animation: slideUp 0.6s ease 0.35s forwards;
                    }
                    .gold-line {
                        width: 0; height: 1px;
                        background: linear-gradient(90deg, transparent, var(--gold), transparent);
                        margin: 20px auto; animation: expandLine 1s ease 0.8s forwards;
                    }
                    @keyframes expandLine { to { width: 100px; } }

                    .coming-soon {
                        font-size: 1.3rem; color: rgba(249,196,212,0.7);
                        font-style: italic; font-weight: 300; margin: 24px 0;
                        opacity: 0; animation: slideUp 0.6s ease 0.6s forwards;
                    }
                    .big-emoji {
                        font-size: 4rem; margin: 20px 0;
                        display: block;
                        animation: floatEmoji 3s ease-in-out infinite, slideUp 0.6s ease 0.75s both;
                        filter: drop-shadow(0 10px 20px rgba(232,64,106,0.3));
                    }
                    @keyframes floatEmoji {
                        0%, 100% { transform: translateY(0) rotate(-5deg); }
                        50% { transform: translateY(-16px) rotate(5deg); }
                    }

                    .back-btn {
                        margin-top: 28px; padding: 14px 36px; border-radius: 2px;
                        border: 1px solid rgba(212,168,67,0.3); background: transparent;
                        color: var(--gold-light); font-family: 'Cormorant Garamond', serif;
                        font-size: 1rem; font-style: italic; letter-spacing: 0.1em;
                        cursor: pointer; transition: all 0.3s ease;
                        opacity: 0; animation: slideUp 0.6s ease 1s forwards;
                    }
                    .back-btn:hover {
                        border-color: var(--gold); color: var(--cream);
                        background: rgba(212,168,67,0.08); transform: translateY(-2px);
                    }
                    @keyframes slideUp {
                        from { opacity: 0; transform: translateY(20px); }
                        to { opacity: 1; transform: translateY(0); }
                    }
                </style>
            </head>
            <body>
                <div id="petals"></div>
                <div class="card">
                    <div class="eyebrow">— more to come —</div>
                    <h1>Just For Fun</h1>
                    <div class="gold-line"></div>
                    <p class="coming-soon">IM COOKING HERE! JUST WAIT</p>
                    <span class="big-emoji">✨</span>
                    <button class="back-btn" onclick="location.href='/Yas'">← return home</button>
                </div>
                <script>
                    const pc = document.getElementById('petals');
                    const ps = ['🌸','♡','❤️','✿','❧','✨'];
                    function sp() {
                        const p = document.createElement('div'); p.className = 'petal';
                        p.textContent = ps[Math.floor(Math.random() * ps.length)];
                        p.style.left = Math.random() * 100 + 'vw';
                        p.style.fontSize = (0.7 + Math.random() * 1.1) + 'rem';
                        p.style.animationDuration = (7 + Math.random() * 9) + 's';
                        p.style.animationDelay = (Math.random() * 3) + 's';
                        pc.appendChild(p); setTimeout(() => p.remove(), 16000);
                    }
                    setInterval(sp, 1000);
                    for (let i = 0; i < 6; i++) setTimeout(sp, i * 400);
                </script>
            </body>
            </html>
            """, "text/html", System.Text.Encoding.UTF8);
        });
    }
}