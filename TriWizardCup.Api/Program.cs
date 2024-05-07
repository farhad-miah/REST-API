using TriWizardCup.DataService.Data;
using TriWizardCup.DataService.Repositories;
using TriWizardCup.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;


var builder = WebApplication.CreateBuilder(args);

// Get Connection String
var connectionString = builder.Configuration.GetConnectionString(name: "DefaultConnection");

// Initialising my DbContext inside the DI Container
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//added in configuration for swagger so it allows users to autheticate themselves by registering, logging in and using the Authorize option at the top to pass in the bearer token
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    opt.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
    app.UseSwaggerUI();
    app.MapIdentityApi<IdentityUser>();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
