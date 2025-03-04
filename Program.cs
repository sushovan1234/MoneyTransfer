using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoneyTransfer.Models;
using MoneyTransfer.Services.Interface;
using MoneyTransfer.Services.Service;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MoneyTransfer.Data_Access.AppContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddIdentity<User,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MoneyTransfer.Data_Access.AppContext>().AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

   
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Login/Login";
    //options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    //options.SlidingExpiration = true;
});
builder.Services.AddTransient<IEmailSenderService, EmailSender>();
builder.Services.AddTransient<IApiService,ApiService>();
builder.Services.AddScoped<IBankDetails, MoneyTransfer.Services.Service.BankDetails>();
builder.Services.AddScoped<IBankAccount, MoneyTransfer.Services.Service.BankAccount>();
builder.Services.AddScoped<ITransactionDetails, MoneyTransfer.Services.Service.TransactionDetails>();
// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
