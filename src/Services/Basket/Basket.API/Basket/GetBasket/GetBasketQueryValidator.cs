using FluentValidation;

namespace Basket.API.Basket.GetBasket;
/// <summary>
/// It's not needed this time,, In emergency or need to validate parameter with regex or etc.
/// then it might be needing
/// </summary>
public class GetBasketQueryValidator : AbstractValidator<GetBasketQuery>
{
    public GetBasketQueryValidator()
    {
        RuleFor(x=>x.userName)
            .NotEmpty()
            .WithMessage("User name needed as parameter");
    }
}
