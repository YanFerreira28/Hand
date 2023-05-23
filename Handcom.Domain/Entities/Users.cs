using System;

namespace Handcom.Domain.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public Session Session{ get; set; }
    }
}
