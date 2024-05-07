using Asp.Versioning;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using TriWizardCup.DataService.Data;
using TriWizardCup.DataService.Repositories;
using TriWizardCup.DataService.Repositories.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Get Connection String
var connectionString = builder.Configuration.GetConnectionString(name: "DefaultConnection");

// Initialising my DbContext inside the DI Container
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Added in configuration for swagger so it allows users to autheticate themselves by registering, logging in and using the Authorize option at the top to pass in the bearer token
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    opt.OperationFilter<SecurityRequirementsOperationFilter>();

    // Adding functionality of the versions of API to swagger
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "API V1", Version = "v1" });
    opt.SwaggerDoc("v2", new OpenApiInfo { Title = "API V2", Version = "v2" });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddApiVersioning(opt => 
{
    // Enable assuming default version when the client request doesn't specify a version.
    opt.AssumeDefaultVersionWhenUnspecified = true;
    // Specify the default version here. 
    opt.DefaultApiVersion = new ApiVersion(1, 0);
    // Enable reporting of API versions in the response headers.
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(
        // This reader extracts the API version from the query string of the request. It looks for a query parameter named "api-version" to determine the version.
        new QueryStringApiVersionReader("api-version"),
        // This reader extracts the API version from a custom header of the request. It looks for a header named "api-version" to determine the version.
        new HeaderApiVersionReader("api-version"),
        // This reader extracts the API version from the URL segments of the request.It parses the URL path to identify the version information.
        new UrlSegmentApiVersionReader()
    );
}).AddApiExplorer(opt =>
{
    opt.GroupNameFormat = "'v'V";
    opt.SubstituteApiVersionInUrl = true;
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

// Configure authentication and authorization services
builder.Services.AddAuthorization();

// Configure Identity API endpoints and Entity Framework stores
// This section configures Identity for user authentication and management in the ASP.NET Core application.
// - AddIdentityApiEndpoints<IdentityUser>() sets up API endpoints for user authentication and management,
//   allowing users to register, login, retrieve tokens, and perform other authentication-related tasks.
// - AddEntityFrameworkStores<AppDbContext>() configures Entity Framework Core as the storage mechanism
//   for user data, enabling Identity to interact with the database to store and retrieve user information,
//   roles, claims, and other related data.
// Together, these configurations integrate Identity into the application, providing a robust authentication
// and user management system with support for custom user data storage and retrieval through Entity Framework.
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<AppDbContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        // Making a UI to interact with the endpoints in each version
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "API V2");
    });
    app.MapIdentityApi<IdentityUser>();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
