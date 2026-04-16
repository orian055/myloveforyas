public static class RelationshipPage
{
    public static void MapRelationshipPage(this WebApplication app)
    {
        app.MapGet("/relationship", () =>
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
                        padding: 52px 48px 40px;
                        border-radius: 32px;
                        background: rgba(30, 9, 43, 0.88);
                        border: 1px solid rgba(255,255,255,0.12);
                        box-shadow: 0 30px 80px rgba(0, 0, 0, 0.38);
                        text-align: center;
                        color: #ffd0f8;
                    }
                    h1 { margin: 0 0 16px; font-size: clamp(2.8rem, 5vw, 4.2rem); letter-spacing: -0.02em; }
                    .subtitle { font-size: 1.15rem; color: rgba(255,210,245,0.88); margin-bottom: 32px; }
                    .time-display {
                        display: grid;
                        grid-template-columns: 1fr 1fr;
                        gap: 16px;
                        margin: 28px 0 32px;
                    }
                    .time-unit {
                        padding: 20px 16px;
                        background: rgba(255, 255, 255, 0.06);
                        border: 1px solid rgba(255,255,255,0.1);
                        border-radius: 16px;
                    }
                    .time-value { font-size: 2.2rem; font-weight: 700; color: #ffb2e7; }
                    .time-label { font-size: 0.9rem; color: rgba(255,210,245,0.7); margin-top: 6px; text-transform: uppercase; letter-spacing: 0.05em; }
                    .back-btn {
                        margin-top: 28px;
                        padding: 14px 24px;
                        border-radius: 999px;
                        border: 1px solid rgba(255,255,255,0.18);
                        background: rgba(255,255,255,0.08);
                        color: #ffd6ff;
                        cursor: pointer;
                        font-weight: 600;
                        transition: all 0.25s ease;
                    }
                    .back-btn:hover {
                        background: rgba(255,255,255,0.14);
                        transform: translateY(-2px);
                    }
                </style>
            </head>
            <body>
                <div class="page-container">
                    <div class="card">
                        <h1>Since Feb 16, 2026</h1>
                        <p class="subtitle">We've been together for</p>
                        <div class="time-display">
                            <div class="time-unit">
                                <div class="time-value" id="days">0</div>
                                <div class="time-label">Days</div>
                            </div>
                            <div class="time-unit">
                                <div class="time-value" id="hours">0</div>
                                <div class="time-label">Hours</div>
                            </div>
                            <div class="time-unit">
                                <div class="time-value" id="minutes">0</div>
                                <div class="time-label">Minutes</div>
                            </div>
                            <div class="time-unit">
                                <div class="time-value" id="seconds">0</div>
                                <div class="time-label">Seconds</div>
                            </div>
                        </div>
                        <button class="back-btn" onclick="location.href='/Yas'">Back</button>
                    </div>
                </div>
                <script>
                    function updateTimer() {
                        const startDate = new Date(2026, 1, 16, 0, 0, 0);
                        const now = new Date();
                        const diff = now - startDate;
                        
                        const days = Math.floor(diff / (1000 * 60 * 60 * 24)) + 1;
                        const hours = Math.floor((diff % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
                        const minutes = Math.floor((diff % (1000 * 60 * 60)) / (1000 * 60));
                        const seconds = Math.floor((diff % (1000 * 60)) / 1000);
                        
                        document.getElementById('days').textContent = days;
                        document.getElementById('hours').textContent = hours;
                        document.getElementById('minutes').textContent = minutes;
                        document.getElementById('seconds').textContent = seconds;
                    }
                    
                    updateTimer();
                    setInterval(updateTimer, 1000);
                </script>
            </body>
            </html>
            """, "text/html");
        });
    }
}
