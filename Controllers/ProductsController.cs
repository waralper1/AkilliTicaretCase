using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace AkilliTicaretCase.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            dynamic request = new ExpandoObject();
            request.page = 2;
            var result = Sabitler.PostMessageToServer(request, "Product/listProducts/");
            return View();
        }


    }
}
