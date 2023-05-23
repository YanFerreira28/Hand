using Handcom.Domain.Entities;
using Handcom.Domain.Interfaces.Service;
using Handcom.Infra.Repository;

namespace Handcom.Application.Services
{
    public class ProductService : BaseService<Products>, IProductService
    {
        public ProductService(BaseRepository<Products> product) : base(product)
        {

        }
    }
}
