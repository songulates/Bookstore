using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<BookStrDbContext>(options => options.UseInMemoryDatabase(databaseName : "BookStoreDB"));
//UYGULAMA içinde kulanılan servislerin implemente edildiği yer database servis bizim için uygulama içinde kullanılması için inject edilmesi lazım
//inmemory databse kullanıcaz buda bize entity framworkden geliyo uygulamamya contexi göstermiş olduk
var app = builder.Build();


using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services); //datayi inseert etmek için service provider kullaıyo
    
}

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
