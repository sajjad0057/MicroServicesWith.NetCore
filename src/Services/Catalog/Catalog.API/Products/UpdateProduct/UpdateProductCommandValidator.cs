namespace Catalog.API.Products.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Product Id is required to update product");

        RuleFor(x => x.Name)
           .NotEmpty()
           .WithMessage("Name is Required")
           .Length(2,250)
           .WithMessage("Name length must be between 2 - 250 characters");

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
