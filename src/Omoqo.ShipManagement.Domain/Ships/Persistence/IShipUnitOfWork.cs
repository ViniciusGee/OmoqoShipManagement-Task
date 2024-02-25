namespace Omoqo.ShipManagement.Domain.Ships.Persistence
{
    public interface IShipUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
