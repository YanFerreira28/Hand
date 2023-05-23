using Handcom.Domain.Dto;
using Handcom.Domain.Entities;
using Handcom.Domain.Interfaces.Service;
using Handcom.Infra.Repository;
using System.Linq;

namespace Handcom.Application.Services
{
    public class UserService : BaseService<Users>, IUserService
    {
        private readonly BaseRepository<Users> _service;
        public UserService(BaseRepository<Users> user) : base(user)
        {
            _service = user;
        }

        public bool ValidateUser(string Email, string Password)
        {
            return _service.GetAll().Where(c => c.Email == Email && c.Password == Password).Any();
        }

        public bool ValidateEmail(string Email)
        {
            return _service.GetAll().Where(c => c.Email == Email).Any();
        }

        public Users GetUserByEmail(string Email)
        {
            var user = _service.GetAll().Where(c => c.Email == Email).First();

            return new Users()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
                CreatedAt = user.CreatedAt,
            };
        }
    }
}
