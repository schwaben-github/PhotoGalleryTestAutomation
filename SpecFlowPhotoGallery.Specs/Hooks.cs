using BoDi;
using SpecFlowPhotoGallery.Specs.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowPhotoGallery.Specs
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _container;
        private WebDriverContext _webDriverContext;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _webDriverContext = new WebDriverContext();
            _container.RegisterInstanceAs(_webDriverContext);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _webDriverContext?.Dispose();
        }
    }
}
