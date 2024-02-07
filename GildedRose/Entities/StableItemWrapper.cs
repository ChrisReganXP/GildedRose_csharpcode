using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    /// <summary>
    /// Wrapper for Item type to implement no quality changes through ageing
    /// </summary>
    internal class StableItemWrapper : AgeingItemWrapper
    {
        /// <summary>
        /// Ctor for Appreciating Item
        /// </summary>
        /// <param name="item">the item to be wrapped</param>
        public StableItemWrapper(Item item)
            : base(item)
        {
        }

        /// <summary>
        /// Age the wrapped Item by one day
        /// </summary>
        public override void AgeByDay()
        {
            // no behaviour needed
        }
    }
}
