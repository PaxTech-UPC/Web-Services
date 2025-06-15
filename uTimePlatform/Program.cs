using Microsoft.EntityFrameworkCore;
using uTimePlatform.Profiles.Application.Internal.CommandServices;
using uTimePlatform.Profiles.Application.Internal.QueryServices;
using uTimePlatform.Profiles.Domain.Services;
using uTimePlatform.Profiles.Domain.Repositories;
using uTimePlatform.Profiles.Infrastructure.Persistence.EFC.Repositories;
using uTimePlatform.Shared.Domain.Repositories;
using uTimePlatform.Shared.Infrastructure.Interfaces.ASP.Configuration;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Repositories;


//IAM BOUNDED CONTEXT
using Microsoft.OpenApi.Models;
using uTimePlatform.IAM.Application.Internal.CommandServices;
using uTimePlatform.IAM.Application.Internal.OutboundServices;
using uTimePlatform.IAM.Application.Internal.QueryServices;
using uTimePlatform.IAM.Domain.Repositories;
using uTimePlatform.IAM.Domain.Services;
using uTimePlatform.IAM.Infrastructure.Hashing.BCrypt.Services;
using uTimePlatform.IAM.Infrastructure.Tokens.JWT.Configuration;
using uTimePlatform.IAM.Infrastructure.Tokens.JWT.Services;
using uTimePlatform.IAM.Infrastructure.Persistence.EFC.Repositories;
using uTimePlatform.IAM.Interfaces.ACL;
using uTimePlatform.IAM.Interfaces.ACL.Services;
using uTimePlatform.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using uTimePlatform.Workers.Application.Internal.CommandServices;
using uTimePlatform.Workers.Application.Internal.QueryServices;
using uTimePlatform.Workers.Domain.Repositories;
using uTimePlatform.Workers.Domain.Services;
using uTimePlatform.Workers.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ---------- SERVICES ----------

// Add Swagger & Controllers
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "uTime Platform API",
        Version = "v1",
        Description = "API documentation for uTime Platform"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter JWT token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

    options.EnableAnnotations();
});

// ---------- DATABASE ----------

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString is null)
    throw new Exception("Database connection string is not set");

if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });
else if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Error)
                .EnableSensitiveDataLogging();
        });

// ---------- DEPENDENCY INJECTION ----------

// Shared
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Profiles
builder.Services.AddScoped<IClientCommandService, ClientCommandServices>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientQueryService, ClientQueryService>();

//Workers
builder.Services.AddScoped<IWorkerCommandService, WorkerCommandServices>();
builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
builder.Services.AddScoped<IWorkerQueryService, WorkerQueryService>();

// IAM Bounded Context
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

// JWT Config
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));


// ---------- APP BUILD ----------

var app = builder.Build();

// Ensure DB created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// ---------- MIDDLEWARE ----------

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();


// JWT Auth Middleware (si lo usas)
app.UseAuthentication();

// Tu middleware personalizado de autorización
app.UseRequestAuthorization();

app.UseAuthorization();
app.MapControllers();
app.Run();
