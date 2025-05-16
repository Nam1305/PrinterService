using System;
using Spire.Pdf;
using System.Drawing;
using System.Drawing.Printing;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            string pdfPath = @"C:\Users\vnintern01\Downloads\slack.pdf";
            string outputPdfPath = @"C:\Users\vnintern01\Desktop\job_188552_modified.pdf";
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
            var pdfDocument = new Spire.Pdf.PdfDocument();

            pdfDocument.LoadFromFile(pdfPath);
            pdfDocument.PageScaling = PdfPrintPageScaling.FitSize;

            //Xóa metadata xoay
            foreach (PdfPageBase page in pdfDocument.Pages)
            {
                page.Rotation = PdfPageRotateAngle.RotateAngle0;
            }



            // Khởi tạo PrintDocument từ Spire.PDF
            PrintDocument printDoc = pdfDocument.PrintDocument;

            // Cấu hình khổ giấy: 110mm x 55mm (433 x 216 hundredths of inch)
            PaperSize paperSize = new PaperSize("Label_110x55", 433, 217);
            Console.WriteLine($"Paper Size: {printDoc.DefaultPageSettings.PaperSize.Width} x {printDoc.DefaultPageSettings.PaperSize.Height}");

            printDoc.DefaultPageSettings.PaperSize = paperSize;
            printDoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            printDoc.DefaultPageSettings.Landscape = true;
            printDoc.PrinterSettings.PrinterName = printerName;

            // Tùy chỉnh sự kiện PrintPage để kiểm soát render
            printDoc.PrintPage += (sender, e) =>
            {
                // Reset transform để tránh xoay tự động
                e.Graphics.ResetTransform();
            };
            // Lưu để kiểm tra
            pdfDocument.SaveToFile(outputPdfPath);
            Console.WriteLine($"Đã lưu file kiểm tra: {outputPdfPath}");
            // In
            printDoc.Print();
            Console.WriteLine("Đã gửi lệnh in.");

            // Giải phóng tài nguyên
            pdfDocument.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi: {ex.Message}\nStack Trace: {ex.StackTrace}");
        }


    }
}
