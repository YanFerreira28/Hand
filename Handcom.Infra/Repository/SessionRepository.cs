

using Handcom.Domain.Entities;
using Handcom.Domain.Interfaces.Repository;
using Handcom.Infra.Data;

namespace Handcom.Infra.Repository
{
    public class SessionRepository : BaseRepository<Session>, ISessionRepository
    {
        public SessionRepository(HandcomContext context) : base(context) { }
    }
}
