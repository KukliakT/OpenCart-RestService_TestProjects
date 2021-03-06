﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenCart414Test.Data;
using OpenCart414Test.Pages;

namespace OpenCart414Test.Tests
{
    [TestFixture]
    public class WishListTest : TestRunner
    {
        // DataProvider
        private static readonly object[] ProductToAdd =
        {
            new object[] { ProductRepository.GetIPhone() },
        };
        //[Test, TestCaseSource(nameof(ProductToAdd))]
        public void CheckAdding(Product addingProduct)
        {
            HomePage homePage = LoadApplication();
            homePage.GotoLoginPage().LoggingIn("roman_my@ukr.net", "TESTER_PASWORD").GotoHomePage();
            ProductsContainerComponent productsContainerComponent = homePage.getProductComponentsContainer();
            ProductComponent productComponent = productsContainerComponent.GetProductComponentByName(addingProduct.Title);
            productComponent.ClickAddToWishButton();
            WishListPage wishListPage = homePage.GotoWishListPage();
            Assert.IsTrue(wishListPage.getWishListComponentsContainer().GetWishListComponentByName(addingProduct.Title)
                .GetWishListComponentProductNameText().Contains(productComponent.Name.Text));
        }
    }
}
