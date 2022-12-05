using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? WarehouseId { get; set; }
        [NotMapped]
        public List<Warehouse>? Warehouse { get; set; }
    }
}
