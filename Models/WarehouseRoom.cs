namespace API.Models
{
    public class WarehouseRoom
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Square { get; set; }
        public int? WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }
    }
}
