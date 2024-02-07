using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Interfaces
{
    /// <summary>
    /// Interface to define Item ageing functions
    /// </summary>
    internal interface IAgeingItemWrapper
    {
        /// <summary>
        /// Age an item by one day
        /// </summary>
        void AgeByDay();
    }
}
