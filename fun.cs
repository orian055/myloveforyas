public static class FunPage
{
    public static void MapFunPage(this WebApplication app)
    {
        app.MapGet("/fun", () =>
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
                        background: linear-gradient(135deg, #30042d 0%, #461362 45%, #a11d7d 100%);
                        overflow-x: hidden;
                    }
                    .page-container {
                        min-height: 100vh;
                        display: flex;
                        align-items: center;
                        justify-content: center;
                        padding: 40px;
                    }
                    .card {
                        width: min(720px, 100%);
                        padding: 44px 44px 32px;
                        border-radius: 32px;
                        background: rgba(30, 9, 43, 0.88);
                        border: 1px solid rgba(255,255,255,0.12);
                        box-shadow: 0 30px 80px rgba(0, 0, 0, 0.38);
                        text-align: center;
                        color: #ffd0f8;
                    }
                    h1 { margin-top: 0; font-size: clamp(3rem, 5vw, 4.4rem); }
                    p { font-size: 1.1rem; line-height: 1.8; color: rgba(255,210,245,0.94); }
                    .emoji { font-size: 4rem; margin: 24px 0; }
                    .back-btn { margin-top: 32px; padding: 14px 18px; border-radius: 999px; border: 1px solid rgba(255,255,255,0.18); background: rgba(255,255,255,0.08); color: #ffd6ff; cursor: pointer; }
                </style>
            </head>
            <body>
                <div class="page-container">
                    <div class="card">
                        <h1>Just For Fun</h1>
                        <p>Coming soon!.</p>
                        <div class="emoji">hey</div>
                        <button class="back-btn" onclick="location.href='/Yas'">Back</button>
                    </div>
                </div>
            </body>
            </html>
            """, "text/html");
        });
    }
}