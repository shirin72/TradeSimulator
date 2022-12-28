namespace TradeSimulator
{
    public class BuyOrder
    {
        public static List<int> AmountListB = new List<int>();

        public BuyOrder()
        {
        }
        public int TotalAmount { get; set; }
        public int Amount { get; set; }

        public int Price { get; set; }

        public int Count { get; set; }

        public int GetCount()
        {
            return AmountListB.Count;
        }

        public int GetTotalAmount()
        {
            return AmountListB.Sum();
        }

        public void AddAmount(int amount)
        {
            AmountListB.Add(amount);
        }

        public int Subtract(int amount)
        {
            for (int i = 0; i < AmountListB.Count; i++)
            {
                if (AmountListB[i] == amount)
                {
                    AmountListB.RemoveAt(i);
                }

                else if (AmountListB[i] > amount)
                {
                    AmountListB[i] = AmountListB[i] - amount;
                    
                }
                else 
                {
                    AmountListB.RemoveAt(i);
                }

            }

            return GetTotalAmount();
        }

    }
}
