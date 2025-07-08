namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> items;

    public GildedRose(IList<Item> items)
    {
        this.items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in items)
        {
            var updater = GetUpdater(item);
            if (updater != null)
            {
                updater.UpdateQuality();
                updater.UpdateSellIn();
            }
        }
    }

    private IItemUpdater GetUpdater(Item item)
    {
            switch (item.Name)
            {
                case "Aged Brie":
                    return new AgedBrieUpdater(item);
                case var name when name.StartsWith("Backstage passes"):
                    return new BackstagePassesUpdater(item);
                case var name when name.StartsWith("Conjured"):
                    return new ConjuredItemUpdater(item);
                case var name when name.StartsWith("Sulfuras"):
                    return null;
                default:
                    return new NormalItemUpdater(item);
            }

    }
}