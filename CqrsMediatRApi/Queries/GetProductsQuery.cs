using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsMediatRApi.Models;
using MediatR;

namespace CqrsMediatRApi.Queries;

public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
