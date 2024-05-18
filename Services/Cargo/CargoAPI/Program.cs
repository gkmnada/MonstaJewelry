using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["IdentityServer"];
    options.Audience = "ResourceCargo";
});

builder.Services.AddTransient<DapperContext>();

builder.Services.AddTransient<ICargoCompanyDal, CargoCompanyRepository>();
builder.Services.AddTransient<ICargoCompanyService, CargoCompanyManager>();

builder.Services.AddTransient<ICargoCustomerDal, CargoCustomerRepository>();
builder.Services.AddTransient<ICargoCustomerService, CargoCustomerManager>();

builder.Services.AddTransient<ICargoDetailDal, CargoDetailRepository>();
builder.Services.AddTransient<ICargoDetailService, CargoDetailManager>();

builder.Services.AddTransient<ICargoOperationDal, CargoOperationRepository>();
builder.Services.AddTransient<ICargoOperationService, CargoOperationManager>();

builder.Services.AddControllers();
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

app.MapControllers();

app.Run();
