using BoDi;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
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

        var scope = application.Services.CreateScope();

        _scenarioContext.Add("httpClient", application.CreateClient());
        _scenarioContext.Add("dbContext", scope.ServiceProvider.GetRequiredService<AppDbContext>());
    }

    [BeforeScenario]
    public void RegisterServices()
    {
        _objectContainer.RegisterInstanceAs(_scenarioContext["httpClient"], typeof(HttpClient));
        _objectContainer.RegisterInstanceAs(_scenarioContext["dbContext"], typeof(AppDbContext));
    }
}
