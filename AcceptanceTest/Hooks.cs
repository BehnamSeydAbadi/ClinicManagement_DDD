using BoDi;
using TechTalk.SpecFlow;

namespace AcceptanceTest;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _scenarioContext;
    private readonly IObjectContainer _objectContainer;

    public Hooks(ScenarioContext scenarioContext, IObjectContainer objectContainer)
    {
        _scenarioContext = scenarioContext;
        _objectContainer = objectContainer;
    }

    [BeforeScenario]
    public void CreateApplication()
    {
        var application = ApplicationFactory.NewApp();

        _scenarioContext.Add("httpClient", application.CreateClient());
    }

    [BeforeScenario]
    public void RegisterServices()
    {
        _objectContainer.RegisterInstanceAs(_scenarioContext["httpClient"], typeof(HttpClient));
    }
}
