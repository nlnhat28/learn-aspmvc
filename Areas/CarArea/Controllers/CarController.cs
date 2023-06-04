using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MVC_Basic.Models;
using MVC_Basic.Services;

namespace MVC_Basic.Areas.CarArea.Controllers
{
    [Area("CarArea")]
    // [Route("super-car/[action]")]
    public class CarController : Controller
    {
        private readonly ILogger<CarController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly CarService _carService;

        public CarController(ILogger<CarController> logger, IWebHostEnvironment env, CarService carService)
        {
            _logger = logger;
            _env = env;
            _carService = carService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowContent()
        {
            var car = new
            {
                name = "Aventador",
                brand = "Lamborghini",
                color = "white",
                price = "$1,000,000"
            };

            _logger.LogWarning("Car/ShowContent");
            return this.Content(JsonConvert.SerializeObject(car, Formatting.Indented), "text/plain");
        }
        public IActionResult ShowJson()
        {
            var car = new
            {
                name = "Aventador",
                brand = "Lamborghini",
                color = "white",
                price = "$1,000,000"           
            };

            _logger.LogWarning("Car/ShowJson");
            return Json(car);
        }
        public IActionResult ShowImage()
        {
            var applicationPath = _env.ContentRootPath;
            var filePath = Path.Combine(applicationPath, "Assets", "Images", "lamborghini-car-1.jpg");
            var fileContent = System.IO.File.ReadAllBytes(filePath);

            _logger.LogWarning("Car/ShowImage");
            return File(fileContent, "image/jpg");
        }
        public IActionResult LocalRedirect()
        {
            var url = Url.Action("Privacy", "Home")??"Index";

            _logger.LogWarning("Car/LocalRedirect");
            return LocalRedirect(url);
        }
        public IActionResult Redirect()
        {
            var url = "https://www.google.com/search?q=lamborghini&sxsrf=APwXEddQLVz3ck8A1s0sM2MV6blVqvjrVg:1685772953693&source=lnms&tbm=isch&sa=X&ved=2ahUKEwiFqc7Quab_AhXUxGEKHR6JBF4Q_AUoAXoECAEQAw&biw=1501&bih=738&dpr=1.25";

            _logger.LogWarning("Car/Redirect");
            return Redirect(url);
        }

        [Route("/my-collection", Order = 1, Name = "collection1")]                           // localhost:5130/my-collection
        [Route("my-collection/[controller]/[action]", Order = 2, Name = "collection2")]     // localhost:5130/my-collection/Car/Collection
        [Route("[controller]-[action].html", Order = 3, Name = "collection3")]              // localhost:5130/Car-Collection.html

        public IActionResult Collection(string? brand)
        {
            _logger.LogWarning("Car/Collection");

            // return View("MyViews/Car.cshtml", brand);
            return View("Collection", brand);
        }
        public IActionResult Product()
        {
            _logger.LogWarning("Car/Product");
            return View();
        }
        public IActionResult Search(string? q)
        {
            var key = q ?? "";
            var result = _carService.Search(key);

            _logger.LogWarning("Car/Search");
            return View("Search", result);
        }
        public IActionResult Search2(string? q)
        {
            var key = q ?? "";
            var result = _carService.Search(key);
            ViewBag.ListCars = result;
            _logger.LogWarning("Car/Search2");
            return View("Search2");
        }
    }
}