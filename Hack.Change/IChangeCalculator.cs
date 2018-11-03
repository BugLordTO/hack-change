using Hack.Change.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hack.Change
{
    public interface IChangeCalculator
    {
        ChangeModel CalculateChange(int pay, int amount);
    }
}
