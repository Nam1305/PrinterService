using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class SatoPrinter : IPrinter
    {
        public void Print(string pdfPath, PrintSettingsModel settings)
        {
            //logic in cho may in SatoPrinter
            Console.WriteLine("In bang may in SATO");
        }
    }
}
