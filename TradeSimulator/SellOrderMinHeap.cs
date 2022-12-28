namespace TradeSimulator
{
    public class SellOrderMinHeap : IComparer<SellOrder>
    {
        public int Compare(SellOrder? x, SellOrder? y)
        {
            if (x.Price == y.Price)
            {
                return 0;
            }
            else if (x.Price > y.Price)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
