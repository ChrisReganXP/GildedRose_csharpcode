using GildedRoseKata.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    /// <summary>
    /// Wrapper for Item type to implement quality loss through ageing
    /// </summary>
    internal class ConjuredItemWrapper : AgeingItemWrapper
    {
        /// <summary>
        /// Ctor for Conjured Item Wrapper
        /// </summary>
        /// <param name="item">the item to wrap</param>
        public ConjuredItemWrapper(Item item)
            : base(item)
        {
        }

        /// <summary>
        /// Age the wrapped Item by one day
        /// </summary>
        public override void AgeByDay()
        {
            if (HandleInvalidQuality())
            {
                return;
            }

            _item.SellIn--;
            _item.Quality = _item.Quality - 2;

            if (_item.SellIn < 0)
            {
                _item.Quality = _item.Quality - 2;
            }

            ApplyQualityMinMax();
        }
    }
}
