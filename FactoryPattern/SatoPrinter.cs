using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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

            // Kiểm tra máy in
            bool printerExists = false;
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                if (printer.Equals(settings.PrinterName, StringComparison.OrdinalIgnoreCase))
                {
                    printerExists = true;
                    break;
                }
            }

            if (!printerExists)
            {
                Console.WriteLine($"Lỗi: Máy in '{settings.PrinterName}' không tồn tại.");
                return;
            }

            //khởi tạo đối tượng pdfDocument để chứa filePdf
            PdfDocument pdfDocument = new PdfDocument();
            pdfDocument.LoadFromFile(pdfPath);

            // Xoá xoay metadata (nếu có)
            foreach (PdfPageBase page in pdfDocument.Pages)
            {
                page.Rotation = PdfPageRotateAngle.RotateAngle0;
            }

            //cấu hình in:
            //tên máy in 
            pdfDocument.PrintSettings.PrinterName = settings.PrinterName;
            
            //khổ giấy
            PaperSize labelSize = settings.PaperSize;
            pdfDocument.PrintSettings.PaperSize = labelSize;

            //KHÔNG xoay vì PDF gốc đã nằm ngang
            pdfDocument.PrintSettings.Landscape = settings.Landscape;

            // Set lề = 0
            pdfDocument.PrintSettings.SetPaperMargins(settings.MarginTop, settings.MarginBottom, settings.MarginLeft, settings.MarginRight);

            //Scale
            pdfDocument.PrintSettings.SelectSinglePageLayout(settings.ScalingMode);

            // Reset transform nếu driver cố tình xoay
            pdfDocument.PrintSettings.PrintPage += (sender, e) =>
            {
                e.Graphics.ResetTransform();
                Console.WriteLine($"Giấy in: {e.PageBounds.Width} x {e.PageBounds.Height}");
            };


            pdfDocument.Print();
            Console.WriteLine("Đã gửi lệnh in.");

            pdfDocument.Dispose();
        }
    }
}
