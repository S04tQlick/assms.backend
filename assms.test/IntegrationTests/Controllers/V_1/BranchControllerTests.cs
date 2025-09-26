using assms.api.Constants;
using assms.api.Helpers;
using assms.entities;
using assms.entities.GeneralResponse;
using assms.entities.Request;
using assms.entities.Response.BranchResponse;
using assms.test.Fixtures;
using assms.test.Helpers;

namespace assms.test.IntegrationTests.Controllers.V_1;

public class BranchControllerTests(ApplicationFixture fixture) : InstitionOperations(fixture), IClassFixture<ApplicationFixture>
{
    private readonly ApplicationFixture _fixture = fixture;

    [Fact]
    public async Task It_Should_Add_Branch()
    {
        var institutionData = await GetInstitutionByDateAsync(DateTime.UtcNow.ToString("o"));
        var row = institutionData?.Data?.FirstOrDefault();
        row.Should().NotBeNull();

        var instId = row.InstitutionId;

        var response = await _fixture.Client.PostAsync(
            ApiPath.SetBranchControllerRoute(),
            TestOperations.SetRequestBody(new BranchRequest
            {
                Id = Guid.NewGuid(),
                InstitutionId = row.InstitutionId,
                Name = FakeDataHelper.CompanyName(),
                Address = FakeDataHelper.Address(),
                City = FakeDataHelper.City(),
                Region = FakeDataHelper.Region(),
                Country = FakeDataHelper.Country(),
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Latitude = FakeDataHelper.Latitude(),
                Longitude = FakeDataHelper.Longitude(),
            }));

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        string content = await response.Content.ReadAsStringAsync();
        var responseMessage = TestOperations.Deserialize<BaseActionResponse<int>>(content);

        responseMessage?.Message.Should().Be(MessageConstants.Success(RecordType.Save));
        responseMessage?.Data.Should().Be(1);
    }
}