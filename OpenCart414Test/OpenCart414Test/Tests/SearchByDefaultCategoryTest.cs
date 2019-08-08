﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenCart414Test.Data;
using OpenCart414Test.Pages;

namespace OpenCart414Test.Tests
{
    [TestFixture]
    class SearchByDefaultCategoryTest:TestRunner
    {
        // DataProvider
        private static readonly object[] ProductSearch =
        {
            new object[] {
                SearchCriteriaRepository.GetMacBookD(),
                },
        };

        [Test, TestCaseSource(nameof(ProductSearch))]
        public void CheckSearchByDefaultCategory(SearchCriteria searchCriteria)
        {
            SearchSuccessPage searchSuccessPage = LoadApplication().SearchSuccessfully(searchCriteria);
            searchSuccessPage.ProductsCriteria.GetProductComponentsCount();

            Console.WriteLine(searchSuccessPage.ProductsCriteria.GetProductComponentsCount());
            Thread.Sleep(2000);

            //SearchUnsuccessPage searchUnsuccessPage = LoadApplication().ClickSearchButtonD();
            //searchUnsuccessPage.ClearCriteriaSearchField();
            //searchUnsuccessPage.ClickCriteriaSearchField();
            //searchUnsuccessPage.SetCriteriaSearchField("Mac");
            //Thread.Sleep(1000);  //Only for presentation
            //searchUnsuccessPage.ClickCriteriaSearchButton();

            //SearchSuccessPage searchSuccessPage 
            //Thread.Sleep(5000);  //Only for presentation
        }
    }
}