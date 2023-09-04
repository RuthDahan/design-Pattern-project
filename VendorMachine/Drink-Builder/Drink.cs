using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorMachine
{
    public class Drink : Product
    {
        public override string ToString()
        {
            return $"{ base.ToString()},{Description}" ;
        }

    }
}
