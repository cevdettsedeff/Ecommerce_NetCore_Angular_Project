using ECommerceAPI.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();

// CORS kullanýrken nereden gelen istekleri kabul edeceðimize WithOrigins ile karar verebiliyoruz.
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

app.UseCors(); //Yukarýda uygulanan cors politikalarý için middleware eklemesini yapýyoruz.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
