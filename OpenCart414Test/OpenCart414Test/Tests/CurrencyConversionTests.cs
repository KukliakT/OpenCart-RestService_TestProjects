﻿using System;
using NUnit.Framework;
using OpenCart414Test.Pages;
using OpenCart414Test.Pages.AdminPanel;
using OpenCart414Test.Data;

namespace OpenCart414Test.Tests
{
    [TestFixture]
    class CurrencyConversionTests : TestRunner
    {
        decimal euroRate;
        decimal gbpRate;
        decimal  usdPrice;
        decimal  euroPrice;
        decimal  gbpPrice;

        [SetUp]
        public override void SetUp()
        {
            AdminLoginPage ALoginPage = LoadAdminLoginPage();
            AdminHomePage AHomePage = ALoginPage.LogInAdmin();
            CurrenciesPage CurrencyPage = AHomePage.ClickCurrenciesMenu();
            euroRate = CurrencyPage.GetCurrencyRate("Euro");
            gbpRate = CurrencyPage.GetCurrencyRate("Pound Sterling");
            HomePage UserHomePage = LoadHomePage();
            UserHomePage = UserHomePage.ChooseCurrency(Currency.US_DOLLAR);
            usdPrice = UserHomePage.GetProductNewPriceValue(ProductRepository.GetCanonEos5D());
            UserHomePage = UserHomePage.ChooseCurrency(Currency.EURO);
            euroPrice = UserHomePage.GetProductNewPriceValue(ProductRepository.GetCanonEos5D());
            UserHomePage = UserHomePage.ChooseCurrency(Currency.POUND_STERLING);
            gbpPrice = UserHomePage.GetProductNewPriceValue(ProductRepository.GetCanonEos5D());

        }

        [Test]
        public void CheckConversion()
        {
            Console.WriteLine(euroRate);
            decimal Conversion = Math.Round(usdPrice * euroRate, 2);
            Console.WriteLine(Conversion);
            Console.WriteLine(usdPrice);
            Assert.AreEqual(Conversion, euroPrice);
        }
        [Test]
        public void CheckGbpConversion()
        {
            decimal Conversion = Math.Round(usdPrice * gbpRate, 2);
            Assert.AreEqual(Conversion, gbpPrice);
        }
    }
}
