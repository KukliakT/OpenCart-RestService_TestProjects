﻿using OpenQA.Selenium;

namespace OpenCart414Test.Pages
{
    public class WishListMessageEmptyPage : WishListEmptyPage
    {
        public IWebElement WishListAlertMessage =>
        driver.FindElement(By.CssSelector(".alert.alert-success"));

        public WishListMessageEmptyPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetWishListAlertMessageText()
        {
            return WishListAlertMessage.Text;
        }
        public bool IsWishListAlertMessageDisplayed()
        {
            return WishListAlertMessage.Displayed;
        }
        public void ClickCloseWishListAlertMessage()
        {
            WishListAlertMessage.FindElement(By.CssSelector(".close")).Click();
        }
    }
}
