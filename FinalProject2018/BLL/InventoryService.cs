using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Entities;

namespace BLL
{
    public class InventoryService : BaseService
    {
        public List<Inventory> GetAllInventory()
        {
            return db.Inventory.ToList();
        }

        public Inventory getProductCountById(int id)
        {
            return db.Inventory.FirstOrDefault(e => e.ProductId == id);
        }
    }
}
