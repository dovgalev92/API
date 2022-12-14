using API.Context;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly ContextDb context;
        public WarehousesController(ContextDb _context)
        {
            context = _context;
        }
        [HttpGet]
        public List<Warehouse> GetWarehousesList()
        {
            var warehouse_list = from list in context.Warehouses select list;
            var get_listroom = context.WarehouseRooms.AsNoTracking().ToList();
            List<Warehouse> warehouse = new();
            foreach (var get_warehouse in warehouse_list)
            {
                Warehouse item_warehose = new();
                item_warehose.Id = get_warehouse.Id;
                item_warehose.Name = get_warehouse.Name;
                item_warehose.CompanyId = get_warehouse.CompanyId;
                item_warehose.RegionId = get_warehouse.RegionId;

                var result_itemEqual = get_listroom.Where(element => element.WarehouseId.Equals(get_warehouse.Id));
                item_warehose.roomCount = result_itemEqual.Count();
                warehouse.Add(item_warehose);
            }
            return warehouse;
        }
        [Route("GetWarehouse/{id}")]
        [HttpGet]
        public List<Warehouse> GetWarehouseId(int id)
        {
            var itemIdWarehouse = context.Warehouses.Where(w => w.Id.Equals(id)).ToList();
            var listWarehouseRoom = context.WarehouseRooms.AsNoTracking().ToList();
            List<Warehouse> warehouses = new();
            foreach (var warehouseItem in itemIdWarehouse)
            {
                Warehouse getwarehouseitem = new();
                getwarehouseitem.Id = warehouseItem.Id;
                getwarehouseitem.Name = warehouseItem.Name;
                getwarehouseitem.CompanyId = warehouseItem.CompanyId;
                getwarehouseitem.RegionId = warehouseItem.RegionId;

                var getEqualsItem = listWarehouseRoom.Where(nameRoom => nameRoom.WarehouseId.Equals(warehouseItem.Id)).ToList();
                foreach (var name_room in getEqualsItem)
                {
                    getwarehouseitem.name_compartment += name_room.Name.ToString();
                    getwarehouseitem.name_compartment += ",";
                }
                warehouses.Add(getwarehouseitem);
            }
            return warehouses;
        }
        [Route("AddNewWarehouse")]
        [HttpPost]
        public ActionResult<Warehouse> AddWarehouse([FromBody] Warehouse warehouse)
        {
            context.Warehouses.Add(warehouse);
            context.SaveChanges();
            return CreatedAtAction("GetWarehouseId", new Warehouse { Id = warehouse.Id}, warehouse);
        }
      
        [HttpPut("Update/{id}")]
        public IActionResult UpdateWarehouses(int id, [FromBody] Warehouse warehouse)
       {
            if (id != warehouse.Id)
            {
                return BadRequest();
            }
            context.Entry(warehouse).State = EntityState.Modified;
            context.SaveChanges();
            return Content("Обновление прошло успешно");
            
        }
        [Route("UpdateWarehouseRoom/{id}")]
        [HttpPut]
        public IActionResult UpdateWarehousesRoom(int id, [FromBody] WarehouseRoom room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }
            context.Entry(room).State = EntityState.Modified;
            context.SaveChanges();
            return Content("Обновление прошло успешно");
        }
    }
}
