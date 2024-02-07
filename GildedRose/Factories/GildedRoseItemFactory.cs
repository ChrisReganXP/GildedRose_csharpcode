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
        private const string AgedBriedName = "AGED BRIE";

        private const string BackStagePassesName = "BACKSTAGE PASSES TO A TAFKAL80ETC CONCERT";

        private const string SulfurasName = "SULFURAS, HAND OF RAGNAROS";

        public static IAgeingItemWrapper CreateItemWrapper(Item item)
        {
            switch (item.Name.ToUpper())
            {
                case AgedBriedName:
                    return new AppreciatingItemWrapper(item);
                case BackStagePassesName:
                    return new DeadlineItemWrapper(item);
                case SulfurasName:
                    return new StableItemWrapper(item);
                default:
                    return new AgeingItemWrapper(item);
            }
        }
    }
}
