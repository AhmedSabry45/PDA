using PDA.Managers;
using PDA.Models;
using PDA.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;

using System.Collections;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Security.Cryptography;
using PDA.Interceptor;


namespace PDA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly IUserManager _userManager;
        private readonly IInterceptorService _interceptorService;
        private string _connectionString;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMailService _mailService;
        static bool isCreateInvoice = false;
        private readonly string _username;
        string InvoiceDownloadUrl = "";
        public HomeController(ILogger<HomeController> logger, IMailService mailService, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IInterceptorService interceptorService, IUserManager userManager, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _configuration = configuration;
     
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
            _interceptorService = interceptorService;
            _mailService = mailService;
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            //_connectionString = configuration.GetConnectionString("TFusionConnection");
           // _connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=ZODIAC-SCAN.DPWSAPPS.COM)(PORT=1521))(CONNECT_DATA=(service_name= TOSEDB)));User Id=FUSION;Password=Welcome@1;";//Environment.GetEnvironmentVariable("TFusionConnection",EnvironmentVariableTarget.Machine);
            _username = httpContextAccessor.HttpContext?.Session.GetString("userName") ?? string.Empty;
            InvoiceDownloadUrl = configuration["InvoiceDownloadUrl"];
        }
        public IActionResult search()
        {
            //if (HttpContext.Session.GetString("userName") is null)
            //{
            //    TempData["LoginExpired"] = "you should login at first!";
            //    return RedirectToAction("Login", "User");
            //}
            return View();
        }


       






    

     







    }
}