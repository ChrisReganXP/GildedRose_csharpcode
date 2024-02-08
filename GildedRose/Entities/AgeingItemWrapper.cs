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
    internal class AgeingItemWrapper : IAgeingItemWrapper
    {
        /// <summary>
        /// The item being wrapped
        /// </summary>
        protected Item _item;

        /// <summary>
        /// Ctor for Ageing Item Wrapper
        /// </summary>
        /// <param name="item">the item to wrap</param>
        public AgeingItemWrapper(Item item)
        {
            // or other appropriate error handling
            ArgumentNullException.ThrowIfNull(item);

            _item = item;
        }

        /// <summary>
        /// Age the wrapped Item by one day
        /// </summary>
        public virtual void AgeByDay()
        {
            if (HandleInvalidQuality())
            {
                return;
            }

            _item.SellIn--;
            _item.Quality--;

            if (_item.SellIn < 0)
            {
                _item.Quality--;
            }

            ApplyQualityMinMax();
        }

        /// <summary>
        /// Updates invalid values to expected ranges. Return indicates impossible situation
        /// </summary>
        /// <returns>true when the item cannot be aged</returns>
        public bool HandleInvalidQuality()
        {
            // no handler for these in scope
            if (_item.SellIn == int.MinValue)
            {
                return true;
            }

            if (_item.Quality < GildedRose.MINIMUM_QUALITY_ALLOWED || _item.Quality > GildedRose.MAXIMUM_QUALITY_ALLOWED)
            {
                ApplyQualityMinMax();
            }

            return false;
        }

        /// <summary>
        /// Enforces location based min/max rules
        /// </summary>
        protected void ApplyQualityMinMax() 
        {
            _item.Quality = Math.Min(
                Math.Max(_item.Quality, GildedRose.MINIMUM_QUALITY_ALLOWED),
                GildedRose.MAXIMUM_QUALITY_ALLOWED);
        }
    }
}
