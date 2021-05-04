using System;

namespace Retailer.Rewards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Customer Reward Program");
            TransactionService service = new TransactionService();
            service.LoadTransactions();
            service.UpdateDataSet();
            Console.WriteLine("Completed");
            Console.Read();
        }
    }
}
