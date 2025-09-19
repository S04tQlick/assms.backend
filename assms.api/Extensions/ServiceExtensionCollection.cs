using System.Text;
using Asp.Versioning;
using assms.api.DAL.DatabaseContext;
using assms.api.Helpers;
using assms.entities.Config;
using assms.entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using StackExchange.Redis;

namespace assms.api.Extensions;

public static class ServiceExtensionCollection
{
   
    public static void AddDependencyInjection(this WebApplicationBuilder builder)
    {
        Log.Logger = AmssLogger.CreateLogger();

        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();
        builder.Services.ConfigureApiVersioning();
        builder.Services.AddDbContext();


        

    }

    public static void AddUsings(this WebApplicationBuilder builder)
    {
        var app = builder.Build();


        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.MapControllers();
        
        app.Run();
    }

    private static void ConfigureApiVersioning(this IServiceCollection services)
    {
        services
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddMvc()
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
    }

    private static void AddDbContext(this IServiceCollection services)
    {
        // Db
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(ReturnEnv.Env("DATABASE_CONNECTION_STRING_DEV")));
    
        // Redis
        services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(ReturnEnv.Env("REDIS_CONNECTION_STRING")!));
       
        
        services.AddSignalR()
            .AddStackExchangeRedis(ReturnEnv.Env("REDIS_CONNECTION_STRING") ?? throw new Exception("REDIS_CONNECTION_STRING Missing"), options =>
                options.Configuration.ChannelPrefix = new RedisChannel( "ASMS", RedisChannel.PatternMode.Literal));
        
        // EMAIL
        services.Configure<EmailSettings>(options =>
        {
            options.SmtpServer = ReturnEnv.Env("EMAIL_SMTP_SERVER");
            options.Port = int.Parse(ReturnEnv.Env("EMAIL_SMTP_PORT"));
            options.SenderName = ReturnEnv.Env("EMAIL_SENDER_NAME");
            options.SenderEmail = ReturnEnv.Env("EMAIL_FROM");
            options.Username = ReturnEnv.Env("EMAIL_USERNAME");
            options.Password = ReturnEnv.Env("EMAIL_PASSWORD");
            options.UseSsl = bool.Parse(ReturnEnv.Env("EMAIL_USE_SSL"));
        });
        
    
        // JWT
        services.Configure<JwtSettings>(options =>
        {
            options.Secret = ReturnEnv.Env("JWT_SECRET");
            options.Issuer = ReturnEnv.Env("JWT_ISSUER");
            options.Audience = ReturnEnv.Env("JWT_AUDIENCE");
            options.AccessTokenExpirationMinutes = int.Parse(ReturnEnv.Env("ACCESS_TOKEN_EXP_MIN"));
            options.RefreshTokenExpirationDays = int.Parse(ReturnEnv.Env("REFRESH_TOKEN_EXP_DAYS"));
        });
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
        {
            o.RequireHttpsMetadata = false;
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = ReturnEnv.Env("JWT_ISSUER"),
                ValidAudience = ReturnEnv.Env("JWT_AUDIENCE"),
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(ReturnEnv.Env("JWT_SECRET")!))
            };
        });
        
        services.AddAuthorization();
    }
}