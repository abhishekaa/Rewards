using System;
using System.Collections.Generic;
using System.Text;

namespace Retailer.Rewards.Models
{
    public class RewardRule
    {
        /*
         A customer receives 2 points for every dollar spent over $100 in each transaction, plus 1 point for every dollar spent over $50 in each transaction
(e.g. a $120 purchase = 2x$20 + 1x$50 = 90 points).
         */
        public RewardRule(decimal threshold, int rewards)
        {
            this.Threshold = threshold;
            this.RewardPointsPerDollar = rewards;

        }
        public decimal Threshold { get; set; }
        public int RewardPointsPerDollar { get; set; }
    }
}
