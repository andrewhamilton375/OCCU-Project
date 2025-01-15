using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using OCCU_Assessment.Data;
using OCCU_Assessment.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register user-defined services
builder.Services.AddSingleton<StatusService>();
builder.Services.AddSingleton<DataService>();

// Register SignalR
builder.Services.AddSignalR();

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
app.MapHub<StatusHub>("/statusHub");
app.MapFallbackToPage("/_Host");

app.Run();
