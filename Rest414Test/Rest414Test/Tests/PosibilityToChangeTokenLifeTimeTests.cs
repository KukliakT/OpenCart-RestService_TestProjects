﻿using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Rest414Test.Data;
using Rest414Test.Services;
using System;

namespace Rest414Test.Tests
{
    [TestFixture]
    public class PosibilityToChangeTokenLifeTimeTests
    {
        GuestService guestService;
        AdminService adminService;

        private static readonly object[] TokenLifeTimes =
        {
            new object[] { LifetimeRepository.GetLongTime() }
        };

        private static readonly object[] IncorrectTokenLifeTimes =
        {
            new object[] { LifetimeRepository.GetLifeTimeWithLetters() },
            new object[] { LifetimeRepository.GetLifeTimeWithSymbols() },
            new object[] { LifetimeRepository.GetNegetiveLifeTime()}
        };

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            guestService = new GuestService();
        }

        [SetUp]
        public void SetUp()
        {
            adminService = guestService.SuccessfulAdminLogin(UserRepository.Get().Admin());
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Console.WriteLine("TestContext.CurrentContext.Result.StackTrace = " + TestContext.CurrentContext.Result.StackTrace);
            }
            if ((adminService != null) && (adminService.IsLogged()))
            {
                Lifetime currentTokenlifetime = LifetimeRepository.GetDefault();
                adminService = adminService.UpdateTokenlifetime(currentTokenlifetime);
            }
            if ((adminService != null) && (adminService.IsLogged()))
            {
                guestService = adminService.Logout();
                adminService = null;
            }
        }

        [Test, TestCaseSource("TokenLifeTimes")]
        public void CheckPosibilityToChangeTokenLifeTimeWithValidAdminToken(Lifetime newTokenlifetime)
        {
            adminService = adminService.UpdateTokenlifetime(newTokenlifetime);
            Lifetime currentTokenlifetime = adminService.GetCurrentTokenLifetime();
            Assert.AreEqual(LifetimeRepository.LongTokenLifetime, currentTokenlifetime.Time);
        }

        [Test, TestCaseSource("TokenLifeTimes")]
        public void CheckPosibilityToChangeTokenLifeTimeWithInvalidAdminToken(Lifetime newTokenlifetime)
        {
            adminService = new AdminService(UserRepository.Get().FakeAdmin());
            adminService.UpdateTokenlifetime(newTokenlifetime);
            Lifetime currentTokenlifetime = adminService.GetCurrentTokenLifetime();
            Assert.AreNotEqual(LifetimeRepository.LongTokenLifetime, currentTokenlifetime.Time);
        }

        [Test, TestCaseSource("TokenLifeTimes")]
        public void CheckPosibilityToChangeTokenLifeTimeToCorrentValue(Lifetime newTokenlifetime)
        {
            adminService = adminService.UpdateTokenlifetime(newTokenlifetime);
            Lifetime currentTokenlifetime = adminService.GetCurrentTokenLifetime();
            Assert.AreEqual(LifetimeRepository.LongTokenLifetime, currentTokenlifetime.Time);
        }

        [Test, TestCaseSource("IncorrectTokenLifeTimes")]
        public void CheckPosibilityToChangeTokenLifeTimeToIncorrentValue(Lifetime newTokenLifeTime)
        {
            Lifetime currentTokenlifetimeBeforeChange = adminService.GetCurrentTokenLifetime();
            Console.WriteLine("currentTokenlifetimeBeforeChange.Time = " + currentTokenlifetimeBeforeChange.Time);
            adminService = adminService.UpdateTokenlifetime(newTokenLifeTime);
            Lifetime currentTokenlifetimeAfterChange = adminService.GetCurrentTokenLifetime();
            Console.WriteLine("currentTokenlifetimeAfterChange.Time = " + currentTokenlifetimeAfterChange.Time);
            Assert.AreEqual(currentTokenlifetimeBeforeChange.Time, currentTokenlifetimeAfterChange.Time);
            Assert.AreNotEqual(currentTokenlifetimeAfterChange.Time, newTokenLifeTime.Time);
        }
    }
}

