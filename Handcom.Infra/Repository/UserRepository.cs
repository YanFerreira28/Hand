using Handcom.Domain.Entities;
using Handcom.Domain.Interfaces.Repository;
using Handcom.Infra.Data;

namespace Handcom.Infra.Repository
{
    public class UserRepository : BaseRepository<Users>, IUserRepository
    {
        public UserRepository(HandcomContext context) : base(context) { }
    }
}
