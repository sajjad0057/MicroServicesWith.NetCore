namespace Catalog.API.Products.DeleteProductById;

public class DeleteProductByIdCommandValidator : AbstractValidator<DeleteProductByIdCommand>
{
    public DeleteProductByIdCommandValidator()
    {
        RuleFor(x=> x.Id).NotEmpty().WithMessage("Id must be needed to delete product");
    }
}
