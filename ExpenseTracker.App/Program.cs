using ExpenseTracker.Infrastructure;
using ExpenseTracker.Business;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ExpenseTracker.Core.Constants;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var configuration = builder.Configuration;

//Register layers dependencies
builder.Services.RegisterInfrastructureServices(configuration);
builder.Services.RegisterBusinessServices();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cache
builder.Services.AddDistributedMemoryCache();

//Register HttpClients
builder.Services.AddHttpClient(HttpClientsNames.MarketClient, (provider, client) =>
{
    client.BaseAddress = new(configuration["Integrations:MarketApiBaseUrl"]!);
});

//Register session
builder.Services.AddSession();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Add session
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
