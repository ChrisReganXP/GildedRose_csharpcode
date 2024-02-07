using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    /// <summary>
    /// Wrapper for Item type to implement quality increase through ageing
    /// </summary>
    internal class AppreciatingItemWrapper : AgeingItemWrapper
    {
        /// <summary>
        /// Ctor for Appreciating Item
        /// </summary>
        /// <param name="item">the item to be wrapped</param>
        public AppreciatingItemWrapper(Item item)
            : base(item)
        {
        }

        /// <summary>
        /// Age the wrapped Item by one day
        /// </summary>
        public override void AgeByDay()
        {
            _item.SellIn--;
            _item.Quality++;

            if (_item.SellIn < 0)
            {
                _item.Quality++;
            }

            ApplyQualityMinMax();
        }
    }
}
