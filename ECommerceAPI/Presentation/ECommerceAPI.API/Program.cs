using ECommerceAPI.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();

// CORS kullan�rken nereden gelen istekleri kabul edece�imize WithOrigins ile karar verebiliyoruz.
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("https://localhost:4200").AllowAnyHeader()));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(); //Yukar�da uygulanan cors politikalar� i�in middleware eklemesini yap�yoruz.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
