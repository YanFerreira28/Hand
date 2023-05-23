using Handcom.Domain.Dto;
using Handcom.Domain.Entities;

namespace Handcom.Domain.Interfaces.Service
{
    public interface IUserService : IBaseService<Users>
    {
        bool ValidateUser(string Email, string Password);
        bool ValidateEmail(string Email);
        Users GetUserByEmail(string Email);
    }
}
