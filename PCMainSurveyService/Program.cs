using PC.AccessLayer.Services.IServices;
using PC.Repository.SurveyUnitOfWork;
using PCMainSurveyService.SurveyService;
using Microsoft.OpenApi.Models;
using PC.DataLayer.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

SD.SendSmsAPIBase = builder.Configuration.GetValue<string>("Survey:NotificationServiceApiLink");//"http://localhost:5256";
builder.Services.AddControllers();

builder.Services.AddEntityFrameworkSqlServer();
builder.Services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("ServiceDBConnection")));
builder.Services.AddTransient<ISurveyUnitofWork, SurveyUnitofWork>();
builder.Services.AddScoped<ISendService, SendService>();
builder.Services.AddHttpClient<SendService>();

builder.Services.AddHostedService<SurveyServiceWorker>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProCare.Services.SurveySMS", Version = "v1" });
    c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
