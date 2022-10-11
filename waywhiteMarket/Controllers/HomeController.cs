using Microsoft.AspNetCore.Mvc;
using waywhiteMarket.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace waywhiteMarket.Controllers
{
    public class HomeController : Controller
    {
        private ProductDbContext _context;
        private string _path;
        

    public HomeController(ProductDbContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _path = $"{hostEnvironment.WebRootPath}\\product";
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string FAccount,string FPassword)
        {
            var member=_context.TMembers.FirstOrDefault(m=>m.FAccount==FAccount&&m.FPassword==FPassword);
            if (member != null)
            {            
                if (member != null && FAccount == "ahow")
                {
                    IList<Claim> claims = new List<Claim> {
                    new Claim(ClaimTypes.Name,member.FName),
                    new Claim(ClaimTypes.Role,member.FPower.ToString()),
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties { IsPersistent = true };
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(identity), authProperties);
                    TempData["good"] = "Succuseful";
                    return RedirectToAction("index", "Boss");//前參 動作方法  後參 控制器 
                }
                else
                {
                    IList<Claim> claims = new List<Claim> {
                    new Claim(ClaimTypes.Name,member.FName),
                    new Claim(ClaimTypes.Role,member.FPower.ToString()),
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties { IsPersistent = true };
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(identity), authProperties);
                    TempData["good"] = "Succuseful";
                    return RedirectToAction("index", "Member");//前參 動作方法  後參 控制器 
                }              
            }
            TempData["bad"] = "帳密錯誤 或是 尚未註冊";
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(TMember member)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    member.FPower = 1;
                    _context.TMembers.Add(member);
                    _context.SaveChanges();
                    ViewBag.state = "Hello";
                    return RedirectToAction("about");
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "帳號已有重複 請重新輸入" ;
                }
            }
            return View(member);           
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("index");
        }

        public IActionResult All()
        {
            return View();
        }
        public IActionResult Top()
        {
            return View();
        }
        public IActionResult Pant()
        {
            return View();
        }
        public IActionResult Coat()
        {
            return View();
        }




















    }
}
