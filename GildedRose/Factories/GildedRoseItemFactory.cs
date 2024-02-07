using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GildedRoseKata.Interfaces;

namespace GildedRoseKata
{
    internal static class GildedRoseItemFactory
    {
        public static IAgeingItemWrapper CreateItemWrapper(Item item)
        {
            switch (item.Name.ToUpper())
            {
                case "AGED BRIE":
                    return new AppreciatingItemWrapper(item);
                case "BACKSTAGE PASSES TO A TAFKAL80ETC CONCERT":
                    return new DeadlineItemWrapper(item);
                default:
                    return new AgeingItemWrapper(item);
            }
        }
    }
}
