namespace GildedRoseKata;
public class ConjuredItemUpdater : IItemUpdater
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