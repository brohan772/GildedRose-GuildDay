namespace GildedRoseKata;

public interface IUpdateItem
{
    void UpdateQuality();
    void UpdateSellIn();
}

public class AgedBrieUpdater : IUpdateItem
{
    private readonly Item item;

    public AgedBrieUpdater(Item item)
    {
        this.item = item;
    }

    public void UpdateQuality()
    {
        if (item.Quality < 50)
        {
            item.Quality++;
            if (item.SellIn < 0 && item.Quality < 50)
            {
                item.Quality++;
            }
        }
    }

    public void UpdateSellIn()
    {
        item.SellIn--;
    }
}

public class BackstagePassesUpdater : IUpdateItem
{
    private readonly Item item;

    public BackstagePassesUpdater(Item item)
    {
        this.item = item;
    }

    public void UpdateQuality()
    {
        if (item.SellIn < 0)
        {
            item.Quality = 0;
        }
        else if (item.Quality < 50)
        {
            item.Quality++;

            if (item.SellIn < 10 && item.Quality < 50)
            {
                item.Quality++;
            }
            if (item.SellIn < 5 && item.Quality < 50)
            {
                item.Quality++;
            }
        }
    }

    public void UpdateSellIn()
    {
        item.SellIn--;
    }
}

public class ConjuredItemUpdater : IUpdateItem
{
    private readonly Item item;

    public ConjuredItemUpdater(Item item)
    {
        this.item = item;
    }

    public void UpdateQuality()
    {
        int degradation = 2;
        if (item.SellIn < 0)
        {
            degradation *= 2;
        }

        item.Quality = Math.Max(0, item.Quality - degradation);
    }

    public void UpdateSellIn()
    {
        item.SellIn--;
    }
}
public class NormalItemUpdater : IUpdateItem
{
    private readonly Item item;

    public NormalItemUpdater(Item item)
    {
        this.item = item;
    }

    public void UpdateQuality()
    {
        int degradation = item.SellIn < 0 ? 2 : 1;
        item.Quality = System.Math.Max(0, item.Quality - degradation);
    }

    public void UpdateSellIn()
    {
        item.SellIn--;
    }
}

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
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                continue;
            }

            var updater = GetUpdater(item);
            updater.UpdateQuality();
            updater.UpdateSellIn();
        }
    }

    private IUpdateItem GetUpdater(Item item)
    {


            switch (item.Name)
            {
                case "Aged Brie":
                    return new AgedBrieUpdater(item);
                case var name when name.StartsWith("Backstage passes"):
                    return new BackstagePassesUpdater(item);
                case var name when name.StartsWith("Conjured"):
                    return new ConjuredItemUpdater(item);
                default:
                    return new NormalItemUpdater(item);
            }

    }
}