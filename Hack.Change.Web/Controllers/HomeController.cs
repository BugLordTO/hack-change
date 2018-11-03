using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hack.Change.Web.Models;
using Newtonsoft.Json;
using Hack.Change.Models;

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

        public IActionResult Index()
        {
            if (TempData["result"] != null)
                return View(JsonConvert.DeserializeObject<ChangeModel>(TempData["result"].ToString()));
            else
                return View();
        }

        [HttpPost("{pay}/{amount}")]
        public IActionResult Index(int pay, int amount)
        {
            var result = changeCalculator.CalculateChange(pay, amount);
            TempData["result"] = result;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
