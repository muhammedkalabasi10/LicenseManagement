using LicenseManagement.Models;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NarposmainlicensedbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("SwaggerApi", new OpenApiInfo
    {
        Version = "v1",
        Title = "Licence API",
        Description = "Lisans bilgilerini yönetmek ve þekillendirmek için API"
    });
});

builder.Services.AddCors(options => options.AddPolicy(name: "LicenseManagementOrigins",
    policy => { policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader(); }));


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseCors("LicenseManagementOrigins");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/SwaggerApi/swagger.json", "Swagger API");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
