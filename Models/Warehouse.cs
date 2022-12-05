using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace API.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        [DisplayName("Название склада")]
        public string? Name { get; set; }
        [DisplayName("Собственник склада")]
        public int? CompanyId { get; set; }
        [DisplayName("Место расположения")]
        public int? RegionId { get; set; }
        [NotMapped]
        public Company? Company { get; set; }
        [NotMapped]
        public Region? Region { get; set; }
        public List<WarehouseRoom>? WarehouseRooms { get; set; }
        /// <summary>
        /// количество комнат
        /// </summary>
        [NotMapped]
        public int roomCount { get; set; }
        /// <summary>
        /// Наименование комнат
        /// </summary>
        [NotMapped]
        public string? name_compartment { get; set; }
    }
}
