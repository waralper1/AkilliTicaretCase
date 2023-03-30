using AkilliTicaretCase.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Dynamic;

namespace AkilliTicaretCase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //string GetProductList = "/Product/ListProducts/";
            //string ProductListIndex = "1"; 
            ////var result = Sabitler.GetMessageFromServer(GetProductList+ProductListIndex);
            //string json = System.IO.File.ReadAllText("Products.json");
            //List<ProductModel> productList = JsonConvert.DeserializeObject<List<ProductModel>>(json);
            List<ProductModel> productList = new List<ProductModel>();
            ProductModel product = new ProductModel();
            product.Gorsel = "data:image/jpeg;base64,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";
            product.Stokkodu = "1";
            product.Stokadi = "Ürün 1";
            product.Marka = "Marka 1";
            product.Stok = "10";
            product.Listefiyati = 50.99;
            product.Doviz = "TL";
            product.Nakitiskontosu = 10;
            product.Tekcekimiskontosu = 5;
            product.Altitaksitiskontosu = 2.5;
            product.Acikhesapiskontosu = 0;

            productList.Add(product);
            ProductModel product2 = new ProductModel();
            product2.Gorsel = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQpfV4MjoTRwLqJ4KK2C7kt1P1PdrFInjWiCg&usqp=CAU";
            product2.Stokkodu = "123";
            product2.Stokadi = "Ürün 2";
            product2.Marka = "Marka 2";
            product2.Stok = "10";
            product2.Listefiyati = 5.99;
            product2.Doviz = "TL";
            product2.Nakitiskontosu = 10;
            product2.Tekcekimiskontosu = 52;
            product2.Altitaksitiskontosu = 22.5;
            product2.Acikhesapiskontosu = 40;

            productList.Add(product2);
            return View(productList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}