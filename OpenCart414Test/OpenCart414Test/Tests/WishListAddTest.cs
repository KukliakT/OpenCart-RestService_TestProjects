﻿using System.Threading;
using NUnit.Framework;
using OpenCart414Test.Data;
using OpenCart414Test.Pages;

namespace OpenCart414Test.Tests
{
    [TestFixture]
    public class WishListAddTest : TestRunner
    {
        private WishListPage wishListPage;
        private Product productToAdd = ProductRepository.GetIPhone();

        [TearDown]
        public void InnerTearDown()
        {
            wishListPage.RemoveLastItemFromWishList(productToAdd);
            AccountLogoutPage accountLogoutPage = wishListPage
                .Logout();
        }

        // DataProvider
        private static readonly object[] DataToTestOn =
        {
            new object[] { ProductRepository.GetIPhone(), UserRepository.Get().WishListTester() },
        };

        [Test, TestCaseSource(nameof(DataToTestOn))]
        public void CheckAdding(Product addingProduct, IUser user)
        {
            HomePage homePage = LoadApplication()
                .GotoLoginPage()
                .LoggingIn(user.Email, user.Password)
                .GotoHomePage();
            Thread.Sleep(2000); //for presentation only
            homePage.getProductComponentsContainer()
                .GetProductComponentByName(addingProduct.Title)
                .AddItemToWishList();
            Thread.Sleep(2000); //for presentation only
            wishListPage = homePage
                .GotoWishListPage();
            Thread.Sleep(2000); //for presentation only
            Assert.IsTrue(wishListPage
                .GetWishListComponentsContainer()
                .GetWishListComponentNames()
                .Contains(addingProduct.Title));
        }
    }
}
