namespace GildedRoseKata;

public class AgedBrieUpdater : IItemUpdater
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