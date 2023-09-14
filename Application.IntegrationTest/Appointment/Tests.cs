using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Application.IntegrationTest.Appointment;

public class Tests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly ISender _mediator;

    public Tests(WebApplicationFactory<Program> webAppFactory)
    {
        _mediator = webAppFactory.Services.GetService<ISender>()!;
    }

    [Fact]
    public async Task Schedule_Successful()
    {
        var id = await _mediator.Send()
    }
}
