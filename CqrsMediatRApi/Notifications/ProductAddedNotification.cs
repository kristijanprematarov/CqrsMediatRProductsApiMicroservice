using CqrsMediatRApi.Models;
using CqrsMediatRApi.Repositories;
using MediatR;

namespace CqrsMediatRApi.Notifications;

public record ProductAddedNotification(Product Product) : INotification;

public class EmailHandler : INotificationHandler<ProductAddedNotification>
{
    private readonly FakeDataStore _fakeDataStore;

    public EmailHandler(FakeDataStore fakeDataStore)
    {
        _fakeDataStore = fakeDataStore;
    }

    public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
    {
        await _fakeDataStore.EventOccured(notification.Product, "EMAIL WAS SENT");
        await Task.CompletedTask;
    }
}

public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotification>
{
    private readonly FakeDataStore _fakeDataStore;

    public CacheInvalidationHandler(FakeDataStore fakeDataStore)
    {
        _fakeDataStore = fakeDataStore;
    }

    public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
    {
        await _fakeDataStore.EventOccured(notification.Product, "CACHE INVALIDATED");
        await Task.CompletedTask;
    }
}