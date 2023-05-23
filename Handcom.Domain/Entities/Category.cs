
using System.ComponentModel.DataAnnotations.Schema;

namespace Handcom.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public virtual Products Products { get; set; }

    }
}
