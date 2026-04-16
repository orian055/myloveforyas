public static class NoIlymPage
{
    public static void MapNoIlymPage(this WebApplication app)
    {
        app.MapGet("/noilym", () =>
        {
            return Results.Content("""
            <html>
            <head>       
            </head>
            <body>
                <div class="page-container">
                </div>
            </body>
            </html>
            """, "text/html");
        });
    }
}
