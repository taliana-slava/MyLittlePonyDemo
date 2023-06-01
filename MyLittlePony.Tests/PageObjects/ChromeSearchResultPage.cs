using MyLittlePony.AT.Selenium.WebElement.BaseElements;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace MyLittlePony.Tests.PageObjects
{
    public class ChromeSearchResultPage
    {
        public HtmlElement SearchContent => new HtmlElement(By.XPath("//div[@id='rso']"));

        public List<HtmlElement> SearchContentItems => SearchContent.FindElements<HtmlElement>(By.XPath("//div[@class='yuRUbf']/a/h3"));

        public List<string> GetContentItemsText()
        {
            var result = SearchContentItems.Where(x => !string.IsNullOrEmpty(x.Text)).Select(x => x.Text).ToList();
            return result;
        }
    }
}
