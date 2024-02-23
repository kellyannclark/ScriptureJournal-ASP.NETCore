using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register the DbContext with dependency injection
builder.Services.AddDbContext<MyScriptureJournalContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MyScriptureJournalContext")));

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
