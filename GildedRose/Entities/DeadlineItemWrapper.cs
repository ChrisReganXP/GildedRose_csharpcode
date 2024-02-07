using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    /// <summary>
     /// Wrapper for Item type to implement quality increase before a deadline
     /// </summary>
    internal class DeadlineItemWrapper : AgeingItemWrapper
    {
        /// <summary>
        /// Ctor for Deadline
        /// </summary>
        /// <param name="item">the item to be wrapped</param>
        public DeadlineItemWrapper(Item item)
            : base(item)
        {
        }

        /// <summary>
        /// Age the wrapped Item by one day
        /// </summary>
        public override void AgeByDay()
        {
            _item.SellIn--;

            if (_item.SellIn < 0)
            {
                _item.Quality = 0;
            }
            else
            {
                _item.Quality++;

                if (_item.SellIn < 10)
                {
                    _item.Quality++;
                }

                if (_item.SellIn < 5)
                {
                    _item.Quality++;
                }
            }
        }
    }
}
