using Spire.Pdf;
using System;
using System.Drawing;
using System.Drawing.Printing;

class Program
{
    static void Main(string[] args)
    {
        // Đường dẫn của file PDF gốc
        string pdfPath = @"C:\Users\vnintern01\Downloads\slack.pdf";

        // Tên máy in
        string printerName = "TestPrint";   
    }


    //public static bool CheckPrinterExist(string printerName)
    //{
    //    foreach (string printer in PrinterSettings.InstalledPrinters)
    //    {
    //        if (printer.Equals(printerName, StringComparison.OrdinalIgnoreCase))
    //        {
    //            Console.WriteLine($"Máy in '{printerName}' được tìm thấy.");
    //            return true;
    //        }
    //    }

    //    Console.WriteLine($"Lỗi: Máy in '{printerName}' không tồn tại.");
    //    return false;
    //}
}