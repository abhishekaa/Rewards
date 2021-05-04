using Retailer.Rewards.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace Retailer.Rewards
{
   public class TransactionService
    {
        string DATASETPATH = "dataset.json";
         List<Transaction> Transactions { get; set; }
         List<RewardRule> rewardRules { get; set; }

        public TransactionService()
        {
            DATASETPATH = $"{AppContext.BaseDirectory}{DATASETPATH}";
            this.Transactions = new List<Transaction>();
            this.rewardRules = new List<RewardRule>() {
             new RewardRule(100,2),
             new RewardRule(50,1),
            };
        }
        public Transaction Add(Transaction txn)
        {
            UpdateRewards(txn);
            this.Transactions.Add(txn);
            UpdateDataSet();
            return txn;
        }

        public void LoadTransactions()
        {
            if (File.Exists(DATASETPATH))
            {
                string fileContent = File.ReadAllText(DATASETPATH);
                this.Transactions = JsonConvert.DeserializeObject<List<Transaction>>(fileContent);
                ApplyRewards();
            }
        }
        public void ApplyRewards()
        {
            foreach(var t in this.Transactions)
            {
                UpdateRewards(t);
            }
        }
        public void UpdateRewards(Transaction txn)
        {
            var totalAmount = Math.Floor(txn.TotalAmount);
            int rewardPoints = 0;
            foreach(var r in this.rewardRules)
            {
                if (r.Threshold < totalAmount)
                {
                    rewardPoints = rewardPoints + Convert.ToInt32((totalAmount - r.Threshold) * r.RewardPointsPerDollar);
                    totalAmount = r.Threshold;
                }
            }
            txn.RewardsPoints = rewardPoints;
        }
        public void UpdateDataSet()
        {
            File.WriteAllText(DATASETPATH,JsonConvert.SerializeObject(this.Transactions));
        }
    }
}
