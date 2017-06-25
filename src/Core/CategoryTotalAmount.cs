using System.Collections.Generic;

namespace GenerateGraphs.src.Core
{
    public class CategoryTotalAmount
    {
        public string Category;
        public decimal TotalAmount;
        public List<Transaction> Transactions;

        public CategoryTotalAmount(string category, decimal totalAmount, List<Transaction> transactions) {
            Category = category;
            TotalAmount = totalAmount;
            Transactions = transactions;
        }
    }
}
