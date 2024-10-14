using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ASPnetcoreapp.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ASPnetcoreappContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ASPnetcoreappContext") ?? throw new InvalidOperationException("Connection string 'ASPnetcoreappContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
