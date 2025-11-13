using TechnicalExercise.Models;
using TechnicalExercise.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

// Register services
builder.Services.AddSingleton<IPaymentGateway, MockPaymentGateway>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/api/transactions/batch", async (List<Transaction> transactions, IPaymentGateway paymentGateway) =>
{
    var results = new List<TransactionResult>();

    foreach (var transaction in transactions)
    {
        var result = await paymentGateway.ProcessPaymentAsync(transaction);
        results.Add(result);
    }

    return Results.Ok(results);
});

app.Run();
