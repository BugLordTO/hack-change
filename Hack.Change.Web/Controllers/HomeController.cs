using Hack.Change.Models;
using Hack.Change.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Hack.Change.Web.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        private readonly IChangeCalculator changeCalculator;

        public HomeController(IChangeCalculator changeCalculator)
        {
            this.changeCalculator = changeCalculator;
        }

        public IActionResult Index(int? pay, int? amount)
        {
            if (pay.HasValue && amount.HasValue)
            {
                var result = changeCalculator.CalculateChange(pay.Value, amount.Value);
                ViewData["pay"] = pay.Value;
                ViewData["amount"]= amount.Value;
                return View(result);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
