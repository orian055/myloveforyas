public static class NguPage
{
    public static void MapNguPage(this WebApplication app)
    {
        app.MapGet("/ngu", () =>
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
                        background: radial-gradient(circle at 15% 15%, rgba(255, 125, 195, 0.18), transparent 18%),
                                    radial-gradient(circle at 85% 25%, rgba(255, 95, 145, 0.24), transparent 22%),
                                    linear-gradient(135deg, #2f0035 0%, #4c125b 45%, #9c1f7b 100%);
                        display: flex;
                        align-items: center;
                        justify-content: center;
                        padding: 24px;
                    }
                    .page-container {
                        width: min(800px, 100%);
                        padding: 42px 40px;
                        border-radius: 36px;
                        background: rgba(30, 9, 43, 0.9);
                        border: 1px solid rgba(255,255,255,0.12);
                        box-shadow: 0 28px 90px rgba(0, 0, 0, 0.35);
                        text-align: center;
                        position: relative;
                        overflow: hidden;
                    }
                    .page-container::before {
                        content: '';
                        position: absolute;
                        inset: 0;
                        background: radial-gradient(circle at 20% 20%, rgba(255,255,255,0.08), transparent 16%),
                                    radial-gradient(circle at 80% 25%, rgba(255, 106, 191, 0.12), transparent 18%);
                        pointer-events: none;
                    }
                    .page-content {
                        position: relative;
                        z-index: 1;
                    }
                    h1 {
                        margin: 0 0 30px;
                        font-size: clamp(2.6rem, 5vw, 4.4rem);
                        line-height: 1.05;
                        letter-spacing: -0.03em;
                        color: #ffb0dd;
                        text-shadow: 0 16px 40px rgba(138, 28, 86, 0.4);
                        transition: font-size 0.25s ease, transform 0.25s ease;
                    }
                    .button-row {
                        display: flex;
                        justify-content: center;
                        gap: 18px;
                        flex-wrap: wrap;
                    }
                    button {
                        min-width: 180px;
                        padding: 16px 24px;
                        border-radius: 999px;
                        border: 1px solid rgba(255,255,255,0.18);
                        background: linear-gradient(135deg, rgba(255, 134, 211, 0.22), rgba(255, 255, 255, 0.08));
                        color: #ffe7ff;
                        font-size: 1rem;
                        font-weight: 700;
                        letter-spacing: 0.04em;
                        cursor: pointer;
                        transition: transform 0.2s ease, box-shadow 0.2s ease, background 0.2s ease;
                        box-shadow: 0 14px 32px rgba(177, 73, 154, 0.22);
                    }
                    button:hover {
                        transform: translateY(-2px);
                        box-shadow: 0 18px 42px rgba(177, 73, 154, 0.32);
                        background: linear-gradient(135deg, rgba(255, 152, 226, 0.28), rgba(255, 255, 255, 0.12));
                    }
                    .back-btn {
                        margin-top: 32px;
                        padding: 14px 26px;
                        border-radius: 999px;
                        border: 1px solid rgba(255,255,255,0.15);
                        background: rgba(255,255,255,0.08);
                        color: #ffd5ff;
                    }
                </style>
            </head>
            <body>
                <div class="page-container">
                    <div class="page-content">
                        <h1 id="challenge-text">never back down never what?</h1>
                        <div class="button-row">
                            <button id="challenge-btn">never give up</button>
                        </div>
                        <button class="back-btn" onclick="location.href='/Yas'">Back</button>
                    </div>
                </div>
                <script>
                    const challengeText = document.getElementById('challenge-text');
                    const challengeBtn = document.getElementById('challenge-btn');
                    let clickCount = 0;
                    const baseText = 'never back down never what';

                    challengeBtn.addEventListener('click', () => {
                        clickCount += 1;

                        if (clickCount < 3) {
                            const exclamations = '!'.repeat(clickCount);
                            challengeText.textContent = `${baseText}${exclamations}`;
                            challengeText.style.fontSize = `calc(2.8rem + ${clickCount * 0.8}rem)`;
                        } else if (clickCount === 3) {
                            challengeText.textContent = 'SO WHO LOVES MORE!';
                            challengeText.style.fontSize = 'clamp(3.6rem, 6vw, 5.6rem)';
                            challengeBtn.textContent = 'yasmin';
                        } else {
                            alert('ill consider this as an option');
                            location.href = '/Yas';
                        }
                    });
                </script>
            </body>
            </html>
            """, "text/html");
        });
    }
}
