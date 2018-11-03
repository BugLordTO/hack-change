using System;
using Hack.Change.Models;

namespace Hack.Change
{
    public class ChangeCalculator : IChangeCalculator
    {
        public ChangeModel CalculateChange(int pay, int amount)
        {
            if (pay < 0 || amount < 0 || pay < amount)
            {
                return null;
            }

            var change = new ChangeModel();
            change.Change = pay - amount;
            var remainChange = change.Change;

            if (remainChange >= 1000)
            {
                change.Tousand = remainChange / 1000;
                remainChange = remainChange % 1000;
            }
            if (remainChange >= 500)
            {
                change.FiveHundred = remainChange / 500;
                remainChange = remainChange % 500;
            }
            if (remainChange >= 100)
            {
                change.Hundred = remainChange / 100;
                remainChange = remainChange % 100;
            }
            if (remainChange >= 50)
            {
                change.Fifty = remainChange / 50;
                remainChange = remainChange % 50;
            }
            if (remainChange >= 20)
            {
                change.Twenty = remainChange / 20;
                remainChange = remainChange % 20;
            }
            if (remainChange >= 5)
            {
                change.Five = remainChange / 5;
                remainChange = remainChange % 5;
            }
            if (remainChange >= 1)
            {
                change.One = remainChange / 1;
                remainChange = remainChange % 1;
            }

            return change;
        }
    }
}
