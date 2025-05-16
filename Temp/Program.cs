using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Print;
using System;
using System.Drawing.Printing;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string pdfPath = @"C:\Users\vnintern01\Downloads\slack.pdf";
            string outputPdfPath = @"C:\Users\vnintern01\Desktop\job_188551_modified.pdf";
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

            // Load file
            PdfDocument pdfDocument = new PdfDocument();
            pdfDocument.LoadFromFile(pdfPath);
            // Không scale
            pdfDocument.PrintSettings.SelectSinglePageLayout(PdfSinglePageScalingMode.FitSize);

            // Xoá xoay metadata (nếu có)
            foreach (PdfPageBase page in pdfDocument.Pages)
            {
                page.Rotation = PdfPageRotateAngle.RotateAngle0;
            }

            // Lưu để kiểm tra
            pdfDocument.SaveToFile(outputPdfPath);
            Console.WriteLine($"Đã lưu file kiểm tra: {outputPdfPath}");



            // Cấu hình in
            pdfDocument.PrintSettings.PrinterName = printerName;

            // Set khổ giấy ngang: 110mm x 55mm (433 x 216)
            PaperSize labelSize = new PaperSize("Label_110x55", 216, 434);
            pdfDocument.PrintSettings.PaperSize = labelSize;

            // KHÔNG xoay vì PDF gốc đã nằm ngang
            pdfDocument.PrintSettings.Landscape = false;

            // Set lề = 0
            pdfDocument.PrintSettings.SetPaperMargins(0, 0, 0, 0);

            // Reset transform nếu driver cố tình xoay
            pdfDocument.PrintSettings.PrintPage += (sender, e) =>
            {
                e.Graphics.ResetTransform();
                //e.Graphics.TranslateTransform(e.PageBounds.Width, e.PageBounds.Height);
                Console.WriteLine($"Giấy in: {e.PageBounds.Width} x {e.PageBounds.Height}");
            };

            // In
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
