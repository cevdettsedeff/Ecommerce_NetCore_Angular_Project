using ECommerceAPI.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<ViewModel_Create_Product>
    {
        // Ürün oluşturma ile ilgili validation rules buraya yazılır.
        public CreateProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Lütfen ürün adını boş geçmeyiniz.")
                .MaximumLength(150).MinimumLength(3).WithMessage("Lütfen ürün adını 3 ile 150 karakter arasında giriniz");

            RuleFor(p => p.Stock).NotEmpty().NotNull().WithMessage("Lütfen Stok bilgisini boş geçmeyiniz.")
                .Must(s => s >= 0).WithMessage("Stok bilgisi negatif olamaz!");

            RuleFor(p => p.Price).NotEmpty().NotNull().WithMessage("Lütfen fiyat bilgisini boş geçmeyiniz.")
                .Must(s => s >= 0).WithMessage("Fiyat bilgisi negatif olamaz!");
        }
    }
}
