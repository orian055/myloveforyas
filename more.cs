public static class MorePage
{
    public static void MapMorePage(this WebApplication app)
    {
        app.MapGet("/more", () =>
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
                    .button-row {
                        display: grid;
                        grid-template-columns: repeat(2, minmax(0, 1fr));
                        gap: 16px;
                        margin: 28px 0 0;
                    }
                    .action-btn {
                        padding: 16px 20px;
                        border-radius: 20px;
                        border: 1px solid rgba(255, 255, 255, 0.18);
                        background: linear-gradient(135deg, rgba(255, 109, 208, 0.18), rgba(255, 255, 255, 0.05));
                        color: #ffe4ff;
                        font-weight: 700;
                        letter-spacing: 0.02em;
                        transition: transform 0.2s ease, box-shadow 0.2s ease, background 0.2s ease;
                        cursor: pointer;
                    }
                    .action-btn:hover {
                        transform: translateY(-2px);
                        box-shadow: 0 18px 40px rgba(186, 80, 187, 0.24);
                        background: linear-gradient(135deg, rgba(238, 132, 232, 0.32), rgba(255, 255, 255, 0.12));
                    }
                    .back-btn { margin-top: 32px; padding: 14px 18px; border-radius: 999px; border: 1px solid rgba(255,255,255,0.18); background: rgba(255,255,255,0.08); color: #ffd6ff; cursor: pointer; }
                </style>
            </head>
            <body>
                <div class="page-container">
                    <div class="card">
                        <h1>I Love You More!</h1>
                        <p>What do you think about that?</p>
                        <div class="button-row">
                            <button class="action-btn" onclick="location.href='/noilym'">NO, I love you more!</button>
                            <button class="action-btn" onclick="location.href='/ngu'">I give up</button>
                            <button class="action-btn" onclick="alert('BLEHHH')">BLEHHH</button>
                            <button class="action-btn" onclick="alert('Hello')">Hello</button>
                        </div>
                        <button class="back-btn" onclick="location.href='/Yas'">Back</button>
                    </div>
                </div>
            </body>
            </html>
            """, "text/html");
        });
    }
}