using CreateCustomMiddleware.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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


app.Use(async (context, next) =>
{
	Console.WriteLine("Start Middleware");
	await next.Invoke(); // Kendisinden sonra ki middleware'yi tetiklemek icin kullanilir Invoke fonksiyonu.
	Console.WriteLine("Stop Middleware");
});


app.Run(async context=> // Run middleware'si kendisinden sonra ki middleware gecis yapmaz.   Isini yapar ve kendinden once yarim kalan middleware'lere geri donus
							//yapar.
{
	Console.WriteLine("Run Middleware");

});

app.UseHello();  //Olusturmus Oldugumuz Custom Middleware . 

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
