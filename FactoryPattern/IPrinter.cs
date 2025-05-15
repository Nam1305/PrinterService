using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public interface IPrinter
    {
        void Print(string pdfPath, PrintSettingsModel settings);
    }
}
