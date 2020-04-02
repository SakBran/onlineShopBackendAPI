using System.Linq;
using onlineShopBackend.Models;

namespace onlineShopBackend.Controllers
{
    public class balanceCount
    {
        private dataModel db = new dataModel();
        public  int BalanceCount(int id)
        {
            int balance = 0;
            int input = 0;
            int output = 0;
           
            var checkInput = (from x in db.InputQtyModels
                              where x.sub_item_id == id select x).ToList();
            var checkOutput = (from x in db.OutputQtyModels
                               where x.sub_item_id == id select x).ToList();
            if (checkInput != null)
            {
                foreach (var x in checkInput)
                {
                    input = input + x.inputQty;
                }
            }
            if (checkOutput != null)
            {
                foreach (var y in checkOutput)
                {
                    output = output + y.outputQty;
                }
            }
            if (input == 0)
            {
                return balance;
            }
            balance = input - output;
            return balance;
        }
    }
}