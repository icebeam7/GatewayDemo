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

var transactions = new List<Transaction>()
{
    new Transaction()
    {
        ProductID = Guid.Parse("ef29fc61-abcc-4ac1-9c8c-e5e17b266868"),
        UserID = Guid.Parse("539bf338-e5de-4fc4-ac65-4a91324d8111"),
        OccuredAt = DateTime.Now,
        PriceAtPointInTime = 36,
        Quantity = 5,
        Total = 180
    },
    new Transaction()
    {
        ProductID = Guid.Parse("d91d2019-e642-4b00-8b10-2bf07c383787"),
        UserID = Guid.Parse("6b2c4788-e1d5-4ef4-8edf-e7d57e31bf4f"),
        OccuredAt = DateTime.Now,
        PriceAtPointInTime = 36,
        Quantity = 5,
        Total = 180
    }
};

app.MapGet("/ledger/transactions", () =>
{
    return transactions;
})
.WithName("GetAllTransactions");

app.MapGet("/ledger/transactions/byid/{id}", (Guid? id) =>
{
    return transactions.Where(t => t.UserID == id).ToList();
})
.WithName("GetTransactionById");

app.Run();