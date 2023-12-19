using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic
{
    public class BankAccount
    {  
        public static bool VxodAdmin(string password, string logo)
        {
            if (password == null || logo == null)
            {
                return false;
            }
            else if ( password =="1" && logo =="1")
            {
                return true;
            }
            return false;
        }
    }
}
