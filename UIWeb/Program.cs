using Autofac;
using Business.DependencyAutoFact;
using Autofac.Extensions.DependencyInjection;
using Business.AutoMapping;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Business.FluentValidations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(AutoProfile));
builder.Services.AddControllersWithViews().AddFluentValidation(s=>s.RegisterValidatorsFromAssemblyContaining<FluentCategoriesProject>());//DataAccessin içinden bu Fluente ulaþýr bu dizindeki diðer fluentleri de çalýþtýrýr.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(x => x.RegisterModule(new AutoFactModule()));
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();

#region User Login için Gerekli Olan Ayarlamalar.

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Login";
    x.LogoutPath = "/admin/Cikis";
    x.AccessDeniedPath = "/admin/YetkisizGiris";
});
#endregion


var app = builder.Build();
app.UseRouting();
app.UseSession();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(x =>
{
    // Proje içerisinde URL Yapýlarý yazýlýmcý tarafýndan deðiþtirilmediði sürece Varsayýlan Mantýkla çalýþacaðýný belirten ayarlamalardýr.

    // ilk siteye girildiðinde Açýlacak sayfayý belirtmemizi saðlýyor (Home/Index)
    x.MapDefaultControllerRoute();

    // Admin Paneline Girecek arkadaþlarýn siteadresi.com/admin Yazýcýnca gelecek ekraný belirtmemizi saðlar.
    x.MapControllerRoute(
          name: "areas",
          pattern: "{area:exists}/{controller=Login}/{action=Index}/{id?}"
        );
});

app.Run();
