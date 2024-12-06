using PDA.Interceptor;
using PDA.Managers;
using PDA;
using Serilog;
using VAS_ZODIAC_Services.Response_Handler_Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Logging.AddSerilog(logger);

var connection = Environment.GetEnvironmentVariable("PDAConnection", EnvironmentVariableTarget.User);
builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer(connection!));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
//var truckerConnection = Environment.GetEnvironmentVariable("VAS_ZODIAC", EnvironmentVariableTarget.Machine);
//builder.Services.AddDbContext<UserContext>(options =>
//options.UseSqlServer(truckerConnection!));

builder.Services.AddScoped<IInterceptorService, InterceptorService>();
builder.Services.AddScoped<IResponseHandlerService, ResponseHandlerService>();

builder.Services.AddScoped<IUserManager, UserManager>();

builder.Services.AddScoped<IMailService, MailService>();



builder.Services.AddHttpContextAccessor();
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
app.UseDeveloperExceptionPage();

app.UseRouting();
app.UseSession();
//app.UseFastReport();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();
