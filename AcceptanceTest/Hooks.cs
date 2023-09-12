using BoDi;
using Microsoft.AspNetCore.Mvc.Testing;
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
        var application = new WebApplicationFactory<Program>();

        _scenarioContext.Add("httpClient", application.CreateClient());
    }

    [BeforeScenario]
    public void RegisterServices()
    {
        _objectContainer.RegisterInstanceAs(_scenarioContext["httpClient"], typeof(HttpClient));
    }
}
