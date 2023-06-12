using MagicPlaces_WEB;
using MagicPlaces_WEB.Services;
using MagicPlaces_WEB.Services.IServices;
using MagicPlaces_WEB.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddScoped<IPlacesService, PlacesService>();
builder.Services.AddHttpClient();
builder.Services.Configure<ServicesUrlsConfig>(options => builder.Configuration.GetSection("ServiceUrls").Bind(options)); // Descomente esta linha

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
