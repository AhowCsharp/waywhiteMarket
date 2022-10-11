using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using waywhiteMarket.Models;



var builder = WebApplication.CreateBuilder(args);
var cnstr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={builder.Environment.ContentRootPath}App_Data\\dbProduct.mdf;Integrated Security=True;Trusted_Connection=True;";
builder.Services.AddMvc();
builder.Services.AddDbContext<waywhiteMarket.Models.ProductDbContext>
    (options => options.UseSqlServer(cnstr));

//�W�[���Ҥ覡 �ϥ�cookie����
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(Options =>
{
    //�s��������cookie�u��g��https��w�s��
    Options.Cookie.HttpOnly = true;
    //���n�J�ɷ|�۰ʾɤJ�O�J��
    Options.LoginPath = new PathString("/Home/Index");
    //���v������ �]�즹���|
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
