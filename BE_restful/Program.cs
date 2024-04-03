using BE_restful.Areas.AdminEmployee.Models;
using BE_restful.Areas.AdminEmployee.Service;
using BE_restful.Areas.AdminManager.Models.Dao;
using BE_restful.Areas.AdminManager.Service;
using BE_restful.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ArtsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<ProductCategoryService, ProductCategoryDao>();
builder.Services.AddScoped<ProductInventoryService, ProductInventoryDao>();
builder.Services.AddScoped<EmployeeService, EmployeeDao>();
builder.Services.AddScoped<CustomerService, CustomerDao>();
builder.Services.AddScoped<OrderDetailService, OrderDetailDao>();
builder.Services.AddScoped<StockProductService, StockProductDao>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
