namespace Catalog.API.Products.GetProductsByCategory;

/// <summary>
/// Not needed Query validation untill emergency
/// </summary>
public class GetProductByCategoryQueryValidator : AbstractValidator<GetProductsByCategoryQuery>
{
    public GetProductByCategoryQueryValidator()
    {
        RuleFor(x => x.Category).NotEmpty().WithMessage("Need categoty type to filter product by category");
    }
}
