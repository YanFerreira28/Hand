using Handcom.Domain.Entities;
using Handcom.Domain.Interfaces.Service;
using Handcom.Infra.Repository;
using System.Linq;

namespace Handcom.Application.Services
{
    public class SessionService : BaseService<Session>, ISessionService
    {
        private readonly BaseRepository<Session> _session;
        public SessionService(BaseRepository<Session> session) : base(session)
        {
            _session = session;
        }

        public Session GetSession(int id)
        {
            return _session.GetAll().Where(c => c.UserId == id).FirstOrDefault();
        }

        public void IncludeSession(Session session)
        {
            var validateUser = _session.GetAll().Any(c => c.UserId == session.UserId);
            if (validateUser)
                _session.Update(session);
            else
                _session.Insert(session);
        }
    }
}
