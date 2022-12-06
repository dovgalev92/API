using API.Context;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetWarehousesController : ControllerBase
    {
        private readonly ContextDb context;
        public GetWarehousesController(ContextDb _context)
        {
            context = _context;
        }
        [Route("ListWarehouse")]
        [HttpGet]
        public List<Warehouse> GetWarehousesList()
        {
            var warehouse_list = from list in context.Warehouses select list;
            var get_listroom = context.WarehouseRooms.AsNoTracking().ToList();  
            List<Warehouse> warehouse = new();
            foreach(var get_warehouse in warehouse_list)
            {
                Warehouse item_warehose = new();
                item_warehose.Name = get_warehouse.Name;
                item_warehose.CompanyId = get_warehouse.CompanyId;
                item_warehose.RegionId = get_warehouse.RegionId;

                var result_itemEqual = get_listroom.Where(element => element.WarehouseId.Equals(get_warehouse.Id));
                item_warehose.roomCount = result_itemEqual.Count();
                warehouse.Add(item_warehose);
            }
            return warehouse;

        }

    }
}
