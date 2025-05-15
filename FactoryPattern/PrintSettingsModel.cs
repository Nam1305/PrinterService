using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf.Graphics;
using Spire.Pdf.Print;
using System.Drawing.Printing;
using System.Linq;

namespace FactoryPattern
{
    public class PrintSettingsModel
    {
        public string PrinterName { get; set; }
        public PaperSize PaperSize { get; set; }
        public bool Landscape { get; set; }
        public int MarginLeft { get; set; }
        public int MarginTop { get; set; }
        public int MarginRight { get; set; }
        public int MarginBottom { get; set; }
        public PdfSinglePageScalingMode ScalingMode { get; set; }
    }
}
