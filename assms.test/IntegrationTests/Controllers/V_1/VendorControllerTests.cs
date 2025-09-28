using System.Net.Mime;
using assms.api.Constants;
using assms.api.Helpers;
using assms.entities.Enums;
using assms.entities.GeneralResponse;
using assms.entities.Request;
using assms.entities.Response.VendorResponse;
using assms.test.Fixtures;
using assms.test.Helpers;

namespace assms.test.IntegrationTests.Controllers.V_1;

public class VendorControllerTests(ApplicationFixture fixture) : GeneralOperations(fixture), IClassFixture<ApplicationFixture>
{
    private readonly ApplicationFixture _fixture = fixture;

    [Fact]
    public async Task It_Should_Add_New_Vendor()
    {
        var response = await _fixture.Client.PostAsync(
            ApiPath.SetVendorControllerRoute(), TestOperations.SetRequestBody(new VendorRequest
            {
                Id = Guid.NewGuid(),
                Name = FakeDataHelper.CompanyName(),
                ContactName = FakeDataHelper.FullName(),
                ContactPhone = FakeDataHelper.ContactNumber(),
                ContactEmail = FakeDataHelper.Email(),
                Address = FakeDataHelper.Address(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            })
        );
        
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        
        var content = await response.Content.ReadAsStringAsync();
        var responseMessage = TestOperations.Deserialize<BaseActionResponse<int>>(content);

        responseMessage?.Message.Should().Be(MessageConstants.Success(RecordTypeEnum.Save));
        responseMessage?.Data.Should().Be(1);
    }

    [Fact]
    public async Task It_Should_Get_Vendor_By_Date()
    {
        var requestData = await GetVendorByDateAsync(DateTime.UtcNow.ToString("o"));

        if (requestData is not null)
        {
            foreach (var row in requestData.Data!)
            {
                row.Name.Should().NotBeEmpty();
                row.ContactName.Should().NotBeEmpty();
                row.ContactPhone.Should().NotBeEmpty();
                row.ContactEmail.Should().NotBeEmpty();
                row.Address.Should().NotBeEmpty();
            }
        }
    }

    [Fact]
    public async Task It_Should_Update_Vendor()
    {
        
    }
}