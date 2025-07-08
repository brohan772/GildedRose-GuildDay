namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;
    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }
    // UpdateAgedBrie - Aged Brie 
    // UpdateBackstagePasses - Backstage Passes
    // Update

    public void UpdateNewQuality()
    {
        foreach (var item in Items)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    UpdateAgedBrie(item);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdateBackstagePasses(item);
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    // Sulfuras does not need to be updated
                    break;
                default:
                    if (item.Name.StartsWith("Conjured"))
                        UpdateConjuredItem(item);
                    else
                        UpdateDefaultItem(item);
                    break;
            }
        }
    }

    private void UpdateConjuredItem(Item item)
    {
        int degrade = item.SellIn > 0 ? 2 : 4;
        item.Quality = Math.Max(0, item.Quality - degrade);
        item.SellIn -= 1;
    }

    private void UpdateDefaultItem(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality -= 1;
        }

        item.SellIn -= 1;

        if (item.SellIn < 0)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }
    }
    public void UpdateBackstagePasses(Item item)
    {
        if (item.SellIn > 0)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
                if (item.SellIn <= 10 && item.Quality < 50)
                {
                    item.Quality += 1;
                }
                if (item.SellIn <= 5 && item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }
        }
        else
        {
            item.Quality = 0;
        }

        item.SellIn -= 1;
    }


    public void UpdateAgedBrie(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;
        }

        item.SellIn -= 1;

        if (item.SellIn < 0 && item.Quality < 50)
        {
            item.Quality += 1;
        }
    }

}
