using assms.api.Constants;
using assms.api.Helpers;
using assms.entities;
using assms.entities.GeneralResponse;
using assms.entities.Request;
using assms.entities.Response.InstitutionsResponse;
using assms.test.Fixtures;
using assms.test.Helpers;

namespace assms.test.IntegrationTests.Controllers.V_1;

public class InstitionControllerTests(ApplicationFixture fixture) : InstitionOperations(fixture), IClassFixture<ApplicationFixture>
{
    private readonly ApplicationFixture _fixture = fixture;

    [Fact]
    public async Task It_Should_Add_Institution()
    {
        var response = await _fixture.Client.PostAsync(
            ApiPath.SetInstitutionControllerRoute(),
            TestOperations.SetRequestBody(new InstitutionRequest
            {
                Id = Guid.NewGuid(),
                Name = FakeDataHelper.CompanyName(),
                LogoUrl = FakeDataHelper.LogoUrl(),
                Country = FakeDataHelper.Country(),
                Region = FakeDataHelper.Region(),
                City = FakeDataHelper.City(),
                Address = FakeDataHelper.Address(),
                SubscriptionExpiresAt = DateTime.UtcNow.AddYears(1),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            }));

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        string content = await response.Content.ReadAsStringAsync();
        var responseMessage = TestOperations.Deserialize<BaseActionResponse<int>>(content);

        responseMessage?.Message.Should().Be(MessageConstants.Success(RecordType.Save));
        responseMessage?.Data.Should().Be(1);
    }
}
