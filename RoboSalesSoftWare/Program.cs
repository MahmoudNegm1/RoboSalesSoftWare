using BLL.RoboMind;
using BLL.RoboMind.AppServices;
using BLL.RoboMind.IAppServices;
using DAL.RoboSalesSoftWare.ApplicationDbContext;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using NToastNotify;
using System.Globalization;
using Microsoft.Extensions.Hosting;
using RoboSalesSoftWare.Models;

var builder = WebApplication.CreateBuilder(args);
//builder.WebHost.Configure(webHostBuilder =>
//{
//    webHostBuilder.UseContentRootPath(Path.Combine(Directory.GetCurrentDirectory(), "myContentRoot"));
//});



// Load configuration from appsettings.json
var configuration = new ConfigurationBuilder()
	.SetBasePath(builder.Environment.ContentRootPath)
	.AddJsonFile("appsettings.json")
	.Build();

// Register DatabaseConfig using configuration settings
builder.Services.Configure<DatabaseConfig>(configuration.GetSection("DatabaseConfig"));

// Other service registrations...
builder.Services.AddDbContext<AppDbContext>((provider, options) =>
{
	var config = provider.GetRequiredService<IOptions<DatabaseConfig>>().Value;
	options.UseSqlServer(config.GetConnectionString());
});
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddRazorRuntimeCompilation().AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();
builder.Services.Configure<RequestLocalizationOptions>(options => {
    var SupportedCulture = new[] {
        new CultureInfo("ar") ,
        new CultureInfo("en")
    };
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(culture: "en", uiCulture: "en");
    options.SupportedCultures = SupportedCulture;
    options.SupportedUICultures = SupportedCulture;
});
builder.Services.AddControllers(options =>
{
    options.ModelMetadataDetailsProviders.Add(new SystemTextJsonValidationMetadataProvider());
});

builder.Services.AddMvc().AddNToastNotifyToastr(new NToastNotify.ToastrOptions
{
    ProgressBar = true,
    PositionClass = ToastPositions.BottomLeft,
    PreventDuplicates = true,
    CloseButton = true,
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddDbContext<AppDbContext>(
//    options => options.UseSqlServer(
//        builder.Configuration.GetConnectionString("SalesDb")
//    )
//);
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IVegatablesTypeServices, VegatablesTypeServices>();
builder.Services.AddScoped<IReceiptServices, ReceiptServices>();
builder.Services.AddScoped<IMarketDataService, MarketDataService>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // app.UseExceptionHandler("/Home/Error");
}
try {using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;

	var context = services.GetRequiredService<AppDbContext>();
	context.Database.Migrate();

} } catch (Exception ex) { }

app.UseStaticFiles();

app.UseRouting();
var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(localizationOptions.Value);


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=LogIn}/{id?}");

app.Run();
