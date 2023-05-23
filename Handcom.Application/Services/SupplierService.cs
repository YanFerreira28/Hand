using Handcom.Domain.Entities;
using Handcom.Domain.Interfaces.Service;
using Handcom.Infra.Repository;

namespace Handcom.Application.Services
{
    public class SupplierService : BaseService<Supplier>, ISupplierService
    {
        public SupplierService(BaseRepository<Supplier> supplier) : base(supplier)
        {

        }
    }
}
