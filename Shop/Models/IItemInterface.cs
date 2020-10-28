using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public interface IItemInterface
    {
        IEnumerable<Item> GetAllItem { get; }
        IEnumerable<Item> GetItemOnSale { get; }
        Item GetItemById(int ItemId);

    }
}
