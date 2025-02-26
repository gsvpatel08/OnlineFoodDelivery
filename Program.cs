using System.Reflection.Emit;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OnlineFoodDelivery.Data;
using OnlineFoodDelivery.model;
using OnlineFoodDelivery.Repository;
using OnlineFoodDelivery.Service;
using OnlineFoodDelivery.Service.Interfaces;
using OnlineFoodDelivery.Utility;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OnlineFoodDeliveryDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<OnlineFoodDeliveryDB,OnlineFoodDeliveryDB>();

builder.Services.AddScoped<OnlineFoodDelivery.Utility.JwtHelper>();
builder.Services.AddScoped<OnlineFoodDelivery.Utility.IEmailService, EmailService>();
builder.Services.AddTransient<EmailService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IRestaurentOwnerRepo, RestaurentOwnerRepository>();
builder.Services.AddScoped<IRestaurentOwnerService, RestaurentOwnerService>();
builder.Services.AddScoped<IRestaurentRepository,RestaurantRepository>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService , CategoryService>();
builder.Services.AddScoped<IFoodItemRepository, FoodItemRepository>();
builder.Services.AddScoped<IFoodItemsService, FoodItemService>();
builder.Services.AddScoped<IOrderService, OrdersService>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
        


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"])),
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"]
           
        };
    });

builder.Services.AddAuthorization(options =>{
options.AddPolicy(IdentityData.AdminUserPolicyClaims, p=> p.RequireClaim(IdentityData.AdminUserPolicyClaims,"True"));
    });

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



app.MapControllers();

app.UseAuthorization();
app.Run();
