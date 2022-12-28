namespace TradeSimulator
{
    public class SellOrder
    {

        public SellOrder()
        {
        }
        public static List<int> AmountListS = new List<int>();

        public int Amount { get; set; }
        public int Price { get; set; }



        public int Count { get; set; }

        public int GetCount()
        {
            return AmountListS.Count;
        }

        public int GetTotalAmount()
       {
            return AmountListS.Sum();
        }

        public void AddAmount(int amount)
        {
            AmountListS.Add(amount);
        }
        public int Subtract(int amount)
        {
            for (int i = 0; i < AmountListS.Count; i++)
            {
                if (AmountListS[i] == amount)
                {
                    AmountListS.RemoveAt(i);
                }

                else if (AmountListS[i] > amount)
                {
                    AmountListS[i] = AmountListS[i] - amount;
                }
                else
                {
                    AmountListS.RemoveAt(i);

                }

            }

            return GetTotalAmount();
        }

    }
}
