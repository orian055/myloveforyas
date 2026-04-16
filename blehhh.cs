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
                        padding: 24px;
                    }
                    .card {
                        width: min(700px, 100%);
                        padding: 52px 44px;
                        border-radius: 36px;
                        background: rgba(30, 9, 43, 0.9);
                        border: 1px solid rgba(255,255,255,0.12);
                        box-shadow: 0 28px 90px rgba(0,0,0,0.35);
                        text-align: center;
                    }
                    h1 {
                        margin: 0 0 12px;
                        font-size: clamp(3rem, 6vw, 5rem);
                        color: #ffb0dd;
                        text-shadow: 0 16px 40px rgba(138, 28, 86, 0.4);
                    }
                    .emoji { font-size: 3.5rem; margin-bottom: 20px; display: block; animation: bounce 1.2s ease-in-out infinite; }
                    @keyframes bounce {
                        0%, 100% { transform: translateY(0); }
                        50% { transform: translateY(-12px); }
                    }
                    p {
                        font-size: 1.15rem;
                        line-height: 1.9;
                        color: rgba(255,210,245,0.94);
                        margin: 0 0 10px;
                    }
                    .highlight {
                        color: #ffb0dd;
                        font-weight: 700;
                    }
                    .back-btn {
                        margin-top: 32px;
                        padding: 14px 26px;
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
                        transform: translateY(-2px);
                    }
                </style>
            </head>
            <body>
                <div class="card">
                    <span class="emoji">🩷</span>
                    <h1>Blehhh.</h1>
                    <p>Yeah yeah blehhh.</p>
                    <p>But also — <span class="highlight">you're the cutest person alive.</span></p>
                    <p>The way you make that face.</p>
                    <p>The way you scrunch your nose.</p>
                    <p>The way you go "blehhh" like a little gremlin.</p>
                    <p><span class="highlight">I love every single version of you.</span></p>
                    <p>Even the blehhh one. <span class="highlight">Especially</span> the blehhh one.</p>
                    <button class="back-btn" onclick="location.href='/Yas'">Back 🩷</button>
                </div>
            </body>
            </html>
            """, "text/html");
        });
    }
}