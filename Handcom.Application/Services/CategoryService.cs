using Handcom.Domain.Entities;
using Handcom.Domain.Interfaces.Service;
using Handcom.Infra.Repository;

namespace Handcom.Application.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(BaseRepository<Category> category) : base(category)
        {

        }
    }
}
