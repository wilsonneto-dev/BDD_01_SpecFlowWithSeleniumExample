using SpecFlowProject1.Infra;
using SpecFlowProject1.PageObjectModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject1.PageObjectModels
{
    class LoginPage: PageObjectModel
    {
        public LoginPage(IBrowserHelper helper, ConfigurationHelper configuration) : base(helper, configuration)
        {
        }

        public void GoToPage()
        {
            BrowserHelper.NavigateTo(Configuration.LoginUrl);
        }

        public void TypeCredentials(string username, string password)
        {
            BrowserHelper.TypeTextByXpath("/html/body/section[1]/section/form/input[1]", username);
            BrowserHelper.TypeTextByXpath("/html/body/section[1]/section/form/input[2]", password);
        }

        public void ClickLoginButton()
        {
            BrowserHelper.ClickByXath("/html/body/section[1]/section/form/input[4]");
        }

        public string GetMessage()
        {
            return BrowserHelper.GetElementTextByCssClass("msg");
        }

        public string GetCurrentUserName()
        {
            return BrowserHelper.GetElementTextByXpath("/html/body/header/div/section/a");
        }
    }
}
