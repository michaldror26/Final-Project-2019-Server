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

        public Inventory getInventoryById(int id)
        {
            return db.Inventory.FirstOrDefault(e => e.ProductId == id);
        }

        public Inventory getProductAmountById(int ProductId)
        {
            return db.Inventory.FirstOrDefault(e => e.ProductId == ProductId);
        }

        public void AddInventory(Inventory inventory)
        {
            db.Inventory.Add(inventory);
            db.SaveChanges();
        }

        public void DeleteInventory(int id)
        {
            Inventory inventory = db.Inventory.FirstOrDefault(c => c.InventoryId == id);
            db.Inventory.Remove(inventory);
            db.SaveChanges();
        }

        public void EditInventory(Inventory inventory)
        {

        }
    }
}
