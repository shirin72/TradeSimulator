using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeSimulator
{
    public class PriorityQueueS<T1, T2> : PriorityQueue<SellOrder, SellOrder>
    {
        public PriorityQueueS(IComparer<SellOrder>? comparer) : base(comparer)
        {

        }


        public void Enqueue(SellOrder x, SellOrder y)
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
                    SellOrder.AmountListS.Add(x.Amount);
                }
            }
            else
            {
                SellOrder.AmountListS.Add(x.Amount);

                base.Enqueue(x, y);
            }

        }
    }
}
