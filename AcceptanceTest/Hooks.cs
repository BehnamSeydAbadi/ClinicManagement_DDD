using BoDi;
using Microsoft.AspNetCore.Mvc.Testing;
using TechTalk.SpecFlow;

namespace AcceptanceTest;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _scenarioContext;

    public Hooks(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;


    [BeforeScenario]
    public void CreateApplication()
    {
        var application = new WebApplicationFactory<Program>();

        _scenarioContext.Add("httpClient", application.CreateClient());
    }
}
