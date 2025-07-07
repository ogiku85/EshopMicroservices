using MediatR;

namespace BuildingBlocks.CQRS;

/// <summary>
/// This is for commamnds that dont return a response
/// </summary>
public interface ICommand : ICommand<Unit>
{
    
}
/// <summary>
/// This is for commamnds that return a response.The out keyword makes TResult covariant,
/// meaning it can be replaced with a more derived type in return values but cannot be used as an input parameter
/// </summary>
public interface ICommand<out TResult> : IRequest<TResult>
{
    
}