using BE_restful.Areas.AdminEmployee.Models;
using BE_restful.Areas.AdminEmployee.Service;
using BE_restful.Areas.AdminManager.Models.Dao;
using BE_restful.Areas.AdminManager.Service;
using BE_restful.Areas.AdminManager.Services;
using BE_restful.Models;
using BE_restful.Models.Dao;
using BE_restful.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ArtsContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<CustomerService, CustomerDao>();
builder.Services.AddScoped<FAQsService, FAQsDao>();
builder.Services.AddScoped<IAccountUser, AccountUser>();
builder.Services.AddScoped<IDeliveryType, DeliveryTypeDao>();
builder.Services.AddScoped<ILoginAdmin, LoginAdminDao>();
builder.Services.AddScoped<IPayment, PaymentDao>();
builder.Services.AddScoped<IProducts, ProductsDao>();
builder.Services.AddScoped<IUpdatePassword, UpdatePasswordDao>();
builder.Services.AddScoped<OrderService, OrderDao>();
builder.Services.AddScoped<ProductCategoryService, ProductCategoryDao>();
builder.Services.AddScoped<ProductCodeService, ProductCodeDao>();
builder.Services.AddScoped<ProductInventoryService, ProductInventoryDao>();
builder.Services.AddScoped<EmployeeService, EmployeeDao>();
builder.Services.AddScoped<ReturnDetailService, ReturnDetailDao>();

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
