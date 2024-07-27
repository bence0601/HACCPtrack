using HACCPTrack.Data;
using HACCPTrack.Services;
using HACCPTrack.Services.Authentication;
using HACCPTrack.Services.CheckItemServices;
using HACCPTrack.Services.InviteLinks;
using HACCPTrack.Services.LogServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Konfigur�ci� bet�lt�se
builder.Configuration.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);

// Identity konfigur�ci� hozz�ad�sa
AddAuthentication(builder.Configuration);
AddIdentity(builder.Services);

// Szolg�ltat�sok hozz�ad�sa a kont�nerhez
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureServices();

// Swagger konfigur�ci�
ConfigureSwagger(builder.Services);


var app = builder.Build();

// Szerepk�r�k l�trehoz�sa
AddRoles(app);

// CORS konfigur�ci�
app.UseCors(builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
});

// HTTP k�r�s pipeline konfigur�l�sa
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Autentik�ci� �s autoriz�ci� haszn�lata
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// �j v�gpont a szerver �llapot�nak ellen�rz�s�re
app.MapGet("/status", () => Results.Ok(new { status = "ok" }));

app.Run();

    void ConfigureServices()
    {
        builder.Services.AddDbContext<DataContext>();

        // Szolg�ltat�sok regisztr�l�sa
        builder.Services.AddScoped<IInviteService, InviteService>();
        builder.Services.AddScoped<InviteService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<ICheckItemService, CheckItemService>();
        builder.Services.AddScoped<ILogService, LogService>();
        builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();

        // Controllers regisztr�l�sa
        builder.Services.AddControllers();

    }
void AddAuthentication(IConfiguration configuration)
{
    var jwtSettings = configuration.GetSection("JwtSettings");
    var secretKey = jwtSettings.GetValue<string>("SecretKey");

    builder.Services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.IncludeErrorDetails = true;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ClockSkew = TimeSpan.Zero,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "apiWithAuthBackend",
                ValidAudience = "apiWithAuthBackend",
                IssuerSigningKey = new SymmetricSecurityKey(
                    PadKey(Encoding.UTF8.GetBytes(secretKey), 32)
                ),
            };
        });
}

void AddIdentity(IServiceCollection services)
{
    services
        .AddIdentityCore<IdentityUser>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.User.RequireUniqueEmail = true;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<DataContext>();
}

void ConfigureSwagger(IServiceCollection services)
{
    services.AddSwaggerGen(option =>
    {
        option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });
        option.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                new string[]{}
            }
        });
    });
}

void AddRoles(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var tAdmin = CreateAdminRole(roleManager);
    tAdmin.Wait();

    var tUser = CreateUserRole(roleManager);
    tUser.Wait();

    var tRestaurantAdmin = CreateRestaurantAdminRole(roleManager);
    tRestaurantAdmin.Wait();

    var tRestaurantUser = CreateRestaurantUserRole(roleManager);
    tRestaurantUser.Wait();
}

async Task CreateAdminRole(RoleManager<IdentityRole> roleManager)
{
    await roleManager.CreateAsync(new IdentityRole("Admin"));
}

async Task CreateUserRole(RoleManager<IdentityRole> roleManager)
{
    await roleManager.CreateAsync(new IdentityRole("User"));
}

async Task CreateRestaurantAdminRole(RoleManager<IdentityRole> roleManager)
{
    await roleManager.CreateAsync(new IdentityRole("RestaurantAdmin"));
}

async Task CreateRestaurantUserRole(RoleManager<IdentityRole> roleManager)
{
    await roleManager.CreateAsync(new IdentityRole("RestaurantUser"));
}

byte[] PadKey(byte[] key, int length)
{
    if (key.Length >= length)
    {
        return key;
    }

    byte[] paddedKey = new byte[length];
    Array.Copy(key, paddedKey, key.Length);
    return paddedKey;
}
