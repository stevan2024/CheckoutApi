using Checkout.Database;
using CheckoutApi.Repository;
using CheckoutApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PricingRulesDBContext>(options => { options.UseInMemoryDatabase(databaseName: "PricingRules"); options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); });
builder.Services.AddDbContext<ItemsDBContext>(options => { options.UseInMemoryDatabase(databaseName: "Items"); options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); });
builder.Services.AddScoped<IPricingRulesRepository, PricingRulesRepository>();
builder.Services.AddScoped<IItemsRepository, ItemsRepository>();
builder.Services.AddScoped<ICheckout, CheckoutApi.Services.Checkout>();
builder.Services.AddScoped<IPricing, Pricing>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});



var app = builder.Build();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();


//1. Get the IWebHost which will host this application.
//var host = CreateWebHostBuilder(args).Build();

//2. Find the service layer within our scope.
using (var scope = app.Services.CreateScope())
{
    //3. Get the instance of BoardGamesDBContext in our services layer
    var services = scope.ServiceProvider;
    //var context = services.GetRequiredService<BooksDBContext>();

    //4. Call the DataGenerator to create sample data
    PriceRulesDataGenerator.Initialize(services);
}


app.Run();
