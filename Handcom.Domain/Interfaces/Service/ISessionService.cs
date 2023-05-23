

using Handcom.Domain.Entities;

namespace Handcom.Domain.Interfaces.Service
{
    public interface ISessionService :  IBaseService<Session>
    {
        void IncludeSession(Session session);
        Session GetSession(int id);    
    }
}
