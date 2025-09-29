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
        builder.Services.AddScoped(typeof(IQueryHandler<>), typeof(QueryHandler<>));
        
        //User roles
        builder.Services.AddSingleton<IAuthorizationPolicyProvider, DynamicAuthorizationPolicyProvider>();
        builder.Services.AddScoped<IAuthorizationHandler, RoleAuthorizationHandler>();
        
        //Auth repository and services
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IAuthRepository, AuthRepository> ();
       
        //Institution repository and services
        builder.Services.AddScoped<IInstitutionService, InstitutionService>();
        builder.Services.AddScoped<IInstitutionRepository, InstitutionRepository>(); 
        
        //Branch repository and services
        builder.Services.AddScoped<IBranchService, BranchService>();
        builder.Services.AddScoped<IBranchRepository, BranchRepository>();
        
        //Branch repository and services
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        
        //AssetType repository and services
        builder.Services.AddScoped<IAssetTypeService, AssetTypeService>();
        builder.Services.AddScoped<IAssetTypeRepository, AssetTypeRepository>();
        
        //AssetCategory repository and services
        builder.Services.AddScoped<IAssetCategoryService, AssetCategoryService>();
        builder.Services.AddScoped<IAssetCategoryRepository, AssetCategoryRepository>();
        
        //Asset repository and services
        builder.Services.AddScoped<IAssetService, AssetService>();
        builder.Services.AddScoped<IAssetRepository, AssetRepository>();
        
        //Vendor repository and services
        builder.Services.AddScoped<IVendorService, VendorService>();
        builder.Services.AddScoped<IVendorRepository, VendorRepository>();
        
        builder.Services.AddTransient<GlobalExceptionHandler>();
    }

    public static void AddUsings(this WebApplicationBuilder builder)
    {
        var app = builder.Build();

        var  scope= app.Services.CreateScope();
        _ = DatabaseSeeder.SeedAsync(scope.ServiceProvider.GetRequiredService<ApplicationDbContext>());
        
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
            options.UseNpgsql(ReturnHelpers.Env("DATABASE_CONNECTION_STRING_DEV")));
    
        // Redis
        services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(ReturnHelpers.Env("REDIS_CONNECTION_STRING")!));
       
        services.AddSignalR()
            .AddStackExchangeRedis(ReturnHelpers.Env("REDIS_CONNECTION_STRING") ?? throw new Exception("REDIS_CONNECTION_STRING Missing"), options =>
                options.Configuration.ChannelPrefix = new RedisChannel( "ASMS", RedisChannel.PatternMode.Literal));
        
        // EMAIL
        services.Configure<EmailSettings>(options =>
        {
            options.SmtpServer = ReturnHelpers.Env("EMAIL_SMTP_SERVER");
            options.Port = int.Parse(ReturnHelpers.Env("EMAIL_SMTP_PORT"));
            options.SenderName = ReturnHelpers.Env("EMAIL_SENDER_NAME");
            options.SenderEmail = ReturnHelpers.Env("EMAIL_FROM");
            options.Username = ReturnHelpers.Env("EMAIL_USERNAME");
            options.Password = ReturnHelpers.Env("EMAIL_PASSWORD");
            options.UseSsl = bool.Parse(ReturnHelpers.Env("EMAIL_USE_SSL"));
        });
    
        // JWT
        services.Configure<JwtSettings>(options =>
        {
            options.Secret = ReturnHelpers.Env("JWT_SECRET");
            options.Issuer = ReturnHelpers.Env("JWT_ISSUER");
            options.Audience = ReturnHelpers.Env("JWT_AUDIENCE");
            options.AccessTokenExpirationMinutes = int.Parse(ReturnHelpers.Env("ACCESS_TOKEN_EXP_MIN"));
            options.RefreshTokenExpirationDays = int.Parse(ReturnHelpers.Env("REFRESH_TOKEN_EXP_DAYS"));
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
                ValidIssuer = ReturnHelpers.Env("JWT_ISSUER"),
                ValidAudience = ReturnHelpers.Env("JWT_AUDIENCE"),
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(ReturnHelpers.Env("JWT_SECRET")!))
            };
        });
        
        services.AddAuthorization();
    }
}