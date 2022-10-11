using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using waywhiteMarket.Models;



var builder = WebApplication.CreateBuilder(args);
var cnstr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={builder.Environment.ContentRootPath}App_Data\\dbProduct.mdf;Integrated Security=True;Trusted_Connection=True;";
builder.Services.AddMvc();
builder.Services.AddDbContext<waywhiteMarket.Models.ProductDbContext>
    (options => options.UseSqlServer(cnstr));

//增加驗證方式 使用cookie驗證
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(Options =>
{
    //瀏覽器限制cookie只能經由https協定存取
    Options.Cookie.HttpOnly = true;
    //未登入時會自動導入燈入頁
    Options.LoginPath = new PathString("/Home/Index");
    //當權限不夠 跑到此路徑
    Options.AccessDeniedPath = new PathString("/Home/NoPower");

});
var app = builder.Build();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{Controller=Home}/{Action=Index}/{id?}"
    );

app.Run();
