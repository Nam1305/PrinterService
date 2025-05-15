using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class ZebraPrinter : IPrinter
    {
        public void Print(string pdfPath, PrintSettingsModel settings)
        {
            Console.WriteLine("In bang may in ZEBRA");
        }
    }
}
