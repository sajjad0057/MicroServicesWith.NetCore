namespace Catalog.API.Products.GetProductById;

/// <summary>
/// Not needed Query validation untill emergency
/// </summary>
public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Need product id to get specific product");
    }
}
