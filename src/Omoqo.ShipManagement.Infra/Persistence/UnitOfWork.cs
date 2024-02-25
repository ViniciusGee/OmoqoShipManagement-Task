using Omoqo.ShipManagement.Domain.Ships.Persistence;

namespace Omoqo.ShipManagement.Infra.Persistence
{
    public class UnitOfWork: IShipUnitOfWork
    { 
        private readonly ShipManagementDbContext _context;

        public UnitOfWork(ShipManagementDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        //Add others ways to commit transaction. 
    }
}
