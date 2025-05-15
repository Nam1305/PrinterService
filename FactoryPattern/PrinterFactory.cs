using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public static class PrinterFactory 
    {
        public static IPrinter CreatePrinter(string printerType) 
        {
            if (string.IsNullOrEmpty(printerType))
            {
                throw new ArgumentNullException(nameof(printerType), "Loại máy in không được để trống hoặc null.");
            }

            switch (printerType.ToLower())
            {
                case "sato":
                    return new SatoPrinter();
                case "zebra":
                    return new ZebraPrinter();
                default:
                    throw new ArgumentException($"Loại máy in '{printerType}' không được hỗ trợ.");
            }
        }
    }
}
