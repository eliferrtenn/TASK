using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using VardabitCore.Business.Interfaces;
using VardabitCore.Business.Services;
using VardabitCore.Data.Context;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager _configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;


builder.Services.AddDbContext<VardabitContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});

#region Core Services
builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
builder.Services.AddHttpContextAccessor();
#endregion

#region Services
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IMarkaService, MarkaService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<ISiparisService, SiparisService>();
builder.Services.AddScoped<IVersiyonService, VersiyonService>();
#endregion

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vardabit", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference= new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme,
        }
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[]{}
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

});

#region Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Events = new JwtBearerEvents()
    {
        OnAuthenticationFailed = context =>
        {
            context.Response.OnStarting(() =>
            {
                context.Response.ContentType = "text/plain";
                return global::System.Threading.Tasks.Task.CompletedTask;
            });

            return Task.CompletedTask;
        }
    };

    opt.SaveToken = true;

    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = _configuration["Token:Issuer"],
        ValidAudience = _configuration["Token:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"])),
        ClockSkew = TimeSpan.FromMinutes(5),
    };
});
#endregion
#region Localization
builder.Services.AddLocalization(o => { o.ResourcesPath = "Resources"; });
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();