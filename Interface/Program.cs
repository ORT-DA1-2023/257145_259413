using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Domain;
using Interface.BusinessLogic;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<Manager>();


string connectionStringIgnacio = "Data Source=LAPTOP-3R9PVFHT;Initial Catalog=BaseDatosObligatorio;Integrated Security=True;TrustServerCertificate=true;";
string connectionStringPablo = "Data Source=DESKTOP-G58UOLC;Initial Catalog=BaseDatosObligatorio;Integrated Security=True;TrustServerCertificate=true;";


//string connectionString = connectionStringIgnacio;
string connectionString = connectionStringPablo;

builder.Services.AddDbContextFactory<ApplicationContext>(
	   options => options.UseSqlServer(
		   connectionString,
		   providerOptions => providerOptions.EnableRetryOnFailure()
		   ));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
