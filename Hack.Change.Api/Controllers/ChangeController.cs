using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hack.Change.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hack.Change.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ChangeController : Controller
    {
        private readonly IChangeCalculator changeCalculator;

        public ChangeController(IChangeCalculator changeCalculator)
        {
            this.changeCalculator = changeCalculator;
        }

        [HttpGet("{pay}/{amount}")]
        public ChangeModel Calculate(int pay, int amount)
        {
            var result = changeCalculator.CalculateChange(pay, amount);
            return result;
        }
    }
}
