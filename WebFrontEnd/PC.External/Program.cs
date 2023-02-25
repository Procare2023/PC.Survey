using Microsoft.EntityFrameworkCore;
using PC.DataLayer.DbContexts;
using PC.Repository.SurveyUnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc()
    .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddControllersWithViews().AddDataAnnotationsLocalization();

builder.Services.AddEntityFrameworkSqlServer();
builder.Services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("ServiceDBConnection")));
builder.Services.AddTransient<ISurveyUnitofWork, SurveyUnitofWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

var supportedCulture = new[] { "en-US", "ar-SA" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCulture[0])
    .AddSupportedCultures(supportedCulture)
    .AddSupportedUICultures(supportedCulture);

app.UseRequestLocalization(localizationOptions);

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{culture=en-US}");

app.Run();
