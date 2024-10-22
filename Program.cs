using DefaultCorsPolicyNugetPackage;
using DgmBobinajServer.Context;
using DgmBobinajServer.Mapping;
using DgmBobinajServer.Middlewares;
using DgmBobinajServer.Models;
using DgmBobinajServer.Options;
using DgmBobinajServer.Repositories;
using DgmBobinajServer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultCors();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 8;
    options.SignIn.RequireConfirmedEmail = false;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(1);
    options.Lockout.MaxFailedAccessAttempts = 50;
    options.Lockout.AllowedForNewUsers = true;
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
builder.Services.ConfigureOptions<JwtTokenSetupConfiguration>();
builder.Services.AddAuthentication()
    .AddJwtBearer();
builder.Services.AddAuthorizationBuilder();

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();

builder.Services.AddScoped<AppUserRepository>();

builder.Services.AddScoped<LayoutRepository>();
builder.Services.AddScoped<LayoutService>();

builder.Services.AddScoped<LinkRepository>();
builder.Services.AddScoped<LinkService>();

builder.Services.AddScoped<MiniServiceRepository>();
builder.Services.AddScoped<MiniServiceService>();

builder.Services.AddScoped<DescriptionModelRepository>();
builder.Services.AddScoped<DescriptionModelService>();

builder.Services.AddScoped<GaleryRepository>();
builder.Services.AddScoped<GaleryService>();

builder.Services.AddScoped<CommentRepository>();
builder.Services.AddScoped<CommentService>();

builder.Services.AddScoped<WorkDateRepository>();
builder.Services.AddScoped<WorkDateService>();

builder.Services.AddScoped<InformationRepository>();
builder.Services.AddScoped<InformationService>();

builder.Services.AddScoped<ContactRepository>();
builder.Services.AddScoped<ContactService>();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecuritySheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** yourt JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecuritySheme, Array.Empty<string>() }
                });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

ExtensionMiddleware.CreateAdmin(app);

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
