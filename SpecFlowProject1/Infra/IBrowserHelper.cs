using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject1.Infra
{
    public interface IBrowserHelper
    {
        public string GetCurrentUrl();

        public void NavigateTo(string url);

        public bool UrlContains(string content);

        public void ClickLinkByText(string linkText);

        public void ClickButtonById(string buttonId);

        public void ClickByXath(string xPath);

        public IWebElement GetElementByCssClass(string cssClass);

        public IWebElement GetElementByXpath(string xPath);

        public void TypeTextById(string id, string value);

        public void TypeTextByXpath(string xpath, string value);

        public void SelectValueInDropboxById(string id, string value);

        public string GetElementTextByCssClass(string cssClass);

        public string GetElementTextByXpath(string xpath);

        public string GetTextByElementId(string id);

        public string GetTextBoxContentById(string id);

        public IEnumerable<IWebElement> GetListByCssClass(string cssClass);

        public bool ElementExistsById(string id);
        public bool ElementExists(By by);

        public void NavigateBack(int times = 1);

        public void TakeScreenShot(string name);
        public void Close();

    }
}
