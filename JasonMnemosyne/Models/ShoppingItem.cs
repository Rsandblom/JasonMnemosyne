using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JasonMnemosyne.Models
{
    public class ShoppingItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }

        public ShoppingItem(int id, string item)
        {
            Id = id;
            ItemName = item;
        }
    }
}
