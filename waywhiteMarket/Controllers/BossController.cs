using Microsoft.AspNetCore.Mvc;
using waywhiteMarket.Models;

namespace waywhiteMarket.Controllers
{
    public class BossController : Controller
    {
       
            private ProductDbContext _context;
            private string _path;


            public BossController(ProductDbContext context, IWebHostEnvironment hostEnvironment)
            {
                _context = context;
                _path = $"{hostEnvironment.WebRootPath}\\product";
            }
            public IActionResult Index()
        {
            return View();
        }

   

        public IActionResult Inventory()
        {           
            return View();
        }
        public IActionResult Delete(string id)
        {
            var productDelete = _context.TProducts.FirstOrDefault(p => p.FName == id);
            _context.TProducts.Remove(productDelete);
            _context.SaveChanges();
            return RedirectToAction("Inventory", "boss");
        }

        public IActionResult ProductUpLoad()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProductUpLoad(TProduct product,IFormFile formFile)
        {
            ViewBag.error = "商品無法上傳";
            if (ModelState.IsValid)
            {
                if(formFile != null)
                {
                    if (formFile.Length > 0)
                    {
                        string filename = $"{Guid.NewGuid().ToString()}.jfif";
                        string save = $"{_path}\\{filename}";
                        using (var stream = new FileStream(save, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                        product.FOwner = "ahow";
                        product.FPath = save;
                        product.FDay=DateTime.Now;
                        _context.TProducts.Add(product);
                        _context.SaveChanges();
                        ViewBag.good = "照片上傳成功";
                        return RedirectToAction("Inventory","boss");
                    }
                }
            }
            return View(product);
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
        public IActionResult Member()
        {
            return View();
        }
        public IActionResult MemberDelete(string id)
        {
            var MemberDelete = _context.TMembers.FirstOrDefault(p => p.FName == id);
            _context.TMembers.Remove(MemberDelete);
            _context.SaveChanges();
            return RedirectToAction("Member", "boss");
        }
        
    }
}
