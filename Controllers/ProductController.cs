
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models;

namespace ProductCatalog.Controllers
{
    public class ProductController : Controller
    {
        // Барлық тауарлар тізімі
        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Ноутбук",
                    Price = 350000,
                    Category = "Электроника",
                    IsAvailable = true,
                    Description = "Оқу, жұмыс және бағдарламалау үшін арналған заманауи ноутбук. Жылдам жұмыс істейді және күнделікті қолдануға ыңғайлы."
                },
                new Product
                {
                    Id = 2,
                    Name = "Құлаққап",
                    Price = 15000,
                    Category = "Аксессуар",
                    IsAvailable = true,
                    Description = "Музыка тыңдауға және қоңырау шалуға арналған сапалы құлаққап. Дыбысы анық, қолдануға ыңғайлы."
                },
                new Product
                {
                    Id = 3,
                    Name = "Пернетақта",
                    Price = 12000,
                    Category = "Компьютерлік техника",
                    IsAvailable = false,
                    Description = "Компьютерге арналған ыңғайлы пернетақта. Оқу мен жұмысқа пайдалануға болады."
                },
                new Product
                {
                    Id = 4,
                    Name = "Тінтуір",
                    Price = 8000,
                    Category = "Аксессуар",
                    IsAvailable = true,
                    Description = "Компьютерді басқаруға арналған ыңғайлы тінтуір. Күнделікті жұмыс пен оқуға қолайлы."
                }
            };
        }

        // Каталог беті
        public IActionResult Index(string? search, string? category)
        {
            var products = GetProducts();

            ViewBag.Categories = products
                .Select(p => p.Category)
                .Distinct()
                .ToList();

            if (!string.IsNullOrWhiteSpace(search))
            {
                products = products.Where(p =>
                    p.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    p.Category.Contains(search, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                products = products
                    .Where(p => p.Category == category)
                    .ToList();
            }

            ViewBag.Search = search;
            ViewBag.SelectedCategory = category;
            ViewBag.Title = "Тауарлар каталогы";

            return View(products);
        }

        // Жеке тауар беті
        public IActionResult Details(int id)
        {
            var product = GetProducts()
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // Таңдаулылар беті
        public IActionResult Favorites()
        {
            var products = GetProducts();

            return View(products);
        }
    }
}
