using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    // ItemName, SellIn, Quality, DaysToExecute, ExpectedQuality, TestName
    [Test]
    [TestCase("Aged Brie", 2, 0, 10, 18, "Aged Brie going past sell date")]
    [TestCase("Aged Brie", 4, 1, 1, 2, "Aged Brie staying in date")]
    [TestCase("Aged Brie", -3, 10, 4, 18, "Aged Brie staying in date")]
    [TestCase("Aged Brie", -20, 48, 5, 50, "Aged Brie hitting ceiling")]
    [TestCase("Aged Brie", 11, int.MaxValue, 8, 50, "Aged Brie breaking boundaries")]
    [TestCase("Sulfuras, Hand of Ragnaros", 13, 80, 3, 80, "Sulfras in date")]
    [TestCase("Sulfuras, Hand of Ragnaros", 3, 80, 7, 80, "Sulfras going past sell date")]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 50, 5, 10, 15, "Backstage Passes Long Range")]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 20, 15, 12, 29, "Backstage Passes Long to Med Range")]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 8, 11, 5, 23, "Backstage Passes Med to Short Range")]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 12, 20, 10, 41, "Backstage Passes Long to Short Range")]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 12, 20, 13, 0, "Backstage Passes Long to Expired")]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 7, 20, 12, 0, "Backstage Passes Med to Expired")]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 2, 20, 5, 0, "Backstage Passes Short to Expired")]
    [TestCase("Wizard Robe", 10, 6, 3, 3, "Basic item in date")]
    [TestCase("Wizard Robe", 4, 19, 8, 7, "Basic item passing sell by date")]
    [TestCase("Wizard Robe", 9, 6, 8, 0, "Basic item dropping to zero")]
    [TestCase("Wizard Robe", 10, int.MinValue, 3, 0, "Basic item breaking min boundaries")]
    [TestCase("Conjured Bath Salts", 8, 40, 3, 34, "Conjured item staying in date")]
    [TestCase("Conjured Bath Salts", 4, 35, 9, 7, "Conjured item passing sell by date")]
    [TestCase("Conjured Bath Salts", 6, 25, 10, 0, "Conjured item dropping to zero")]
    [TestCase("Conjured Bath Salts", int.MinValue, 34, 5, 34, "Conjured item impossible days old")]
    public void UpdateQualityTests(string itemName, int sellIn, int quality, int daysToExecute, int expectedQuality, string testName)
    {
        IList<Item> Items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = quality } };
        GildedRose app = new GildedRose(Items);

        for (int i = 0; i < daysToExecute; i++)
        {
            app.UpdateQuality();
        }

        Assert.That(expectedQuality, Is.EqualTo(Items[0].Quality), $"{testName} : {itemName} after {daysToExecute} loops should be {expectedQuality} but was {Items[0].Quality}");
    }
}
