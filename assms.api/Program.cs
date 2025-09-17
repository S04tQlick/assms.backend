using assms.api.Extensions;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.AddDependencyInjection();

builder.AddUsings();

public abstract partial class Program;