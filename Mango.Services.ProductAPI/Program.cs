using AutoMapper;
using Mango.Services.ProductAPI;
using Mango.Services.ProductAPI.DbContext;
using Mango.Services.ProductAPI.Repository;
using Mango.Services.ProductAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//- ************* Add services to the container ************* 
//. DbContext
var DefaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(DefaultConnection));

//. Mapper
var mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//. Dependency Injection :
builder.Services.AddScoped<IProductRepository, ProductRepository>();
    
//. MVC
builder.Services.AddControllers();

//. Swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//- *************  Configure the HTTP request pipeline ************* 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();