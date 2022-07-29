using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsMediatRApi.Models;
using CqrsMediatRApi.Repositories;
using MediatR;

namespace CqrsMediatRApi.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<Product>>;

    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetProductsHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _fakeDataStore.GetAllProducts();
        }
    }
}
