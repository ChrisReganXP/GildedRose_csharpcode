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

        private const string ConjuredItemPrefix = "CONJURED ";

        /// <summary>
        /// Creates a Wrapper item based on Item.Name
        /// </summary>
        /// <param name="item">the item to produce a wrapper for</param>
        /// <returns>the wrapped item</returns>
        public static IAgeingItemWrapper CreateItemWrapper(Item item)
        {
            if (item.Name.ToUpper().StartsWith(ConjuredItemPrefix))
            {
                return new ConjuredItemWrapper(item);
            }

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
