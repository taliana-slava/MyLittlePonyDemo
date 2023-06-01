using MyLittlePony.AT.Framework;
using MyLittlePony.AT.Selenium.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace MyLittlePony.Tests.Base
{
    [TestFixture]
    [Parallelizable(scope: ParallelScope.All)]
    public class UiTestBase
    {
        [SetUp]
        public void Setup()
        {
            Driver.GetDriver().Navigate().GoToUrl(EnvironmentSettings.EnvironmentInfo.BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.QuiteDriver();
        }

    }
}
