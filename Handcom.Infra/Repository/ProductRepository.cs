

using Handcom.Domain.Entities;
using Handcom.Domain.Interfaces.Repository;
using Handcom.Infra.Data;

namespace Handcom.Infra.Repository
{
    public class ProductRepository : BaseRepository<Products>, IProductRepository
    {
        public ProductRepository(HandcomContext context) : base(context) { }
    }
}
