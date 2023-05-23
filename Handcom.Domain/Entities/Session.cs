using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handcom.Domain.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }

        public Users User { get; set; }
    }
}
