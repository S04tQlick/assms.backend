namespace assms.api.Helpers;

public abstract class FakeDataHelper
{
    private static readonly Faker Faker = new();

    // ✅ Random string
    public static string CompanyName() => Faker.Company.CompanyName();

    // ✅ Random string
    public static string RandomString(int length = 8) =>
        Faker.Random.String(length);

    // ✅ Person data
    public static string FullName() => Faker.Name.FullName();
    public static string FirstName() => Faker.Name.FirstName();
    public static string LastName() => Faker.Name.LastName();
    public static string Email() => Faker.Internet.Email();
    public static string ContactNumber() => Faker.Phone.PhoneNumber();

    // ✅ Location data
    public static string Country() => Faker.Address.Country();
    public static string City() => Faker.Address.City();
    public static string Region() => Faker.Address.State();
    public static string Address() => Faker.Address.FullAddress();
    public static string ZipCode() => Faker.Address.ZipCode();

    // ✅ Dates
    public static DateTime FutureIndefiniteDate() => DateTime.MaxValue;

    public static DateTime FutureDate(int years = 1) =>
        Faker.Date.Future(years, DateTime.UtcNow);

    public static DateTime PastDate(int years = 1) =>
        Faker.Date.Past(years, DateTime.UtcNow);


    // ✅ Coordinates
    public static double Latitude() => Faker.Address.Latitude();
    public static double Longitude() => Faker.Address.Longitude();

    // ✅ Logo URL
    public static string LogoUrl() => Faker.Internet.Avatar();
}