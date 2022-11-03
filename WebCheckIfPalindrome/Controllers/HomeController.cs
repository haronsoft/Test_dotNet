using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;
using WebCheckIfPalindrome.Models;

namespace WebCheckIfPalindrome.Controllers
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
            return View();
        }  
        [HttpPost]
        public IActionResult Index(PalindromeVm model)
        {
            var result = new PalindromeVm();
            var myString = model.word.ToString();
            if (myString.Length == 0)
            {
                return View(model);
            }
            else
            {
                if (myString != null)
                {
                    result.word = myString;
                    var reverse = string.Join("", myString.Reverse());
                    if (myString == reverse)
                    {
                        result.isPalindrome = true;
                    }
                    else
                    {
                        result.isPalindrome = false;
                    }
                }
            }
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}