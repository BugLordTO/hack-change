using FluentAssertions;
using Hack.Change.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Hack.Change.Test
{
    public class ChangeTest
    {
        public static IEnumerable<object[]> scenarios = new List<object[]>
        {
            new object[] { 1000, 650, new ChangeModel { Change = 350, Tousand = 0, FiveHundred = 0, Hundred = 3, Fifty = 1, Twenty = 0, Five = 0, One = 0, } },
            new object[] { 1000, 352, new ChangeModel { Change = 648, Tousand = 0, FiveHundred = 1, Hundred = 1, Fifty = 0, Twenty = 2, Five = 1, One = 3, } },
            new object[] { 1000, 450, new ChangeModel { Change = 550, Tousand = 0, FiveHundred = 1, Hundred = 0, Fifty = 1, Twenty = 0, Five = 0, One = 0, } },
            new object[] { 1000, 138, new ChangeModel { Change = 862, Tousand = 0, FiveHundred = 1, Hundred = 3, Fifty = 1, Twenty = 0, Five = 2, One = 2, } },
            new object[] { 1000, 1000, new ChangeModel { Change = 0, Tousand = 0, FiveHundred = 0, Hundred = 0, Fifty = 0, Twenty = 0, Five = 0, One = 0, } },
            new object[] { 1000, 1100, null },
            new object[] { -1, 138, null },
            new object[] { 1000, -1, null },
            new object[] { -1, -1, null },
        };

        [Theory]
        [MemberData(nameof(scenarios))]
        public void ChangeCalculatorTest(int amount, int pay, ChangeModel expected)
        {
            var sut = new ChangeCalculator();
            var actual = sut.CalculateChange(amount, pay);
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
