using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MyLittlePony.AT.Selenium.WebDriver;
using OpenQA.Selenium;

namespace MyLittlePony.AT.Selenium.WebElement.BaseElements
{
    public class HtmlElement
    {
        protected IWebDriver MyDriver => Driver.GetDriver();

        private readonly IWebElement _parentWebElement = null;
        private readonly IWebElement _convert = null;

        public IWebElement Element => _convert ??
                                      (_parentWebElement == null
                                      ? MyDriver.FindElement(Locator)
                                      : _parentWebElement.FindElement(Locator));

        public By Locator { get; set; }


        public HtmlElement(IWebElement convert)
        {
            _convert = convert;
        }

        public HtmlElement(HtmlElement element, By locator)
        {
            _parentWebElement = element.Element;
            Locator = locator;
        }

        public HtmlElement(By locator)
        {
            Locator = locator;
        }

        public HtmlElement(IWebElement webElement, By locator)
        {
            _parentWebElement = webElement ?? throw new ArgumentNullException(nameof(webElement));
            Locator = locator;
        }

        #region Settable parameters

        public string ExpectedText { get; set; }

        public string ExpectedTitle { get; set; }
        #endregion

        #region Html Parameters

        public virtual string Text
        {
            get
            {
                var value = Element.Text;

                return value;
            }
        }

        public virtual string Title
        {
            get
            {
                var value = Element.GetAttribute("title");

                return value;
            }
        }

        public virtual string Value
        {
            get
            {
                var value = Element.GetAttribute("value");

                return value;
            }
        }

        public virtual string InnerHtml
        {
            get
            {
                var value = Element.GetAttribute("innerHTML"); 

                return value;
            }
        }

        public virtual string OuterHtml
        {
            get
            {
                var value = Element.GetAttribute("outerHTML"); 

                return value;
            }
        }

        public string Id
        {
            get
            {
                var value = Element.GetAttribute("Id");

                return value;
            }
        }

        public string Name
        {
            get
            {
                var value = Element.GetAttribute("name");

                return value;
            }
        }

        public string Class
        {
            get
            {
                var value = Element.GetAttribute("class");

                return value;
            }
        }

        public bool Enabled
        {
            get
            {
                var value = Element.Enabled;

                return value;
            }
        }

        public bool Displayed
        {
            get
            {
                var value = Element.Displayed;

                return value;
            }
        }

        public string TagName
        {
            get
            {
                var value = Element.TagName;

                return value;
            }
        }

        public Point Location
        {
            get
            {
                var value = Element.Location;

                return value;
            }
        }

        public Size Size
        {
            get
            {
                var value = Element.Size;

                return value;
            }
        }

        public string GetCssValue(string value)
        {
            var result = Element.GetCssValue(value);
            return result;
        }

        public string GetAttributeValue(string name)
        {
            var result = Element.GetAttribute(name);

            return result;
        }

        public string GetProperty(string name)
        {
            var result = Element.GetDomProperty(name);

            return result;
        }

        public virtual HtmlElement Parent
        {
            get
            {
                var value = FindElement<HtmlElement>(By.XPath("parent::*"));

                return value;
            }
        }
        #endregion

        #region Main Methods

        public virtual void Click()
        {
            Element.Click();
        }

        public T FindElement<T>(By by) where T : HtmlElement
        {

            return (T)Activator.CreateInstance(typeof(T), this, by);
        }

        public List<T> FindElements<T>(By by) where T : HtmlElement
        {
            if (by == null)
                throw new ArgumentNullException(nameof(by));


            var elements = Element.FindElements(by);

            return elements.Select(v => (T)Activator.CreateInstance(typeof(T), v)).ToList();
        }

        protected virtual T Ancestor<T>(string by)
        {
           
            return (T)Activator.CreateInstance(typeof(T), this, By.XPath($"ancestor::{by}"));
        }
        #endregion

        #region ElementStates 

        public bool IsElementPresent()
        {
            try
            {
                var a = Element.Displayed;
                return true;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("IsElementPresent failed:", ex);
            }
        }

        public bool IsElementVisible()
        {
            try
            {
                var isElementVisible = Element.Displayed;
                return isElementVisible;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("IsElementPresent failed:", ex);
            }
        }

        public bool IsElementClickable()
        {
            try
            {
                var clickable = Element is { Displayed: true, Enabled: true };
                return clickable;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("IsElementPresent failed:", ex);
            }
        }

        public bool IsElementAbsent()
        {
            try
            {
                var a = Element.Displayed;//any state except exception - element present 
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return true;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("IsElementPresent failed:", ex);
            }
        }
        #endregion
    }
}
