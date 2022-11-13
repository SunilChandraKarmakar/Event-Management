using EventManagementService.DatabaseSetting;
using EventManagementService.Model.Models;
using EventManagementService.RepositoryService.DishService;
using EventManagementService.RepositoryService.EventTypeService;
using EventManagementService.RepositoryService.FoodService;
using EventManagementService.RepositoryService.FoodTypeService;
using EventManagementService.RepositoryService.MealTypeService;
using EventManagementService.RepositoryService.PaymentService;
using EventManagementService.RepositoryService.PaymentTypeService;
using EventManagementService.RepositoryService.VenueService;
using EventManagementService.RepositoryService.VenueTypeService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//// Add database connection.
builder.Services.AddDbContext<EventManagementDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add JWT
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JWTConfig"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    byte[] key = System.Text.Encoding.ASCII.GetBytes(builder.Configuration["JWTConfig:Key"]);
    string isSuer = builder.Configuration["JWTConfig:Issuer"];
    string audience = builder.Configuration["JWTConfig:Audience"];

    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        RequireExpirationTime = true,
        ValidIssuer = isSuer,
        ValidAudience = audience
    };
});

//Add CORS
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowOrigin", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

// Add identity table
builder.Services.AddIdentity<User, IdentityRole>(option =>
       { }).AddEntityFrameworkStores<EventManagementDbContext>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddTransient<IVenueRepository, VenueRepository>();
builder.Services.AddTransient<IEventTypeRepository, EventTypeRepository>();
builder.Services.AddTransient<IVenueTypeRepository, VenueTypeRepository>();
builder.Services.AddTransient<IFoodTypeRepository, FoodTypeRepository>();
builder.Services.AddTransient<IMealTypeRepository, MealTypeRepository>();
builder.Services.AddTransient<IDishTypeRepository, DishTypeRepository>();
builder.Services.AddTransient<IFoodRepository, FoodRepository>();
builder.Services.AddTransient<IPaymentTypeRepository, PaymentTypeRepository>();
builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();

builder.Services.AddControllers()
       .AddNewtonsoftJson(options =>
         options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
   
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("AllowOrigin");

app.MapControllers();

app.Run();