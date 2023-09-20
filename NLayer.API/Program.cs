using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayer.API.Filters;
using NLayer.Core.Repositorys;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository;
using NLayer.Repository.Mapping;
using NLayer.Repository.Repositorys;
using NLayer.Repository.UnitOfWorks;
using NLayer.Service.Services;
using NLayer.Service.Validations;
using System.Reflection;
using NLayer.API.Middlewares;
using NLayer.Caching;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// FLUENTVALIDATORUN QOSULMASI ????????????????????????????????????????????????????????????????????????????????

builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute()))
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDTOValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Caching hissesi program.cs de cagirilmasi
builder.Services.AddMemoryCache();


//Frameworkun Validatorunu filterini baglamaaq??????
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductService, ProductServiceWithCaching>();




builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"), options =>
    {
        //Burada NLayer.Repository yazmal yerine bele yazmaq daha yaxsi ve guvenlidir
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Custom Middleware qosulmasi ??????
app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
