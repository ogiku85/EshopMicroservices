


using Discount.Grpc;

namespace Basket.API.Basket.StoreBasket;

public record StoreBasketResult(string UserName);

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("CartId cannot be null");
        RuleFor(x => x.Cart.Username).NotNull().WithMessage("Username is required");
    }
}

public class StoreBasketCommandHandler(IBasketRepository repository, DiscountProtoService.DiscountProtoServiceClient discountProto) 
    : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {

        await DeductDiscount(command.Cart, cancellationToken);
        
        // Store basket in database (use marten upsert - if exists = update, if not create a new. one)
        await repository.StoreBasket(command.Cart, cancellationToken);
        
        return new StoreBasketResult(command.Cart.Username);
    }

    private async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
    {
        // Commumicate with discount grpc and calculate latest prices of products
        foreach (var item in cart.Items)
        {
            var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest{ ProductName = item.ProductName }, cancellationToken: cancellationToken);
            item.Price -= coupon.Amount;
        }
    }
}