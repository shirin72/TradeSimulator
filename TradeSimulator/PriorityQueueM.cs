namespace TradeSimulator
{
    public class PriorityQueueB<T1,T2>:PriorityQueue<BuyOrder, BuyOrder>
    {
        public PriorityQueueB(IComparer<BuyOrder>? comparer) : base(comparer)
        {

        }


        public void Enqueue(BuyOrder x, BuyOrder y)
        {
            if (this.Count > 0)
            {
                var getTop = this.Peek();
                if (x.Price != getTop.Price)
                {
                    base.Enqueue(x, y);
                }
                else
                {
                    BuyOrder.AmountListB.Add(x.Amount);
                }
            }
            else
            {
                BuyOrder.AmountListB.Add(x.Amount);

                base.Enqueue(x, y);
            }

        }
    }
}
