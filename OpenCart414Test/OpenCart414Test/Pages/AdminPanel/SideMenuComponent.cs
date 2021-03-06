﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace OpenCart414Test.Pages.AdminPanel
{
    public class SideMenuComponent : HeaderPart
    {
        public IWebElement ProfileSection { get { return driver.FindElement(By.Id("profile")); } }
        public IWebElement DashboardButton { get { return driver.FindElement(By.Id("menu-dashboard")); } }
        public Dictionary<string, MenuComponent> Menus = new Dictionary<string, MenuComponent>();

        public SideMenuComponent(IWebDriver driver) : base(driver)
        {
            
        }

        public void GetMenu()
        {
            MenuButton.Click();
            foreach (IWebElement item in driver.FindElements(By.CssSelector("li[id]>a.parent")))
            {
                MenuComponent menu = new MenuComponent();
                menu.MenuButton = item;
                menu.MenuLabel = item.FindElement(By.XPath("./span")).Text;
                Menus.Add(menu.MenuLabel, menu);

            }
            //MenuButton.Click();
        }

        public void ClickMenu(string targetMenu)
        {

            Menus[targetMenu].MenuButton.Click();
        }

        public void ClickLocalizationMenu()
        {
            
            MenuComponent Localization = new MenuComponent();
            Localization.MenuButton = driver.FindElement(By.XPath("//a[contains(text(), 'Localisation')]"));
            Localization.MenuLabel = Localization.MenuButton.Text;
            Localization.MenuButton.Click();
        }

        public GeoZonesPage GoToGeoZonePage()
        {
            
            MenuComponent GeoZones = new MenuComponent();
            GeoZones.MenuButton = driver.FindElement(By.XPath("//a[contains(text(), 'Geo Zones')]"));
            GeoZones.MenuLabel = GeoZones.MenuButton.Text;
            GeoZones.MenuButton.Click();
            return new GeoZonesPage(driver);
        }

        public void ClickTaxesMenu()
        {
            
            MenuComponent Taxes = new MenuComponent();
            Taxes.MenuButton = driver.FindElement(By.XPath("//a[contains(text(), 'Taxes')]"));
            Taxes.MenuLabel = Taxes.MenuButton.Text;
            Taxes.MenuButton.Click();
        }

        public TaxRatesPage GoToTaxRatesPage()
        {
            
            MenuComponent TaxRates = new MenuComponent();
            TaxRates.MenuButton = driver.FindElement(By.XPath("//a[contains(text(), 'Tax Rates')]"));
            TaxRates.MenuLabel = TaxRates.MenuButton.Text;
            TaxRates.MenuButton.Click();
            return new TaxRatesPage(driver);
        }

        public TaxClassesPage GoToTaxClassesPage()
        {
            
            MenuComponent TaxClasses = new MenuComponent();
            TaxClasses.MenuButton = driver.FindElement(By.XPath("//a[contains(text(), 'Tax Classes')]"));
            TaxClasses.MenuLabel = TaxClasses.MenuButton.Text;
            TaxClasses.MenuButton.Click();
            return new TaxClassesPage(driver);
        }

        public void ClickSubMenu(string submenu)
        {
            MenuComponent Submenu = new MenuComponent();
            string path = String.Format(@"//a[contains(text(), {0})]", submenu);
            Submenu.MenuButton = driver.FindElement(By.XPath(path));
            Submenu.MenuLabel = Submenu.MenuButton.Text;
            Submenu.MenuButton.Click();
        }

        public CurrenciesPage ClickCurrenciesMenu()
        {
            ClickLocalizationMenu();
            MenuComponent Currencies = new MenuComponent();
            Currencies.MenuButton = driver.FindElement(By.XPath("//a[contains(text(), 'Currencies')]"));
            Currencies.MenuLabel = Currencies.MenuButton.Text;
            Currencies.MenuButton.Click();
            return new CurrenciesPage(driver);
        }

        public void ClickSystemMenu()
        {
            driver.FindElement(By.Id("menu-system")).Click();
        }
    }


}
