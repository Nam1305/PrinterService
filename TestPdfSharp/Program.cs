using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Drawing.Printing;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {

        string pdfPath = @"C:\Users\vnintern01\Downloads\slack.pdf";
        string printerName = "TestPrint";

        // Load PDF
        PdfDocument pdfDocument = PdfReader.Open(pdfPath, PdfDocumentOpenMode.Import);

        // Tạo PrintDocument
        System.Drawing.
    }
}