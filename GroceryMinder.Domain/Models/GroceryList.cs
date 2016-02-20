using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMinder.Domain.Models
{
    public class GroceryList
    {
        public DateTime Date { get; set; }
        public IList<Grocery> Groceries { get; set; }
        public int TotalCost { get; set; }

        public string ToText()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("GrocerMinder Shopping List for {0}", DateTime.Now.ToShortDateString()));
            sb.AppendLine("");

            foreach (var grocery in Groceries)
            {
                sb.AppendLine(string.Format("${0:0.00} - {1} - {2}", grocery.AverageCost, grocery.GroceryCategory.Name, grocery.Name));
            }
            sb.AppendLine("");
            sb.AppendLine(string.Format("Total Estimated Cost: ${0:00.00}", TotalCost));

            return sb.ToString();
        }
    }
}
