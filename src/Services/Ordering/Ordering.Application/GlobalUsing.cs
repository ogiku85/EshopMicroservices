global using BuildingBlocks.CQRS;
global using Ordering.Application.Data;
global using Ordering.Application.Dtos;
global using Ordering.Domain.Models;
global using Ordering.Domain.ValueObjects;
global using Ordering.Application.Exceptions;
global using MediatR;
global using Microsoft.Extensions.Logging;
global using Ordering.Domain.Events;
global using Microsoft.EntityFrameworkCore;
global using Ordering.Application.Extensions;
global using BuildingBlocks.Pagination;
using Ordering.Application.Orders.Queries.GetOrdersByCustomer;