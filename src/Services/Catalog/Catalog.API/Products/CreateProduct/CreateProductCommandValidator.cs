namespace Catalog.API.Products.CreateProduct;

public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
         RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is Required");

        RuleFor(x => x.Category)
           .NotEmpty()
           .WithMessage("Category is Required");

        RuleFor(x => x.ImageFile)
           .NotEmpty()
           .WithMessage("Image Fileme is Required");

        RuleFor(x => x.Price)
           .NotEmpty()
           .WithMessage("Price is Required")
           .GreaterThan(1)
           .WithMessage("Price must be greater than one ");          
    }
}
