using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;
using WebProje.Models;
using WebProje.Resources;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });

builder.Services.AddDbContext<HastaneContext>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
    options.LoginPath = "/Login/GirisYap";
    options.AccessDeniedPath = "/Login/Hata";
    //options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    }
);
builder.Services.AddSingleton<LocalizationService>();

builder.Services.AddMvc().AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix).
    AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
        {
            var assemblyName = new AssemblyName(typeof(ApplicationResource).GetTypeInfo().Assembly.FullName);
            return factory.Create("ApplicationResource", assemblyName.ToString());
        };
    });

builder.Services.Configure<RequestLocalizationOptions>(opt =>
{
    var cultures = new List<CultureInfo>()
    {
        new CultureInfo("en-US"),
        new CultureInfo("tr-TR")
    };
    opt.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(new CultureInfo("tr-TR"));
    opt.SupportedCultures = cultures;
    opt.SupportedUICultures = cultures;

    opt.RequestCultureProviders = new List<IRequestCultureProvider>()
    {
        new QueryStringRequestCultureProvider(),
        new CookieRequestCultureProvider(),
        new AcceptLanguageHeaderRequestCultureProvider()
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
if (options != null)
{
    app.UseRequestLocalization(options.Value);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Main}/{action=Anasayfa}/{id?}");

app.Run();
