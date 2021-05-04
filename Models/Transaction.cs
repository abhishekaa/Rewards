using System;
using System.Collections.Generic;
using System.Text;

namespace Retailer.Rewards.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public int RewardsPoints { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
