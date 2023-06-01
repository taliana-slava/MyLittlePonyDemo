using OpenQA.Selenium;

namespace MyLittlePony.AT.Selenium.WebElement.BaseElements
{
    public class InputElement : HtmlElement
    {
        public InputElement(IWebElement convert) : base(convert)
        {
        }

        public InputElement(By locator) : base(locator)
        {
        }

        public InputElement(HtmlElement webElement, By locator) : base(webElement, locator)
        {
        }

        public InputElement(IWebElement webElement, By locator) : base(webElement, locator)
        {
        }

        private InputElement Input => FindElement<InputElement>(By.TagName("input"));
        private HtmlElement TitleBox => Ancestor<HtmlElement>("div[contains(@class, 'adm_control_box')]");

        #region Html parameters

        public override string Title
        {
            get
            {
                var value = TitleBox.Text;

                return value;
            }
        }
        #endregion

        #region Methods

        public void SetValue(string value)
        {

            if (TagName != "input")
                Input.SetValue(value);
            else
                Element.SendKeys(value);

        }
        #endregion
    }
}
