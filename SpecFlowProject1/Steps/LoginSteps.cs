using FluentAssertions;
using SpecFlowProject1.Fixtures;
using SpecFlowProject1.PageObjectModels;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowProject1.Steps
{
    [Binding]
    [CollectionDefinition(nameof(WebTestFixtureCollection))]
    public class LoginSteps
    {
        private readonly WebTestFixture _webTestFixture;
        private readonly LoginPage _loginPage;

        public LoginSteps(WebTestFixture webTestFixture)
        {
            _webTestFixture = webTestFixture;
            _loginPage = new LoginPage(_webTestFixture.BrowserHelper, _webTestFixture.Configuration);
        }

        [Given(@"The user entered login page")]
        public void GivenTheUserEnteredLoginPage()
        {
            _loginPage.GoToPage();
        }
        
        [Given(@"The user typed the credentials: user ""(.*)"" pass ""(.*)""")]
        public void GivenTheUserTypedTheCredentialsUserPass(string username, string pass)
        {
            _loginPage.TypeCredentials(username, pass);
        }
        
        [When(@"Press login button")]
        public void WhenPressLoginButton()
        {
            _loginPage.ClickLoginButton();
        }
        
        [Then(@"The user should be logged as: ""(.*)""")]
        public void ThenTheUserShouldBeLoggedAs(string userName)
        {
            _loginPage.GetCurrentUserName().Should().Be(userName) ;
        }
        
        [Then(@"The user should be redirected to user dashboard page")]
        public void ThenTheUserShouldBeRedirectedToUserDashboardPage()
        {
            _loginPage.GetCurrentUrl().Should().Be("http://zedoingresso.com.br/");
        }
        
        [Then(@"Message ""(.*)"" should be shown")]
        public void ThenMessageShouldBeShown(string message)
        {
            _loginPage.GetMessage().Should().Be(message);
        }
    }
}
