using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    /// <summary>
    /// Maximum value allowed for quality items in this location
    /// </summary>
    public const int MAXIMUM_QUALITY_ALLOWED = 50;

    /// <summary>
    /// Minimum value allowed for quality items in this location
    /// </summary>
    public const int MINIMUM_QUALITY_ALLOWED = 0;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items) 
        {
            GildedRoseItemFactory.CreateItemWrapper(item).AgeByDay();
        }
    }
}