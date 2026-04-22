public static class RelationshipPage
{
    public static void MapRelationshipPage(this WebApplication app)
    {
        app.MapGet("/relationship", () =>
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
                        color: var(--cream);
                        overflow-x: hidden;
                    }
                    .petal { position: fixed; pointer-events: none; animation: petalFall linear infinite; z-index: 0; opacity: 0.45; }
                    @keyframes petalFall {
                        0% { transform: translateY(-40px) rotate(0deg); opacity: 0.5; }
                        100% { transform: translateY(105vh) rotate(540deg) translateX(25px); opacity: 0; }
                    }
                    .page-wrap {
                        min-height: 100vh;
                        display: flex; align-items: center; justify-content: center;
                        padding: 48px 24px;
                        position: relative; z-index: 1;
                    }
                    .card {
                        width: min(700px, 100%);
                        padding: 60px 52px 48px;
                        border-radius: 4px;
                        background: rgba(22,5,14,0.88);
                        border: 1px solid rgba(212,168,67,0.2);
                        box-shadow: 0 50px 120px rgba(0,0,0,0.6), inset 0 1px 0 rgba(212,168,67,0.12);
                        backdrop-filter: blur(28px);
                        text-align: center;
                        position: relative; overflow: hidden;
                        animation: cardIn 0.8s ease forwards;
                    }
                    @keyframes cardIn {
                        from { opacity: 0; transform: translateY(40px); }
                        to { opacity: 1; transform: translateY(0); }
                    }
                    .card::before {
                        content: ''; position: absolute; top: 0; left: 0; right: 0; height: 2px;
                        background: linear-gradient(90deg, transparent, var(--gold), var(--rose-light), var(--gold), transparent);
                        background-size: 200% 100%;
                        animation: shimmer 3s linear infinite;
                    }
                    @keyframes shimmer { from { background-position: 200% 0; } to { background-position: -200% 0; } }

                    .eyebrow {
                        font-family: 'Dancing Script', cursive;
                        font-size: 1.3rem; color: var(--gold-light);
                        letter-spacing: 0.08em; margin-bottom: 10px;
                        opacity: 0; animation: slideUp 0.7s ease 0.2s forwards;
                    }
                    h1 {
                        font-family: 'Playfair Display', serif;
                        font-size: clamp(2.2rem, 5vw, 3.4rem);
                        font-weight: 700; color: var(--cream);
                        letter-spacing: -0.02em; line-height: 1.1;
                        opacity: 0; animation: slideUp 0.7s ease 0.35s forwards;
                    }
                    h1 em { font-style: italic; color: var(--rose-light); }
                    .gold-line {
                        width: 0; height: 1px;
                        background: linear-gradient(90deg, transparent, var(--gold), transparent);
                        margin: 18px auto;
                        animation: expandLine 1s ease 0.8s forwards;
                    }
                    @keyframes expandLine { to { width: 100px; } }
                    .sub {
                        font-size: 1.05rem; color: rgba(249,196,212,0.7);
                        font-style: italic; font-weight: 300;
                        margin-bottom: 36px;
                        opacity: 0; animation: slideUp 0.7s ease 0.5s forwards;
                    }

                    /* Time grid */
                    .time-grid {
                        display: grid;
                        grid-template-columns: repeat(2, 1fr);
                        gap: 14px;
                        margin-bottom: 28px;
                        opacity: 0; animation: slideUp 0.7s ease 0.65s forwards;
                    }
                    .time-unit {
                        padding: 28px 16px 20px;
                        background: rgba(255,255,255,0.025);
                        border: 1px solid rgba(212,168,67,0.12);
                        border-radius: 4px;
                        position: relative; overflow: hidden;
                        transition: border-color 0.3s ease, transform 0.3s ease;
                    }
                    .time-unit:hover {
                        border-color: rgba(212,168,67,0.3);
                        transform: translateY(-3px);
                    }
                    .time-unit::before {
                        content: '';
                        position: absolute; inset: 0;
                        background: radial-gradient(circle at 50% 0%, rgba(232,64,106,0.07), transparent 70%);
                        pointer-events: none;
                    }
                    .time-value {
                        font-family: 'Playfair Display', serif;
                        font-size: 3rem; font-weight: 900;
                        color: var(--soft-pink);
                        line-height: 1;
                        display: block;
                        text-shadow: 0 0 30px rgba(255,112,150,0.3);
                        animation: pulse 2s ease-in-out infinite;
                    }
                    .time-unit:nth-child(2) .time-value { animation-delay: 0.5s; }
                    .time-unit:nth-child(3) .time-value { animation-delay: 1s; }
                    .time-unit:nth-child(4) .time-value { animation-delay: 1.5s; }
                    @keyframes pulse {
                        0%, 100% { text-shadow: 0 0 30px rgba(255,112,150,0.3); }
                        50% { text-shadow: 0 0 50px rgba(255,112,150,0.6); }
                    }
                    .time-label {
                        font-size: 0.75rem;
                        color: rgba(212,168,67,0.55);
                        letter-spacing: 0.2em;
                        text-transform: uppercase;
                        margin-top: 10px;
                        display: block;
                        font-family: 'Cormorant Garamond', serif;
                    }

                    .love-note {
                        font-family: 'Dancing Script', cursive;
                        font-size: 1.4rem;
                        color: var(--gold-light);
                        margin: 8px 0 0;
                        opacity: 0; animation: slideUp 0.7s ease 0.9s forwards;
                    }

                    .back-btn {
                        margin-top: 32px;
                        padding: 14px 36px;
                        border-radius: 2px;
                        border: 1px solid rgba(212,168,67,0.3);
                        background: transparent;
                        color: var(--gold-light);
                        font-family: 'Cormorant Garamond', serif;
                        font-size: 1rem; font-style: italic;
                        letter-spacing: 0.1em;
                        cursor: pointer;
                        transition: all 0.3s ease;
                        opacity: 0; animation: slideUp 0.7s ease 1.1s forwards;
                    }
                    .back-btn:hover {
                        border-color: var(--gold); color: var(--cream);
                        background: rgba(212,168,67,0.08);
                        transform: translateY(-2px);
                    }
                    @keyframes slideUp {
                        from { opacity: 0; transform: translateY(20px); }
                        to { opacity: 1; transform: translateY(0); }
                    }
                </style>
            </head>
            <body>
                <div id="petals"></div>
                <div class="page-wrap">
                    <div class="card">
                        <div class="eyebrow">— cool update righttt??? —</div>
                        <h1>Together Since<br><em>February 16, 2026</em></h1>
                        <div class="gold-line"></div>
                        <p class="sub">Until forever.</p>

                        <div class="time-grid">
                            <div class="time-unit">
                                <span class="time-value" id="days">0</span>
                                <span class="time-label">Days</span>
                            </div>
                            <div class="time-unit">
                                <span class="time-value" id="hours">0</span>
                                <span class="time-label">Hours</span>
                            </div>
                            <div class="time-unit">
                                <span class="time-value" id="minutes">0</span>
                                <span class="time-label">Minutes</span>
                            </div>
                            <div class="time-unit">
                                <span class="time-value" id="seconds">0</span>
                                <span class="time-label">Seconds</span>
                            </div>
                        </div>

                        <br>
                        <button class="back-btn" onclick="location.href='/Yas'">← return home</button>
                    </div>
                </div>

                <script>
                    function updateTimer() {
                        const start = new Date(2026, 1, 16, 0, 0, 0);
                        const now = new Date();
                        const diff = now - start;
                        const days = Math.floor(diff / 86400000) + 1;
                        const hours = Math.floor((diff % 86400000) / 3600000);
                        const minutes = Math.floor((diff % 3600000) / 60000);
                        const seconds = Math.floor((diff % 60000) / 1000);
                        document.getElementById('days').textContent = days;
                        document.getElementById('hours').textContent = hours;
                        document.getElementById('minutes').textContent = minutes;
                        document.getElementById('seconds').textContent = seconds;
                    }
                    updateTimer();
                    setInterval(updateTimer, 1000);

                    // Petals
                    const pc = document.getElementById('petals');
                    const ps = ['🌸','❤️','🌹'];
                    function spawnPetal() {
                        const p = document.createElement('div');
                        p.className = 'petal';
                        p.textContent = ps[Math.floor(Math.random() * ps.length)];
                        p.style.left = Math.random() * 100 + 'vw';
                        p.style.fontSize = (0.7 + Math.random() * 1.1) + 'rem';
                        p.style.animationDuration = (7 + Math.random() * 9) + 's';
                        p.style.animationDelay = (Math.random() * 3) + 's';
                        pc.appendChild(p);
                        setTimeout(() => p.remove(), 16000);
                    }
                    setInterval(spawnPetal, 1000);
                    for (let i = 0; i < 8; i++) setTimeout(spawnPetal, i * 300);
                </script>
            </body>
            </html>
            """, "text/html");
        });
    }
}