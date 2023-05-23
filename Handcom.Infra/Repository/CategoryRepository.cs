using Handcom.Domain.Entities;
using Handcom.Domain.Interfaces.Repository;
using Handcom.Infra.Data;

namespace Handcom.Infra.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(HandcomContext context):base(context) { }
    }
}
