using CommonTestUtilities.Requests;
using Shouldly;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace WebApi.Test.Routine.Register;

public class RegisterRoutineTest : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _httpClient;
    public RegisterRoutineTest(CustomWebApplicationFactory factory) => _httpClient = factory.CreateClient();
    
    [Fact]
    public async Task Sucess()
    {
        var request = RequestRegisterRoutineJsonBuilder.Build();

        var response = await _httpClient.PostAsJsonAsync("Routine", request);

        response.StatusCode.ShouldBe(HttpStatusCode.Created);
        await using var responseBody = await response.Content.ReadAsStreamAsync();
        var responseData = await JsonDocument.ParseAsync(responseBody);
        responseData.RootElement.GetProperty("name").GetString().ShouldBe(request.Name);
    }
}
