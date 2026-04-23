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
                <meta name="viewport" content="width=device-width, initial-scale=1.0">
                <link href="https://fonts.googleapis.com/css2?family=Playfair+Display:ital,wght@0,400;0,700;0,900;1,400;1,700&family=Cormorant+Garamond:ital,wght@0,300;0,400;0,600;1,300;1,400&family=Dancing+Script:wght@600;700&display=swap" rel="stylesheet">
                <style>
                    :root {
                        --rose: #e8406a; --rose-light: #ff7096;
                        --gold: #d4a843; --gold-light: #f0c96a;
                        --cream: #fff5f7; --deep: #1a0610; --soft-pink: #f9c4d4;
                    }
                    * { box-sizing: border-box; margin: 0; padding: 0; }
                    body {
                        min-height: 100vh; min-height: 100dvh;
                        font-family: 'Cormorant Garamond', serif;
                        background:
                            radial-gradient(ellipse at 15% 25%, rgba(158,26,58,0.28) 0%, transparent 50%),
                            radial-gradient(ellipse at 85% 75%, rgba(74,14,32,0.35) 0%, transparent 45%),
                            linear-gradient(160deg, #1a0610 0%, #2d0a1a 40%, #1a0610 100%);
                        color: var(--cream); overflow: hidden;
                        display: flex; flex-direction: column; align-items: center; justify-content: center;
                    }

                    /* ── SCREENS ── */
                    .screen { display: none; width: 100%; max-width: 480px; padding: 0 16px; text-align: center; }
                    .screen.active { display: flex; flex-direction: column; align-items: center; }

                    /* start screen */
                    .eyebrow {
                        font-family: 'Dancing Script', cursive; font-size: 1.3rem;
                        color: var(--gold-light); margin-bottom: 10px;
                        animation: slideUp 0.5s ease forwards;
                    }
                    h1 {
                        font-family: 'Playfair Display', serif;
                        font-size: clamp(2.2rem, 8vw, 3.4rem); font-weight: 700; font-style: italic;
                        color: var(--cream); letter-spacing: -0.02em; margin-bottom: 8px;
                        animation: slideUp 0.5s ease 0.1s both;
                    }
                    .gold-line {
                        width: 80px; height: 1px;
                        background: linear-gradient(90deg, transparent, var(--gold), transparent);
                        margin: 14px auto 20px;
                        animation: expandLine 0.8s ease 0.3s both;
                    }
                    @keyframes expandLine { from { width: 0; } to { width: 80px; } }
                    .desc {
                        font-size: 1.05rem; color: rgba(249,196,212,0.75);
                        font-style: italic; line-height: 1.7; margin-bottom: 28px;
                        animation: slideUp 0.5s ease 0.2s both;
                    }
                    .high-score-display {
                        font-size: 0.85rem; color: rgba(212,168,67,0.55);
                        letter-spacing: 0.1em; margin-bottom: 20px;
                        animation: slideUp 0.5s ease 0.25s both;
                    }

                    /* ── GAME CANVAS WRAPPER ── */
                    #gameScreen {
                        position: fixed; inset: 0;
                        display: none; flex-direction: column;
                        align-items: center; justify-content: flex-start;
                        padding-top: 0;
                    }
                    #gameScreen.active { display: flex; }

                    .hud {
                        width: 100%; max-width: 480px;
                        display: flex; justify-content: space-between; align-items: center;
                        padding: 12px 18px 8px;
                        position: relative; z-index: 10;
                    }
                    .hud-score { font-family: 'Playfair Display', serif; font-size: 1.4rem; color: var(--soft-pink); }
                    .hud-lives { font-size: 1.3rem; letter-spacing: 4px; }
                    .hud-timer {
                        font-family: 'Cormorant Garamond', serif; font-size: 1rem;
                        color: rgba(212,168,67,0.7); letter-spacing: 0.1em;
                    }

                    canvas {
                        display: block;
                        width: 100%;
                        max-width: 480px;
                        border: 1px solid rgba(212,168,67,0.15);
                        border-top: none;
                        background: rgba(22,5,14,0.7);
                        touch-action: none;
                    }

                    /* ── OVER SCREEN ── */
                    #overScreen { position: fixed; inset: 0; background: rgba(26,6,16,0.92); backdrop-filter: blur(8px); z-index: 20; }
                    .over-card {
                        background: rgba(22,5,14,0.95); border: 1px solid rgba(212,168,67,0.2);
                        border-radius: 4px; padding: 48px 40px 40px;
                        width: min(400px, 88vw); text-align: center; position: relative; overflow: hidden;
                        animation: cardIn 0.4s ease;
                    }
                    @keyframes cardIn { from { opacity:0; transform:translateY(30px); } to { opacity:1; transform:translateY(0); } }
                    .over-card::before {
                        content: ''; position: absolute; top: 0; left: 0; right: 0; height: 2px;
                        background: linear-gradient(90deg, transparent, var(--gold), var(--rose-light), var(--gold), transparent);
                        background-size: 200% 100%; animation: shimmer 3s linear infinite;
                    }
                    @keyframes shimmer { from { background-position:200% 0; } to { background-position:-200% 0; } }
                    .over-title {
                        font-family: 'Playfair Display', serif; font-weight: 700; font-style: italic;
                        font-size: 2rem; color: var(--cream); margin-bottom: 6px;
                    }
                    .over-score { font-size: 3.5rem; font-family: 'Playfair Display', serif; color: var(--soft-pink); line-height: 1; }
                    .over-label { font-size: 0.8rem; letter-spacing: 0.2em; text-transform: uppercase; color: rgba(212,168,67,0.5); margin-bottom: 16px; }
                    .over-msg { font-style: italic; font-size: 1.1rem; color: rgba(249,196,212,0.7); margin: 14px 0 28px; line-height: 1.6; }
                    .new-best { color: var(--gold-light); font-family: 'Dancing Script', cursive; font-size: 1.2rem; margin-bottom: 6px; }

                    /* ── BUTTONS ── */
                    .btn {
                        padding: 14px 40px; border-radius: 3px;
                        border: 1px solid rgba(212,168,67,0.3);
                        background: transparent; color: var(--gold-light);
                        font-family: 'Cormorant Garamond', serif; font-size: 1rem; font-style: italic;
                        letter-spacing: 0.1em; cursor: pointer; transition: all 0.3s ease;
                        display: inline-block;
                    }
                    .btn:hover { border-color: var(--gold); color: var(--cream); background: rgba(212,168,67,0.08); transform: translateY(-2px); }
                    .btn-primary {
                        padding: 16px 44px; border-radius: 3px;
                        border: 1px solid rgba(232,64,106,0.4);
                        background: rgba(232,64,106,0.08); color: var(--soft-pink);
                        font-family: 'Playfair Display', serif; font-size: 1.2rem; font-style: italic;
                        cursor: pointer; transition: all 0.3s ease; display: inline-block;
                    }
                    .btn-primary:hover { border-color: var(--rose-light); color: var(--cream); background: rgba(232,64,106,0.15); transform: translateY(-2px); box-shadow: 0 12px 30px rgba(232,64,106,0.2); }
                    .btn-row { display: flex; gap: 12px; justify-content: center; flex-wrap: wrap; }

                    @keyframes slideUp { from { opacity:0; transform:translateY(20px); } to { opacity:1; transform:translateY(0); } }
                </style>
            </head>
            <body>

                <!-- START SCREEN -->
                <div class="screen active" id="startScreen">
                    <div class="eyebrow">&#8212; just for fun &#8212;</div>
                    <h1>Heart Catcher</h1>
                    <div class="gold-line"></div>
                    <p class="desc">
                        Catch the falling hearts.<br>
                        Don't let them hit the ground.<br>
                        Miss 3 and it's over.
                    </p>
                    <div class="high-score-display" id="hsDisplay">Best: 0</div>
                    <button class="btn-primary" onclick="startGame()">Play &#9829;</button>
                    <br><br>
                    <button class="btn" onclick="location.href='/Yas'">&#8592; return home</button>
                </div>

                <!-- GAME SCREEN -->
                <div id="gameScreen">
                    <div class="hud">
                        <div class="hud-score" id="hudScore">0</div>
                        <div class="hud-lives" id="hudLives">&#9829;&#9829;&#9829;</div>
                        <div class="hud-timer" id="hudTimer">60s</div>
                    </div>
                    <canvas id="canvas"></canvas>
                </div>

                <!-- OVER SCREEN -->
                <div class="screen" id="overScreen">
                    <div class="over-card">
                        <div class="over-title" id="overTitle">Game Over</div>
                        <div class="over-score" id="overScore">0</div>
                        <div class="over-label">hearts caught</div>
                        <div class="new-best" id="newBest" style="display:none">&#10022; New Best! &#10022;</div>
                        <div class="over-msg" id="overMsg">Not bad!</div>
                        <div class="btn-row">
                            <button class="btn-primary" onclick="startGame()">Play Again &#9829;</button>
                            <button class="btn" onclick="location.href='/Yas'">&#8592; home</button>
                        </div>
                    </div>
                </div>

                <script>
                    const canvas = document.getElementById('canvas');
                    const ctx = canvas.getContext('2d');

                    let W, H, dpr;
                    let hearts = [], score, lives, gameRunning, animId, timeLeft, spawnTimer, spawnInterval;
                    let paddleX, paddleW, paddleY;
                    let touching = false, touchX = 0;
                    let highScore = parseInt(localStorage.getItem('hcHS') || '0');

                    document.getElementById('hsDisplay').textContent = 'Best: ' + highScore;

                    function resize() {
                        const maxW = Math.min(480, window.innerWidth);
                        const maxH = window.innerHeight - 60;
                        dpr = window.devicePixelRatio || 1;
                        canvas.style.width = maxW + 'px';
                        canvas.style.height = Math.min(maxH, maxW * 1.4) + 'px';
                        canvas.width = maxW * dpr;
                        canvas.height = Math.min(maxH, maxW * 1.4) * dpr;
                        W = canvas.width; H = canvas.height;
                        paddleW = W * 0.22;
                        paddleY = H - 30 * dpr;
                        if (!gameRunning) paddleX = W / 2;
                    }

                    window.addEventListener('resize', resize);
                    resize();

                    function startGame() {
                        document.getElementById('startScreen').classList.remove('active');
                        document.getElementById('overScreen').classList.remove('active');
                        document.getElementById('gameScreen').classList.add('active');
                        resize();

                        hearts = []; score = 0; lives = 3; timeLeft = 60;
                        spawnInterval = 1400; spawnTimer = 0;
                        paddleX = W / 2; gameRunning = true;

                        updateHUD();
                        if (animId) cancelAnimationFrame(animId);
                        lastTime = null;
                        animId = requestAnimationFrame(loop);
                    }

                    let lastTime = null;
                    function loop(ts) {
                        if (!gameRunning) return;
                        const dt = lastTime ? Math.min(ts - lastTime, 50) : 16;
                        lastTime = ts;

                        // timer
                        timeLeft -= dt / 1000;
                        if (timeLeft <= 0) { endGame(true); return; }

                        // spawn
                        spawnTimer += dt;
                        if (spawnTimer >= spawnInterval) {
                            spawnTimer = 0;
                            spawnInterval = Math.max(500, 1400 - score * 12);
                            spawnHeart();
                        }

                        // move paddle toward touch/mouse
                        if (touching) {
                            const rect = canvas.getBoundingClientRect();
                            const tx = (touchX - rect.left) * dpr;
                            paddleX += (tx - paddleX) * 0.18;
                        }
                        paddleX = Math.max(paddleW/2, Math.min(W - paddleW/2, paddleX));

                        // update hearts
                        const speed = (2.5 + score * 0.08) * dpr * (dt / 16);
                        for (let i = hearts.length - 1; i >= 0; i--) {
                            const h = hearts[i];
                            h.y += speed;
                            h.rot += 0.04;

                            // caught?
                            if (h.y + h.r > paddleY - 8*dpr &&
                                h.y - h.r < paddleY + 10*dpr &&
                                h.x > paddleX - paddleW/2 - h.r &&
                                h.x < paddleX + paddleW/2 + h.r) {
                                score++;
                                hearts.splice(i, 1);
                                updateHUD();
                                continue;
                            }

                            // missed
                            if (h.y > H + h.r) {
                                hearts.splice(i, 1);
                                lives--;
                                updateHUD();
                                if (lives <= 0) { endGame(false); return; }
                            }
                        }

                        draw();
                        animId = requestAnimationFrame(loop);
                    }

                    function spawnHeart() {
                        const isBomb = score > 5 && Math.random() < 0.18;
                        hearts.push({
                            x: (0.1 + Math.random() * 0.8) * W,
                            y: -20 * dpr,
                            r: (18 + Math.random() * 12) * dpr,
                            rot: Math.random() * Math.PI,
                            bomb: isBomb,
                            color: isBomb ? '#888' : (Math.random() > 0.5 ? '#e8406a' : '#d4a843')
                        });
                    }

                    function drawHeart(x, y, r, color, rot) {
                        ctx.save();
                        ctx.translate(x, y);
                        ctx.rotate(rot);
                        ctx.scale(r/10, r/10);
                        ctx.beginPath();
                        ctx.moveTo(0, -3);
                        ctx.bezierCurveTo(0, -6, -5, -6, -5, -2);
                        ctx.bezierCurveTo(-5, 2, 0, 5, 0, 8);
                        ctx.bezierCurveTo(0, 5, 5, 2, 5, -2);
                        ctx.bezierCurveTo(5, -6, 0, -6, 0, -3);
                        ctx.fillStyle = color;
                        ctx.shadowColor = color;
                        ctx.shadowBlur = 8;
                        ctx.fill();
                        ctx.restore();
                    }

                    function draw() {
                        ctx.clearRect(0, 0, W, H);

                        // draw paddle
                        const pw = paddleW, ph = 12 * dpr, pr = ph / 2;
                        const px = paddleX - pw/2, py = paddleY - ph/2;
                        ctx.beginPath();
                        ctx.moveTo(px + pr, py);
                        ctx.lineTo(px + pw - pr, py);
                        ctx.arcTo(px + pw, py, px + pw, py + ph, pr);
                        ctx.lineTo(px + pw, py + ph - pr);
                        ctx.arcTo(px + pw, py + ph, px + pw - pr, py + ph, pr);
                        ctx.lineTo(px + pr, py + ph);
                        ctx.arcTo(px, py + ph, px, py + ph - pr, pr);
                        ctx.lineTo(px, py + pr);
                        ctx.arcTo(px, py, px + pr, py, pr);
                        ctx.closePath();
                        const grad = ctx.createLinearGradient(px, py, px + pw, py);
                        grad.addColorStop(0, 'rgba(232,64,106,0.7)');
                        grad.addColorStop(0.5, 'rgba(240,201,106,0.9)');
                        grad.addColorStop(1, 'rgba(232,64,106,0.7)');
                        ctx.fillStyle = grad;
                        ctx.shadowColor = 'rgba(240,201,106,0.5)';
                        ctx.shadowBlur = 14;
                        ctx.fill();
                        ctx.shadowBlur = 0;

                        // draw hearts
                        for (const h of hearts) {
                            drawHeart(h.x, h.y, h.r, h.color, h.rot);
                            if (h.bomb) {
                                ctx.save();
                                ctx.font = `${h.r * 0.9}px serif`;
                                ctx.fillStyle = 'rgba(255,255,255,0.5)';
                                ctx.textAlign = 'center';
                                ctx.textBaseline = 'middle';
                                ctx.fillText('✕', h.x, h.y);
                                ctx.restore();
                            }
                        }

                        // timer bar
                        const barW = W * 0.8;
                        const barX = W * 0.1;
                        const barY = 8 * dpr;
                        ctx.fillStyle = 'rgba(255,255,255,0.06)';
                        ctx.fillRect(barX, barY, barW, 4 * dpr);
                        const fill = Math.max(0, timeLeft / 60);
                        const fillGrad = ctx.createLinearGradient(barX, 0, barX + barW, 0);
                        fillGrad.addColorStop(0, '#e8406a');
                        fillGrad.addColorStop(1, '#d4a843');
                        ctx.fillStyle = fillGrad;
                        ctx.fillRect(barX, barY, barW * fill, 4 * dpr);
                    }

                    function updateHUD() {
                        document.getElementById('hudScore').textContent = score;
                        const hearts_arr = ['&#9829;&#9829;&#9829;','&#9829;&#9829;&#9825;','&#9829;&#9825;&#9825;','&#9825;&#9825;&#9825;'];
                        document.getElementById('hudLives').innerHTML = hearts_arr[3 - Math.max(0, Math.min(3, lives))];
                        document.getElementById('hudTimer').textContent = Math.ceil(timeLeft) + 's';
                    }

                    const msgs = [
                        ["0-5", "You can do better, I believe in you!", "Keep trying &#9825;"],
                        ["6-15", "Not bad! You're warming up.", "Getting better every time!"],
                        ["16-25", "Pretty good! You've got quick hands.", "I knew you had it in you!"],
                        ["26-40", "Wow okay that's actually impressive!", "You're genuinely good at this &#9829;"],
                        ["41-999", "OKAY WHAT. You're a heart-catching machine.", "I'm literally in awe of you &#9829;&#9829;"]
                    ];

                    function endGame(timeUp) {
                        gameRunning = false;
                        cancelAnimationFrame(animId);
                        document.getElementById('gameScreen').classList.remove('active');

                        const isNewBest = score > highScore;
                        if (isNewBest) {
                            highScore = score;
                            localStorage.setItem('hcHS', highScore);
                            document.getElementById('hsDisplay').textContent = 'Best: ' + highScore;
                        }

                        let msg = msgs[0];
                        if (score >= 41) msg = msgs[4];
                        else if (score >= 26) msg = msgs[3];
                        else if (score >= 16) msg = msgs[2];
                        else if (score >= 6) msg = msgs[1];

                        document.getElementById('overTitle').textContent = timeUp ? 'Time\'s Up!' : 'Game Over';
                        document.getElementById('overScore').textContent = score;
                        document.getElementById('newBest').style.display = isNewBest ? 'block' : 'none';
                        document.getElementById('overMsg').innerHTML = timeUp
                            ? 'You survived! ' + msg[2]
                            : msg[1] + ' ' + msg[2];

                        document.getElementById('overScreen').classList.add('active');
                    }

                    // ── CONTROLS ──
                    // Mouse
                    document.addEventListener('mousemove', e => {
                        if (!gameRunning) return;
                        touching = true;
                        touchX = e.clientX;
                    });
                    document.addEventListener('mouseleave', () => { touching = false; });

                    // Touch
                    canvas.addEventListener('touchstart', e => { e.preventDefault(); touching = true; touchX = e.touches[0].clientX; }, { passive: false });
                    canvas.addEventListener('touchmove', e => { e.preventDefault(); touchX = e.touches[0].clientX; }, { passive: false });
                    canvas.addEventListener('touchend', () => { touching = false; });

                    // Keyboard
                    const keys = {};
                    document.addEventListener('keydown', e => { keys[e.key] = true; });
                    document.addEventListener('keyup', e => { keys[e.key] = false; });
                    setInterval(() => {
                        if (!gameRunning) return;
                        const spd = W * 0.025;
                        if (keys['ArrowLeft'] || keys['a']) paddleX -= spd;
                        if (keys['ArrowRight'] || keys['d']) paddleX += spd;
                    }, 16);
                </script>
            </body>
            </html>
            """, "text/html", System.Text.Encoding.UTF8);
        });
    }
}