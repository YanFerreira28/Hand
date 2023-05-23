using Handcom.Domain.Entities;
using Handcom.Domain.Interfaces.Repository;
using Handcom.Infra.Data;

namespace Handcom.Infra.Repository
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(HandcomContext context) : base(context) { }
    }
}
