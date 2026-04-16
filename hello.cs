public static class HelloPage
{
    public static void MapHelloPage(this WebApplication app)
    {
        app.MapGet("/hello", () =>
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
                        overflow: hidden;
                    }
                    .card {
                        width: min(700px, 100%);
                        padding: 52px 44px;
                        border-radius: 36px;
                        background: rgba(30, 9, 43, 0.9);
                        border: 1px solid rgba(255,255,255,0.12);
                        box-shadow: 0 28px 90px rgba(0,0,0,0.35);
                        text-align: center;
                        position: relative;
                        overflow: hidden;
                    }
                    .card::before {
                        content: '';
                        position: absolute;
                        inset: 0;
                        background: radial-gradient(circle at 50% 0%, rgba(255, 100, 180, 0.12), transparent 60%);
                        pointer-events: none;
                    }
                    h1 {
                        margin: 0 0 24px;
                        font-size: clamp(3.5rem, 7vw, 6rem);
                        color: #ffd0f8;
                        letter-spacing: -0.03em;
                        text-shadow: 0 20px 55px rgba(116, 15, 72, 0.5);
                        animation: glow 2.5s ease-in-out infinite;
                    }
                    @keyframes glow {
                        0%, 100% { text-shadow: 0 20px 55px rgba(116, 15, 72, 0.5); }
                        50% { text-shadow: 0 20px 80px rgba(255, 100, 180, 0.7); }
                    }
                    p {
                        font-size: 1.2rem;
                        line-height: 2;
                        color: rgba(255,210,245,0.94);
                        margin: 0 0 8px;
                        position: relative;
                    }
                    .highlight { color: #ffb0dd; font-weight: 700; }
                    .hearts {
                        font-size: 2rem;
                        letter-spacing: 8px;
                        margin: 20px 0;
                        animation: pulse 1.6s ease-in-out infinite;
                        display: block;
                    }
                    @keyframes pulse {
                        0%, 100% { transform: scale(1); opacity: 1; }
                        50% { transform: scale(1.15); opacity: 0.85; }
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
                    <h1>Helloww</h1>
                    <p>i madee a whole website</p>
                    <p>just to say <span class="highlight">i love you</span>.</p>
                    <p>btw youre pretty cute.</p>
                    <p><span class="highlight">I LOVE YOUUU</span></p>
                    <button class="back-btn" onclick="location.href='/Yas'">Back</button>
                </div>
            </body>
            </html>
            """, "text/html");
        });
    }
}