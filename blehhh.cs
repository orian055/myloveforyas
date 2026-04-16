public static class BlehhPage
{
    public static void MapBlehhPage(this WebApplication app)
    {
        app.MapGet("/blehhh", () =>
        {
            return Results.Content("""
            <html>
            <head>
                <style>
                    * { box-sizing: border-box; }
                    body {
                        min-height: 100vh;
                        margin: 0;
                        padding: 0;
                        font-family: 'Inter', 'Segoe UI', sans-serif;
                        color: #f7e7ff;
                        background: radial-gradient(circle at 20% 15%, rgba(255, 145, 196, 0.18), transparent 20%),
                                    radial-gradient(circle at 85% 20%, rgba(255, 95, 145, 0.24), transparent 18%),
                                    linear-gradient(135deg, #30042d 0%, #461362 45%, #a11d7d 100%);
                        display: flex;
                        align-items: center;
                        justify-content: center;
                        height: 100vh;
                        overflow: hidden;
                    }
                    @keyframes rumble {
                        0%   { transform: translate(0, 0) rotate(0deg); }
                        10%  { transform: translate(-8px, -6px) rotate(-1deg); }
                        20%  { transform: translate(8px, 6px) rotate(1deg); }
                        30%  { transform: translate(-10px, 4px) rotate(0.5deg); }
                        40%  { transform: translate(10px, -4px) rotate(-0.5deg); }
                        50%  { transform: translate(-6px, 8px) rotate(1deg); }
                        60%  { transform: translate(6px, -8px) rotate(-1deg); }
                        70%  { transform: translate(-8px, 4px) rotate(0.5deg); }
                        80%  { transform: translate(8px, -4px) rotate(-0.5deg); }
                        90%  { transform: translate(-4px, 6px) rotate(0deg); }
                        100% { transform: translate(0, 0) rotate(0deg); }
                    }
                    .rumbling {
                        animation: rumble 0.5s ease;
                    }
                    .blehhh-btn {
                        padding: 28px 64px;
                        font-size: 2.8rem;
                        font-weight: 800;
                        border-radius: 999px;
                        border: 2px solid rgba(255,255,255,0.2);
                        background: linear-gradient(135deg, rgba(255, 109, 208, 0.25), rgba(255,255,255,0.08));
                        color: #ffd6ff;
                        cursor: pointer;
                        letter-spacing: 0.04em;
                        box-shadow: 0 20px 60px rgba(207, 53, 135, 0.3);
                        transition: transform 0.2s ease, box-shadow 0.2s ease;
                    }
                    .blehhh-btn:hover {
                        transform: scale(1.05);
                        box-shadow: 0 28px 70px rgba(207, 53, 135, 0.45);
                    }
                    .back-btn {
                        position: fixed;
                        bottom: 32px;
                        left: 50%;
                        transform: translateX(-50%);
                        padding: 12px 24px;
                        border-radius: 999px;
                        border: 1px solid rgba(255,255,255,0.15);
                        background: rgba(255,255,255,0.08);
                        color: #ffd5ff;
                        cursor: pointer;
                        font-size: 1rem;
                        transition: all 0.25s ease;
                    }
                    .back-btn:hover {
                        background: rgba(255,255,255,0.14);
                        transform: translateX(-50%) translateY(-2px);
                    }
                </style>
            </head>
            <body>
                <button class="blehhh-btn" id="blehhh-btn">blehhh</button>
                <button class="back-btn" onclick="location.href='/Yas'">Back</button>

                <script>
                    const btn = document.getElementById('blehhh-btn');

                    btn.addEventListener('click', () => {
                        // rumble the whole page
                        document.body.classList.remove('rumbling');
                        void document.body.offsetWidth; // force reflow so animation restarts
                        document.body.classList.add('rumbling');

                        // vibrate on mobile
                        if (navigator.vibrate) navigator.vibrate([100, 50, 100]);

                        document.body.addEventListener('animationend', () => {
                            document.body.classList.remove('rumbling');
                        }, { once: true });
                    });
                </script>
            </body>
            </html>
            """, "text/html");
        });
    }
}