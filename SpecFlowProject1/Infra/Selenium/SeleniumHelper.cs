using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SpecFlowProject1.Infra.Seleium
{
    public class SeleniumHelper : IBrowserHelper, IDisposable
    {
        public IWebDriver WebDriver;
        public readonly ConfigurationHelper Configuration;
        public WebDriverWait Wait;

        public SeleniumHelper(ConfigurationHelper configuration, Browser browser = Browser.Chrome, bool headless = false)
        {
            Configuration = configuration;
            WebDriver = SeleniumWebDriverFactory.CreateWebDriver(browser, Configuration.WebDrivers, headless);
            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(30));
        }

        public string GetCurrentUrl()
        {
            return WebDriver.Url;
        }

        public void NavigateTo(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        public bool UrlContains(string content)
        {
            return Wait.Until(ExpectedConditions.UrlContains(content));
        }

        public void ClickLinkByText(string linkText)
        {
            var link = Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(linkText)));
            link.Click();
        }

        public void ClickButtonById(string buttonId)
        {
            var button = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(buttonId)));
            button.Click();
        }

        public void ClickByXath(string xPath)
        {
            var element = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
            element.Click();
        }

        public IWebElement GetElementByCssClass(string cssClass)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(cssClass)));
        }

        public IWebElement GetElementByXpath(string xPath)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
        }

        public void TypeTextById(string id, string value)
        {
            var fieldElement = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
            fieldElement.SendKeys(value);
        }

        public void TypeTextByXpath(string xpath, string value)
        {
            var fieldElement = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            fieldElement.SendKeys(value);
        }

        public void SelectValueInDropboxById(string id, string value)
        {
            var fieldElement = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
            var selectElement = new SelectElement(fieldElement);
            selectElement.SelectByValue(value);
        }

        public string GetElementTextByCssClass(string cssClass)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(cssClass))).Text;
        }

        public string GetTextByElementId(string id)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id))).Text;
        }

        public string GetTextBoxContentById(string id)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)))
                .GetAttribute("value");
        }

        public IEnumerable<IWebElement> GetListByCssClass(string cssClass)
        {
            return Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName(cssClass)));
        }

        public bool ElementExistsById(string id)
        {
            return ElementExists(By.Id(id));
        }

        public bool ElementExists(By by)
        {
            try
            {
                WebDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void NavigateBack(int times = 1)
        {
            for (var i = 0; i < times; i++)
            {
                WebDriver.Navigate().Back();
            }
        }

        private void SaveScreenShot(Screenshot screenshot, string fileName)
        {
            screenshot.SaveAsFile($"{Configuration.FolderPicture}{fileName}", ScreenshotImageFormat.Png);
        }

        public void TakeScreenShot(string name)
        {
            SaveScreenShot(WebDriver.TakeScreenshot(), string.Format("{0}_" + name + ".png", DateTime.Now.ToFileTime()));
        }

        public void Dispose()
        {
            WebDriver.Quit();
            WebDriver.Dispose();
        }

        public void Close()
        {
            WebDriver.Close();
        }

        public string GetElementTextByXpath(string xpath)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath))).Text;
        }
    }
}

