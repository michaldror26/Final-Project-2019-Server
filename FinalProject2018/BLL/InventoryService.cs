﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities;

namespace BLL
{
    public class InventoryService : BaseService
    {

        public InventoryService()
        {
        }
        
        public List<Inventory> getInventory()
        {
            return db.Inventory.Include("Product").ToList();
        }
    }
}
