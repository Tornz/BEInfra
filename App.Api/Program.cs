using App.Api;
using App.Application;
using App.Infrastructure;
using App.Api.Middleware;
using App.Api.Extensions.Authorization;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation(builder.Configuration)
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddCors(o => o.AddPolicy("default", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithExposedHeaders("WWW-Authenticate");
    }));
}

var app = builder.Build();
{  
    if (app.Environment.IsDevelopment())
    {
     
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseCors("default");
    app.UseHttpsRedirection();
    app.UseMyAuthorization();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}

