using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SpecFlowProject1.Infra.Seleium
{
    public static class SeleniumWebDriverFactory
    {
        public static IWebDriver CreateWebDriver(Browser browser = Browser.Chrome, string driverPath = "C:\\drivers\\", bool headless = false)
        {
            IWebDriver webDriver = null;

            switch (browser)
            {
                case Browser.Firefox:
                    var optionsFireFox = new FirefoxOptions();
                    if (headless)
                        optionsFireFox.AddArgument("--headless");

                    webDriver = new FirefoxDriver(driverPath, optionsFireFox);

                    break;
                case Browser.Chrome:
                    var options = new ChromeOptions();
                    if (headless)
                        options.AddArgument("--headless");

                    webDriver = new ChromeDriver(driverPath, options);

                    break;
            }

            return webDriver;
        }
    }
}

