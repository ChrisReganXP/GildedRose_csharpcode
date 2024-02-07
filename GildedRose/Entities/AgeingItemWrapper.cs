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
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            _item = item;
        }

        /// <summary>
        /// Age the wrapped Item by one day
        /// </summary>
        public virtual void AgeByDay()
        {
            _item.SellIn--;
            _item.Quality--;

            if (_item.SellIn < 0)
            {
                _item.Quality--;
            }

            ApplyQualityMinMax();
        }

        protected void ApplyQualityMinMax() 
        {
            _item.Quality = Math.Min(
                Math.Max(_item.Quality, GildedRose.MINIMUM_QUALITY_ALLOWED),
                GildedRose.MAXIMUM_QUALITY_ALLOWED);
        }
    }
}
