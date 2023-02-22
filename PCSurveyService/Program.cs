using PC.AccessLayer.Services.IServices;
using PCSurveyService;
using Microsoft.Extensions.Hosting;
using PC.AccessLayer.Survey;

var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureServices(services =>
{
    services.AddHostedService<Worker>();
});

builder.UseWindowsService();
var app = builder.Build();
app.Run();

//IHost host = Host.CreateDefaultBuilder(args)
//    .ConfigureServices(services =>
//    {
//        services.AddHostedService<Worker>();
//        //services.AddHttpClient("soldier", c =>
//        //{
//        //    c.BaseAddress = new Uri(Configuration.GetValue<string>("AppSetting:EmpDataApiUrl"));
//        //});
//        //SurveyManager.Configure(services.<ISurveyUnitofWork>(),
//        //    services.AddHttpClient<ISendService, SendService>());
//        //services.AddTransient<ISurveyUnitofWork, SurveyUnitofWork>();
//        //services.AddHostedService<SurveyManager>();
//        //services.AddHttpClient<ISendService, SendService>();
//    })
//    .UseWindowsService()
//    .Build();
//await host.RunAsync();

