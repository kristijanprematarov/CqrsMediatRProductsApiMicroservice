using CqrsMediatRApi.Models;
using MediatR;

namespace CqrsMediatRApi.Commands;

public record AddProductCommand(Product Product) : IRequest<Product>;