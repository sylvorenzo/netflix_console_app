using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessTier;


namespace Sylvorenzo.Assignment3
{
    class Program
    {
       static Logic l = new Logic();


        static void Main(string[] args)
        {
            Console.WriteLine("====================================================================");
            Console.WriteLine("                    BROUGHT TO YOU BY SYLVORENZO JACQUES            ");
            Console.WriteLine("====================================================================");
            Console.WriteLine("     =    = ==== ======= ======= =    ====== =    =");
            Console.WriteLine("     = =  = ==      =    ===     =       =      =  ");
            Console.WriteLine("     =    = ====    =    =       ===== ===== =    =\n");
            Console.WriteLine("              ==============================");
            Console.WriteLine("                    PSEUDO-RECOMMENDER");
            Console.WriteLine("              ==============================\n");
            Console.WriteLine("=====================================================================\n");
            Console.WriteLine("============================");
            Console.WriteLine(l.readRecords());
        }
    }
}
