using Autofac;
using Business.DependencyAutoFact;
using Autofac.Extensions.DependencyInjection;
using Business.AutoMapping;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Business.FluentValidations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(AutoProfile));
builder.Services.AddControllersWithViews().AddFluentValidation(s=>s.RegisterValidatorsFromAssemblyContaining<FluentCategoriesProject>());//DataAccessin i�inden bu Fluente ula��r bu dizindeki di�er fluentleri de �al��t�r�r.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(x => x.RegisterModule(new AutoFactModule()));
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();

#region User Login i�in Gerekli Olan Ayarlamalar.

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
    // Proje i�erisinde URL Yap�lar� yaz�l�mc� taraf�ndan de�i�tirilmedi�i s�rece Varsay�lan Mant�kla �al��aca��n� belirten ayarlamalard�r.

    // ilk siteye girildi�inde A��lacak sayfay� belirtmemizi sa�l�yor (Home/Index)
    x.MapDefaultControllerRoute();

    // Admin Paneline Girecek arkada�lar�n siteadresi.com/admin Yaz�c�nca gelecek ekran� belirtmemizi sa�lar.
    x.MapControllerRoute(
          name: "areas",
          pattern: "{area:exists}/{controller=Login}/{action=Index}/{id?}"
        );
});

app.Run();
