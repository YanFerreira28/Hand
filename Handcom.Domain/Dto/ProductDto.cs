

using System;

namespace Handcom.Domain.Dto
{
    public class ProductDto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
