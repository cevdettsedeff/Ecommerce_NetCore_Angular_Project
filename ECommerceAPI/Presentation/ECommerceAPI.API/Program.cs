using ECommerceAPI.Application.Validators.Products;
using ECommerceAPI.Infrastructure.Filters;
using ECommerceAPI.Persistence;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();

// CORS kullan�rken nereden gelen istekleri kabul edece�imize WithOrigins ile karar verebiliyoruz.
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()));

// Fluent Validation kullanmak i�in alttaki gibi kodu ekliyoruz. Sadece CreateProduct eklememize ra�men o klas�r i�indeki t�m validatorler ge�erli olacakt�r.

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();
builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>()).ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

//builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>()).
//    AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>()).ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseCors(); //Yukar�da uygulanan cors politikalar� i�in middleware eklemesini yap�yoruz.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
