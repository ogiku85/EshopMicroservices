using MediatR;

namespace BuildingBlocks.CQRS;
/// <summary>
/// This is a generic interface that represents a query in the CQRS. The out keyword makes TResponse covariant,
/// It cannot be used as an input parameter in methods inside this interface
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
{
    
}