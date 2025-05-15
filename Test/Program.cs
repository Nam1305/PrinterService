using Spire.Pdf;
using Spire.Pdf.Print;
using System;
using System.Drawing.Printing;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string pdfPath = @"C:\Users\vnintern01\Downloads\slack.pdf";
            string printerName = "TestPrint";

            // Kiểm tra máy in
            bool printerExists = false;
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                if (printer.Equals(printerName, StringComparison.OrdinalIgnoreCase))
                {
                    printerExists = true;
                    break;
                }
            }

            if (!printerExists)
            {
                Console.WriteLine($"Lỗi: Máy in '{printerName}' không tồn tại.");
                return;
            }

            // Load file PDF
            PdfDocument pdfDocument = new PdfDocument();
            pdfDocument.LoadFromFile(pdfPath);

            // Cấu hình máy in (chỉ chọn máy in, không thiết lập thêm)
            pdfDocument.PrintSettings.PrinterName = printerName;
            
            pdfDocument.PrintSettings.SelectSinglePageLayout(PdfSinglePageScalingMode.FitSize);



            // In với thiết lập mặc định của trình điều khiển
            pdfDocument.Print();
            Console.WriteLine("Đã gửi lệnh in.");

            pdfDocument.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi: {ex.Message}");
        }
    }
}