var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.MapGet("/catalog/products", () =>
{
    var products = new List<Product>()
    {
        new Product() { Name = "Azure Shirt", ProductId = Guid.Parse("ef29fc61-abcc-4ac1-9c8c-e5e17b266868") },
        new Product() { Name = "ASP.net Core Shirt", ProductId = Guid.Parse("618808a6-8466-4fd8-80da-e8651ec0c0e4") },
        new Product() { Name = "Node JS Shirt", ProductId = Guid.Parse("dc2bd686-7eaf-44a3-9fdd-b3645fef9a02") },
        new Product() { Name = "Spring Shirt", ProductId = Guid.Parse("d91d2019-e642-4b00-8b10-2bf07c383787") }
    };
    return products;
})
.WithName("GetAllProducts");

app.Run();