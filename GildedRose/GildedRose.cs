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
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                continue;
            }

            item.SellIn--;

            switch (item.Name)
            {
                case "Aged Brie":
                    UpdateAgedBrie(item);
                    break;
                case var name when name.StartsWith("Backstage passes"):
                    UpdateBackstagePasses(item);
                    break;
                case var name when name.StartsWith("Conjured"):
                    UpdateConjuredItem(item);
                    break;
                default:
                    UpdateNormalItem(item);
                    break;
            }
        }
    }

    private void UpdateAgedBrie(Item item)
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

    private void UpdateBackstagePasses(Item item)
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

    private void UpdateConjuredItem(Item item)
    {
        int degradation = 2;
        if (item.SellIn < 0)
        {
            degradation *= 2;
        }

        item.Quality = Math.Max(0, item.Quality - degradation);

    }

    private void UpdateNormalItem(Item item)
    {
        int degradation = item.SellIn < 0 ? 2 : 1;
        item.Quality = Math.Max(0, item.Quality - degradation);
    }
}