using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PC.AccessLayer;
using PC.AccessLayer.Services.IServices;
using PC.DataLayer.DbContexts;
using PC.Repository.SurveyUnitOfWork;

var builder = Host.CreateDefaultBuilder(args);
SD.SendSmsAPIBase = "http://localhost:5256";
builder.ConfigureServices(services =>
{
    services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(@"Server = MUSSAB\SQLEXPRESS; Database = PCSurveyDB; Trusted_Connection = true; MultipleActiveResultSets = true"));

    services.AddTransient<ISurveyUnitofWork, SurveyUnitofWork>();
    services.AddHttpClient<ISendService, SendService>();
});

var app = builder.Build();
await app.RunAsync();

//SD.SendSmsAPIBase = "http://localhost:5256";
//IHost host = Host.CreateDefaultBuilder(args)
//    .ConfigureServices(services =>
//    {
//        services.AddDbContext<ApplicationDbContext>(options =>
//                       options.UseSqlServer(@"Server = MUSSAB\SQLEXPRESS; Database = PCSurveyDB; Trusted_Connection = true; MultipleActiveResultSets = true"));
//        // Add builder.Services to the container.
//        //IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
//        //builder.Services.AddSingleton(mapper);
//        //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//        services.AddTransient<ISurveyUnitofWork, SurveyUnitofWork>();
//        services.AddHttpClient<ISendService, SendService>();
//    })
//    .Build();

//await host.RunAsync();
