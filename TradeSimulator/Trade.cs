namespace TradeSimulator
{
    public class StockMarketMatchEngine
    {
        private readonly PriorityQueueS<SellOrder, SellOrder> SellOrderQueue;
        private readonly PriorityQueueB<BuyOrder, BuyOrder> BuyOrder;
        private int TradeCount;

        public StockMarketMatchEngine()
        {
            this.SellOrderQueue = new PriorityQueueS<SellOrder, SellOrder>(new SellOrderMinHeap());
            this.BuyOrder = new PriorityQueueB<BuyOrder, BuyOrder>(new BuyOrderMaxHeap());
        }

        public void Sell(SellOrder sellOrder)
        {
            if (BuyOrder.Count > 0)
            {
                var getTop = BuyOrder.Peek();
                if (getTop.Price >= sellOrder.Price)
                {
                    TradeCount++;

                    var getAmount = getTop.Subtract(sellOrder.Amount);

                    if (getAmount <= 0)
                    {
                        // this.SellOrderQueue.Enqueue(sellOrder, sellOrder);
                        this.BuyOrder.Dequeue();
                    }
                    //else if (getAmount > 0)
                    //{
                    //    this.BuyOrder.Dequeue();
                    //    this.SellOrderQueue.Enqueue(sellOrder, sellOrder);
                    //}
                    //else
                    //{
                    //    this.BuyOrder.Dequeue();
                    //}
                }
                else if (getTop.Price < sellOrder.Price)
                {
                    //sellOrder.AddAmount(sellOrder.Amount);

                    this.SellOrderQueue.Enqueue(sellOrder, sellOrder);

                    //sellOrder.Count = sellOrder.GetCount();
                }


                #region Comment
                //if (getTop.Price >= sellOrder.Price)
                //{
                //    TradeCount++;

                //    if (getTop.Amount == sellOrder.Amount)
                //    {
                //        BuyOrder.Dequeue();
                //    }
                //    else if (getTop.Amount > sellOrder.Amount)
                //    {
                //        getTop.Amount = getTop.Amount - sellOrder.Amount;
                //        SellOrderQueue.Enqueue(sellOrder, sellOrder);
                //    }
                //    else if(getTop.Amount < sellOrder.Amount)
                //    {
                //        sellOrder.Amount = sellOrder.Amount - getTop.Amount;
                //        BuyOrder.Dequeue();
                //        SellOrderQueue.Enqueue(sellOrder, sellOrder);
                //    }

                //}
                //else
                //{
                //    SellOrderQueue.Enqueue(sellOrder, sellOrder);
                //}
                #endregion
            }
            else
            {
                SellOrderQueue.Enqueue(sellOrder, sellOrder);
            }
        }

        public void Buy(BuyOrder buyOrder)
        {
            if (SellOrderQueue.Count > 0)
            {
                var getTop = SellOrderQueue.Peek();

                if (getTop.Price <= buyOrder.Price)
                {
                    TradeCount++;

                    if (buyOrder.Amount > getTop.GetTotalAmount())
                    {
                        buyOrder.Amount = buyOrder.Amount - getTop.GetTotalAmount();
                    }
                    //else
                    //{
                    //    buyOrder.Amount = buyOrder.Amount - getTop.GetTotalAmount();

                    //}
                    var getAmount = getTop.Subtract(buyOrder.Amount);

                    if (getAmount <= 0)
                    {

                        this.BuyOrder.Enqueue(buyOrder, buyOrder);
                        this.SellOrderQueue.Dequeue();
                    }

                    //if (getAmount <= 0)
                    //{
                    //    //this.BuyOrder.Dequeue();
                    //    //this.BuyOrder.Enqueue(buyOrder, buyOrder);
                    //    //this.SellOrderQueue.Dequeue();
                    //}
                    //if (getAmount > 0)
                    //{
                    //   // BuyOrder.Enqueue(buyOrder, buyOrder);   

                    //}

                }
                else
                {
                    BuyOrder.Enqueue(buyOrder, buyOrder);
                }
            }
            else
            {
                BuyOrder.Enqueue(buyOrder, buyOrder);
            }
        }

        public void ShowInfoTrade()
        {
            Console.WriteLine("Number Of Trade Until Now {0}", TradeCount);
            Console.WriteLine("Number Of Sell Orders in Queue {0} ", SellOrderQueue.Count);
            Console.WriteLine("Number Of Buy Orders in Queue {0}", BuyOrder.Count);
        }
    }
}
