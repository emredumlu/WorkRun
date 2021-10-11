namespace WorkRun.Service
{
    public static class SeviceExtension
    {
        public static void WorkMiddleware(this WebApplication app)
        {
            app.MapWhen(context => context.Request.Path == "/emre" & context.Request.Query["w"] == "3", builder =>
            {
                builder.Run(async c =>
                {
                    await c.Response.WriteAsync("Emre Dumlu");
                });
            });
        }

        public static void ImgMiddleware(this WebApplication app)
        {
            app.MapWhen(context => context.Request.Path == "/img1", builder =>
            {
                builder.Run(async c =>
                {
                    c.Response.Clear();
                    var imgBuffer = File.ReadAllBytes("img.jpg");
                    c.Response.ContentType = "image";
                    await c.Response.BodyWriter.WriteAsync(imgBuffer);
                });
            });

            app.MapWhen(context => context.Request.Path == "/img2", builder =>
            {
                builder.Run(async c =>
                {
                    c.Response.Clear();
                    var imgBuffer = File.ReadAllBytes("img2.jpg");
                    c.Response.ContentType = "image";
                    await c.Response.BodyWriter.WriteAsync(imgBuffer);
                });
            });
        }
    }
}
