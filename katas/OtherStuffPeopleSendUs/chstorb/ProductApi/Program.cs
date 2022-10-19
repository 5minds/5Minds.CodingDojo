#define SWAGGER 
#define SEED 
#define ODATA 
#define STATFILES
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#if ODATA

builder.Services.AddControllers().AddOData(opt => opt.Select().Filter().OrderBy());

#else 

builder.Services.AddControllers();

#endif 

builder.Services.AddTransient<DataSeeder>();
builder.Services.AddDbContext<ProductContext>(opt => opt.UseInMemoryDatabase("ProductList"));

#if SWAGGER

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endif

var app = builder.Build();

#if SEED 

SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    if (scopedFactory != null)
    {
        using (var scope = scopedFactory.CreateScope())
        {
            var service = scope.ServiceProvider.GetService<DataSeeder>();
            if (service != null)
            {
                service.Seed();
            }
        }
    }
}

#endif 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

#if SWAGGER

    app.UseSwagger();
    app.UseSwaggerUI();

#endif
}

#if STATFILES

app.UseDefaultFiles();
app.UseStaticFiles();

#endif 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

