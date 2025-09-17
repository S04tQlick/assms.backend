namespace assms.api.Helpers;

public static class ReturnEnv
{
    public static string Env(string recQuery)
    {
        var env = Environment.GetEnvironmentVariable(recQuery) ?? throw new Exception($"{recQuery} missing");
        return env;
    }
}