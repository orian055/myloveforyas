public static class NoIlymPage
{
    public static void MapNoIlymPage(this WebApplication app)
    {
        app.MapGet("/noilym", () =>
        {
            return Results.Content("""
            <html>
            <head>
                <style>
                    * {
                        box-sizing: border-box;
                    }
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
                        overflow-x: hidden;
                    }
                    .page-container {
                        text-align: center;
                        padding: 40px 20px;
                    }
                    h1 {
                        font-size: 3rem;
                        margin-bottom: 40px;
                        color: #ff8bc1;
                        text-shadow: 0 4px 20px rgba(255, 139, 193, 0.3);
                        letter-spacing: 0.05em;
                    }
                    .button-group {
                        display: flex;
                        gap: 20px;
                        justify-content: center;
                        flex-wrap: wrap;
                    }
                    button {
                        padding: 16px 40px;
                        font-size: 1.1rem;
                        font-weight: 600;
                        border-radius: 999px;
                        border: 2px solid rgba(255, 255, 255, 0.2);
                        background: rgba(255, 255, 255, 0.1);
                        color: #ffd6ff;
                        cursor: pointer;
                        transition: all 0.3s ease;
                        box-shadow: 0 10px 30px rgba(207, 53, 135, 0.2);
                        backdrop-filter: blur(10px);
                    }
                    button:hover {
                        background: rgba(255, 139, 193, 0.25);
                        border-color: rgba(255, 139, 193, 0.5);
                        transform: translateY(-3px);
                        box-shadow: 0 15px 40px rgba(207, 53, 135, 0.4);
                    }
                    button:active {
                        transform: translateY(-1px);
                    }
                    .yasmin-btn {
                        cursor: not-allowed;
                        opacity: 0.7;
                    }
                    .yasmin-btn:hover {
                        background: rgba(255, 255, 255, 0.1);
                        border-color: rgba(255, 255, 255, 0.2);
                        transform: none;
                    }
                </style>
            </head>
            <body>
                <div class="page-container">
                    <h1>Who loves more?</h1>
                    <div class="button-group">
                        <button onclick="location.href='/Yas'">Orian</button>
                        <button class="yasmin-btn">Yasmin</button>
                    </div>
                </div>
            </body>
            </html>
            """, "text/html");
        });
    }
}
