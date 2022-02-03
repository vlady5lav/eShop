using MVC.Services;
using MVC.Services.Interfaces;
using MVC.ViewModels;

var configuration = GetConfiguration();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllersWithViews(options => options.Filters.Add(typeof(HttpGlobalExceptionFilter)))
    .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);

builder.AddConfiguration();

var identityUrl = configuration.GetValue<string>("IdentityUrl");
var callbackUrl = configuration.GetValue<string>("CallbackUrl");
var redirectUrl = configuration.GetValue<string>("RedirectUrl");

var sessionCookieLifetime = configuration.GetValue("SessionCookieLifetimeMinutes", 60);

builder.Services
    .AddAuthentication(options => options.DefaultScheme = OpenIdConnectDefaults.AuthenticationScheme)
    .AddCookie(setup => setup.ExpireTimeSpan = TimeSpan.FromMinutes(sessionCookieLifetime))
    .AddOpenIdConnect(options =>
    {
        options.Authority = identityUrl;
        options.ClientId = "mvc_pkce";
        options.ClientSecret = "secret";
        options.GetClaimsFromUserInfoEndpoint = true;
        options.RequireHttpsMetadata = false;
        options.ResponseType = "code";
        options.SaveTokens = true;
        options.SignedOutRedirectUri = callbackUrl;
        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.UsePkce = true;

        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("mvc");

        options.Events.OnRedirectToIdentityProvider = async n =>
        {
            n.ProtocolMessage.RedirectUri = redirectUrl;
            await Task.FromResult(0);
        };
    });

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "eShop - MVC HTTP API",
        Version = "v1",
        Description = "The MVC Service HTTP API",
    });

    var authority = configuration["Authorization:Authority"];

    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows()
        {
            Implicit = new OpenApiOAuthFlow()
            {
                AuthorizationUrl = new Uri($"{authority}/connect/authorize"),
                TokenUrl = new Uri($"{authority}/connect/token"),
                Scopes = new Dictionary<string, string>()
                {
                    { "mvc", "website" },
                },
            },
        },
    });

    options.OperationFilter<AuthorizeCheckOperationFilter>();
});

builder.Services.Configure<AppSettings>(configuration);

builder.Services.AddHttpClient();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddTransient<ICatalogService, CatalogService>();
builder.Services.AddTransient<IHttpClientService, HttpClientService>();
builder.Services.AddTransient<IIdentityParser<ApplicationUser>, IdentityParser>();

builder.Services.AddCors(
    options => options
    .AddPolicy(
        "CorsPolicy",
        builder => builder
            .SetIsOriginAllowed((host) => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()));

var app = builder.Build();

app.UseSwagger()
    .UseSwaggerUI(setup =>
    {
        setup.SwaggerEndpoint($"{configuration["PathBase"]}/swagger/v1/swagger.json", "MVC.API V1");
        setup.OAuthClientId("mvcswaggerui");
        setup.OAuthAppName("MVC Swagger UI");
    });

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("default", "{controller=Catalog}/{action=Index}/{id?}");
    endpoints.MapControllerRoute("defaultError", "{controller=Error}/{action=Error}");
    endpoints.MapControllers();
});

app.Run();

IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    return builder.Build();
}
