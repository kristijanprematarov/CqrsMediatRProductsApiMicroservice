using CqrsMediatRApi.Models;
using MediatR;

namespace CqrsMediatRApi.Queries;

public record GetProductByIdQuery(int Id) : IRequest<Product>;