using FactoryPattern;
using Spire.Pdf.Print;

class Program
{
    static void Main(String[] args)
    {
        string pdfPath = @"C:\Users\vnintern01\Downloads\slack.pdf";
        PrintSettingsModel settings = new PrintSettingsModel
        {
            PrinterName = "TestPrint",
            PaperSize = new System.Drawing.Printing.PaperSize("Label_110x55", 216, 434),
            Landscape = false,
            MarginBottom = 0,   
            MarginLeft = 0, 
            MarginRight = 0,    
            MarginTop = 0,
            ScalingMode = PdfSinglePageScalingMode.FitSize
        };

        IPrinter sato = PrinterFactory.CreatePrinter("sato");
        IPrinter zebra = PrinterFactory.CreatePrinter("zebra");
        sato.Print(pdfPath, settings);
        //zebra.Print(pdfPath, settings);
    }
}