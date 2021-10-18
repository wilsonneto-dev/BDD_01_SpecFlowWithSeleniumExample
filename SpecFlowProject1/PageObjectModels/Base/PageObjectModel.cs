using SpecFlowProject1.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject1.PageObjectModels.Base
{
    public abstract class PageObjectModel
    {
        protected readonly IBrowserHelper BrowserHelper;
        public readonly ConfigurationHelper Configuration;

        protected PageObjectModel(IBrowserHelper browserHelper, ConfigurationHelper configuration)
        {
            BrowserHelper = browserHelper;
            Configuration = configuration;
        }

        public string GetCurrentUrl()
        {
            return BrowserHelper.GetCurrentUrl();
        }
        public string Close()
        {
            return BrowserHelper.GetCurrentUrl();
        }

        public void NavigateTo(string url)
        {
            BrowserHelper.NavigateTo(url);
        }
    }
}
