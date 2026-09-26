using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using NotificationService.Data;
using NotificationService.SignalR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NotificationDbContext>(options =>
    options.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = NotificationDB; Trusted_Connection = True;"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();
builder.Services.AddScoped<NotificationManager>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy
            .WithOrigins("https://localhost:52191")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider
        .GetRequiredService<NotificationDbContext>();

    context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("ReactPolicy");

app.UseAuthorization();

app.MapControllers();

app.MapHub<NotificationHub>("/notificationHub");

app.Run();