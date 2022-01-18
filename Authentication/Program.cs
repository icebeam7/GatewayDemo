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

var users = new List<User>()
{
    new User() { FirstName = "Allan", LastName = "Chua", UserId = Guid.Parse("539bf338-e5de-4fc4-ac65-4a91324d8111")},
    new User() { FirstName = "Burr", LastName = "Sutter", UserId = Guid.Parse("6b2c4788-e1d5-4ef4-8edf-e7d57e31bf4f")},
    new User() { FirstName = "Josh", LastName = "Long", UserId = Guid.Parse("3a4149fa-32e9-4d4a-a051-5c49b7ed2fca")}
};

app.MapGet("/authentication/users", () =>
{
    return users;
})
.WithName("GetAllUsers");

app.MapGet("/authentication/users/byid/{id}", (Guid? id) =>
{
    return users.FirstOrDefault(u => u.UserId == id);
})
.WithName("GetUserById");

app.Run();