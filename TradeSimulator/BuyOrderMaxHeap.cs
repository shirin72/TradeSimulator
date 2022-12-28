namespace TradeSimulator
{
    public class BuyOrderMaxHeap : IComparer<BuyOrder>
    {
        public int Compare(BuyOrder? x, BuyOrder? y)
        {
            if (x.Price == y.Price)
            {
                TradeSimulator.BuyOrder.AmountListB.Add(x.Amount);
                return 0;
            }
            else if (x.Price < y.Price)
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
