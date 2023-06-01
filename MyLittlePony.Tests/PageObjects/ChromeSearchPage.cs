using MyLittlePony.AT.Framework.Models;
using MyLittlePony.AT.Selenium.WebElement.BaseElements;
using OpenQA.Selenium;

namespace MyLittlePony.Tests.PageObjects
{
    public class ChromeSearchPage
    {
        public InputElement SearchInput => new InputElement(By.Name("q"));


        public void InputText(string text)
        {
            SearchInput.Element.SendKeys(text);
        }

        public void EnterInput()
        {
            SearchInput.Element.SendKeys(Keys.Enter);
        }

    }
}
