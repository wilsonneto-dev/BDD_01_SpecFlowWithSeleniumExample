using Bogus;
using SpecFlowProject1.Infra;
using SpecFlowProject1.Infra.Seleium;
using Xunit;

namespace SpecFlowProject1.Fixtures
{
    [CollectionDefinition(nameof(WebTestFixture))]
    public class WebTestFixtureCollection : ICollectionFixture<WebTestFixture> { }

    public class WebTestFixture
    {
        public IBrowserHelper BrowserHelper;
        public readonly ConfigurationHelper Configuration;

        public WebTestFixture()
        {
            Configuration = new ConfigurationHelper();
            BrowserHelper = new SeleniumHelper(Configuration, Browser.Chrome);
        }
    }
}
