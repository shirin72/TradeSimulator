using TradeSimulator;

var trade=new StockMarketMatchEngine();

while (true)
{
    Console.WriteLine("Please Enter Your Request Type");

    var request = Console.ReadLine();
    if (request == "s")
    {
        Console.WriteLine("Please Enter Your Price");
        var price = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please Enter Your Amount");
        var amount = Convert.ToInt32(Console.ReadLine());
        var sellOrder = new SellOrder() { Price = price,Amount= amount };
        trade.Sell(sellOrder);
       // Console.WriteLine("Sum: {0} ", sellOrder.GetTotalAmount());
        trade.ShowInfoTrade();

    }
    else if (request == "b")
    {
        Console.WriteLine("Please Enter Your Price");
        var price = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please Enter Your Amount");
        var amount = Convert.ToInt32(Console.ReadLine());
        var buyOrder = new BuyOrder() { Price = price, Amount = amount };
        trade.Buy(buyOrder);
        Console.WriteLine("Sum: {0} ", buyOrder.GetTotalAmount());
        trade.ShowInfoTrade();
    }
    else
    {
        Console.WriteLine("this is not the true instruction");
    }
}










