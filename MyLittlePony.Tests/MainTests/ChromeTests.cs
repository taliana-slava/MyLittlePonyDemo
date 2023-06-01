using MyLittlePony.AT.Framework;
using MyLittlePony.AT.Framework.Models;
using MyLittlePony.AT.Selenium.WebDriver;
using MyLittlePony.Tests.Base;
using MyLittlePony.Tests.DataSource;
using MyLittlePony.Tests.PageObjects;
using NUnit.Framework;

namespace MyLittlePony.Tests.MainTests
{
    [TestFixture]
    public class ChromeTests : UiTestBase
    {

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ChromeTestCases))]
        public void ChromeSearchVerification(ChromeInfo info)
        {
            var chromeSearchPage = new ChromeSearchPage();
            var chromeSearchResultPage = new ChromeSearchResultPage();

            chromeSearchPage.InputText(info.SearchText);
            chromeSearchPage.EnterInput();

            Assert.IsTrue(chromeSearchResultPage.GetContentItemsText()[4].Contains("Selenium IDE"));
        }
        
    }
}
