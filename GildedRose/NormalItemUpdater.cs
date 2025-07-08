namespace GildedRoseKata;
public class NormalItemUpdater : IItemUpdater
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