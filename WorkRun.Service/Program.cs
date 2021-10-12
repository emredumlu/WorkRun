using WorkRun.Service;

var builder = WebApplication.CreateBuilder(args);

IConfiguration Configuration = builder.Configuration;
ConfigureService(builder.Services);

var app = builder.Build();
Configure(app, builder.Environment);

static void ConfigureService(IServiceCollection services)
{
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
    app.UseRouting();

    app.UseEndpoints(routes =>
    {
        routes.MapControllers();
    });

    app.Run();
}
