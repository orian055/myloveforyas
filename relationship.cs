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
                <meta name="viewport" content="width=device-width, initial-scale=1.0">
                <link href="https://fonts.googleapis.com/css2?family=Playfair+Display:ital,wght@0,400;0,700;0,900;1,400;1,700&family=Cormorant+Garamond:ital,wght@0,300;0,400;0,600;1,300;1,400&family=Dancing+Script:wght@600;700&display=swap" rel="stylesheet">
                <style>
                    :root {
                        --rose:#e8406a; --rose-light:#ff7096;
                        --gold:#d4a843; --gold-light:#f0c96a;
                        --cream:#fff5f7; --deep:#1a0610; --soft-pink:#f9c4d4;
                    }
                    *{box-sizing:border-box;margin:0;padding:0;}
                    body{
                        min-height:100vh;min-height:100dvh;
                        font-family:'Cormorant Garamond',serif;
                        background:
                            radial-gradient(ellipse at 15% 25%,rgba(158,26,58,0.28) 0%,transparent 50%),
                            radial-gradient(ellipse at 85% 75%,rgba(74,14,32,0.35) 0%,transparent 45%),
                            linear-gradient(160deg,#1a0610 0%,#2d0a1a 40%,#1a0610 100%);
                        color:var(--cream);overflow-x:hidden;
                    }
                    .petal{position:fixed;pointer-events:none;animation:petalFall linear infinite;z-index:0;opacity:0.4;}
                    @keyframes petalFall{0%{transform:translateY(-40px) rotate(0deg);opacity:0.5;}100%{transform:translateY(105vh) rotate(540deg) translateX(25px);opacity:0;}}
                    .page-wrap{
                        min-height:100vh;min-height:100dvh;
                        display:flex;align-items:center;justify-content:center;
                        padding:28px 16px;position:relative;z-index:1;
                    }
                    .card{
                        width:min(680px,100%);
                        padding:48px 44px 40px;border-radius:4px;
                        background:rgba(22,5,14,0.88);
                        border:1px solid rgba(212,168,67,0.2);
                        box-shadow:0 50px 120px rgba(0,0,0,0.6),inset 0 1px 0 rgba(212,168,67,0.12);
                        backdrop-filter:blur(28px);text-align:center;position:relative;overflow:hidden;
                        animation:cardIn 0.8s ease forwards;
                    }
                    @keyframes cardIn{from{opacity:0;transform:translateY(40px);}to{opacity:1;transform:translateY(0);}}
                    .card::before{
                        content:'';position:absolute;top:0;left:0;right:0;height:2px;
                        background:linear-gradient(90deg,transparent,var(--gold),var(--rose-light),var(--gold),transparent);
                        background-size:200% 100%;animation:shimmer 3s linear infinite;
                    }
                    @keyframes shimmer{from{background-position:200% 0;}to{background-position:-200% 0;}}
                    .eyebrow{font-family:'Dancing Script',cursive;font-size:1.2rem;color:var(--gold-light);letter-spacing:0.08em;margin-bottom:8px;opacity:0;animation:slideUp 0.7s ease 0.2s forwards;}
                    h1{font-family:'Playfair Display',serif;font-size:clamp(1.8rem,4.5vw,3rem);font-weight:700;color:var(--cream);letter-spacing:-0.02em;line-height:1.1;opacity:0;animation:slideUp 0.7s ease 0.35s forwards;}
                    h1 em{font-style:italic;color:var(--rose-light);}
                    .gold-line{width:0;height:1px;background:linear-gradient(90deg,transparent,var(--gold),transparent);margin:14px auto;animation:expandLine 1s ease 0.8s forwards;}
                    @keyframes expandLine{to{width:100px;}}
                    .sub{font-size:1rem;color:rgba(249,196,212,0.7);font-style:italic;font-weight:300;margin-bottom:28px;opacity:0;animation:slideUp 0.7s ease 0.5s forwards;}
                    .time-grid{display:grid;grid-template-columns:repeat(2,1fr);gap:12px;margin-bottom:24px;opacity:0;animation:slideUp 0.7s ease 0.65s forwards;}
                    .time-unit{
                        padding:24px 12px 18px;
                        background:rgba(255,255,255,0.025);border:1px solid rgba(212,168,67,0.12);
                        border-radius:4px;position:relative;overflow:hidden;
                        transition:border-color 0.3s,transform 0.3s;
                    }
                    .time-unit:hover{border-color:rgba(212,168,67,0.3);transform:translateY(-2px);}
                    .time-unit::before{content:'';position:absolute;inset:0;background:radial-gradient(circle at 50% 0%,rgba(232,64,106,0.07),transparent 70%);pointer-events:none;}
                    .time-value{
                        font-family:'Playfair Display',serif;font-size:clamp(2rem,6vw,3rem);
                        font-weight:900;color:var(--soft-pink);line-height:1;display:block;
                        text-shadow:0 0 30px rgba(255,112,150,0.3);
                        animation:pulse 2s ease-in-out infinite;
                    }
                    .time-unit:nth-child(2) .time-value{animation-delay:0.5s;}
                    .time-unit:nth-child(3) .time-value{animation-delay:1s;}
                    .time-unit:nth-child(4) .time-value{animation-delay:1.5s;}
                    @keyframes pulse{0%,100%{text-shadow:0 0 30px rgba(255,112,150,0.3);}50%{text-shadow:0 0 50px rgba(255,112,150,0.6);}}
                    .time-label{font-size:0.7rem;color:rgba(212,168,67,0.55);letter-spacing:0.18em;text-transform:uppercase;margin-top:8px;display:block;font-family:'Cormorant Garamond',serif;}
                    .love-note{font-family:'Dancing Script',cursive;font-size:1.3rem;color:var(--gold-light);margin:4px 0 0;opacity:0;animation:slideUp 0.7s ease 0.9s forwards;}
                    .back-btn{
                        margin-top:28px;padding:12px 32px;border-radius:2px;
                        border:1px solid rgba(212,168,67,0.3);background:transparent;color:var(--gold-light);
                        font-family:'Cormorant Garamond',serif;font-size:0.95rem;font-style:italic;letter-spacing:0.1em;
                        cursor:pointer;transition:all 0.3s ease;opacity:0;animation:slideUp 0.7s ease 1.1s forwards;
                        -webkit-tap-highlight-color:transparent;
                    }
                    .back-btn:hover{border-color:var(--gold);color:var(--cream);background:rgba(212,168,67,0.08);transform:translateY(-2px);}
                    @keyframes slideUp{from{opacity:0;transform:translateY(20px);}to{opacity:1;transform:translateY(0);}}
                    @media(max-width:400px){
                        .card{padding:32px 16px 28px;}
                        .time-grid{gap:8px;}
                        .time-unit{padding:18px 8px 14px;}
                    }
                </style>
            </head>
            <body>
                <div id="petals"></div>
                <div class="page-wrap">
                    <div class="card">
                        <div class="eyebrow">&#8212; cool update righttt??? &#8212;</div>
                        <h1>Together Since<br><em>February 16, 2026</em></h1>
                        <div class="gold-line"></div>
                        <p class="sub">Until forever.</p>
                        <div class="time-grid">
                            <div class="time-unit"><span class="time-value" id="days">0</span><span class="time-label">Days</span></div>
                            <div class="time-unit"><span class="time-value" id="hours">0</span><span class="time-label">Hours</span></div>
                            <div class="time-unit"><span class="time-value" id="minutes">0</span><span class="time-label">Minutes</span></div>
                            <div class="time-unit"><span class="time-value" id="seconds">0</span><span class="time-label">Seconds</span></div>
                        </div>
                        <p class="love-note">&#9825; and every one was worth it &#9825;</p>
                        <br>
                        <button class="back-btn" onclick="location.href='/Yas'">&#8592; return home</button>
                    </div>
                </div>
                <script>
                    function updateTimer(){
                        const s=new Date(2026,1,16,0,0,0),n=new Date(),d=n-s;
                        document.getElementById('days').textContent=Math.floor(d/86400000)+1;
                        document.getElementById('hours').textContent=Math.floor((d%86400000)/3600000);
                        document.getElementById('minutes').textContent=Math.floor((d%3600000)/60000);
                        document.getElementById('seconds').textContent=Math.floor((d%60000)/1000);
                    }
                    updateTimer();setInterval(updateTimer,1000);
                    const pc=document.getElementById('petals');
                    const ps=['\u2665','\u2661','\u2764','\u273F'];
                    const col=['#e8406a','#d4a843','#ff7096'];
                    function sp(){
                        const p=document.createElement('div');p.className='petal';
                        p.textContent=ps[Math.floor(Math.random()*ps.length)];
                        p.style.left=Math.random()*100+'vw';
                        p.style.color=col[Math.floor(Math.random()*col.length)];
                        p.style.fontSize=(0.7+Math.random()*1.1)+'rem';
                        p.style.animationDuration=(7+Math.random()*9)+'s';
                        p.style.animationDelay=(Math.random()*3)+'s';
                        pc.appendChild(p);setTimeout(()=>p.remove(),16000);
                    }
                    setInterval(sp,1200);for(let i=0;i<6;i++)setTimeout(sp,i*350);
                </script>
            </body>
            </html>
            """, "text/html", System.Text.Encoding.UTF8);
        });
    }
}