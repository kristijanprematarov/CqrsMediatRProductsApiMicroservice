﻿using CqrsMediatRApi.Models;
using CqrsMediatRApi.Queries;
using CqrsMediatRApi.Repositories;
using MediatR;

namespace CqrsMediatRApi.Handlers;

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