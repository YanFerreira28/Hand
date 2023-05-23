using System;
using System.Collections.Generic;

namespace Handcom.Domain.Entities
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get;set; }
        public string Description { get;set; }
        public DateTime CreatedAt { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }

    }
}
