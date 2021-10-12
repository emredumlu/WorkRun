using WorkRun.Service;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
IConfiguration Configuration = app.Configuration;
ConfigureService(builder.Services);
Configure(app, builder.Environment);

static void ConfigureService(IServiceCollection services)
{
    services.AddControllers(c =>
    {
        c.Filters.Add(new ServiceRunFilter());
    });
}

static void Configure(WebApplication app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseEndpoints(routes =>
    {
        routes.MapControllers();
    });
}
