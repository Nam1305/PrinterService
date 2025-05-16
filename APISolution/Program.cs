using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Printing;


class Program
{
    static void Main(string[] args)
    {
        var printer = new DirectPdfPrinter();
        string xPath = @"C:\Users\vnintern01\Desktop\VN197400-60203T (22).pdf";
        string printerName = "TestPrint";
        printer.PrintPdfDirectly(xPath, printerName);

    }


    public class DirectPdfPrinter
    {
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool OpenPrinter(string pPrinterName, out IntPtr phPrinter, IntPtr pDefault);

        [DllImport("winspool.drv", SetLastError = true)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, int Level, ref DOCINFO_1 pDocInfo);

        [DllImport("winspool.drv", SetLastError = true)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", SetLastError = true)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

        [DllImport("winspool.drv", SetLastError = true)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", SetLastError = true)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", SetLastError = true)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [StructLayout(LayoutKind.Sequential)]
        public struct DOCINFO_1
        {
            public string pDocName;
            public string pOutputFile;
            public string pDataType;
        }

        public void PrintPdfDirectly(string pdfPath, string printerName)
        {
            IntPtr hPrinter = IntPtr.Zero;
            DOCINFO_1 docInfo = new DOCINFO_1();
            int dwWritten = 0;

            try
            {
                // Mở kết nối tới máy in
                if (!OpenPrinter(printerName, out hPrinter, IntPtr.Zero))
                    throw new Exception($"Không thể mở máy in. Mã lỗi: {Marshal.GetLastWin32Error()}");

                // Đọc toàn bộ file PDF
                byte[] pdfBytes = File.ReadAllBytes(pdfPath);

                // Thiết lập thông tin tài liệu
                docInfo.pDocName = Path.GetFileName(pdfPath);
                docInfo.pDataType = "RAW"; // Hoặc "PDF" nếu driver hỗ trợ

                // Bắt đầu quá trình in
                if (!StartDocPrinter(hPrinter, 1, ref docInfo))
                    throw new Exception($"Không thể bắt đầu tài liệu in. Mã lỗi: {Marshal.GetLastWin32Error()}");

                if (!StartPagePrinter(hPrinter))
                    throw new Exception($"Không thể bắt đầu trang in. Mã lỗi: {Marshal.GetLastWin32Error()}");

                // Gửi dữ liệu PDF tới máy in
                IntPtr pUnmanagedBytes = Marshal.AllocCoTaskMem(pdfBytes.Length);
                Marshal.Copy(pdfBytes, 0, pUnmanagedBytes, pdfBytes.Length);

                if (!WritePrinter(hPrinter, pUnmanagedBytes, pdfBytes.Length, out dwWritten))
                    throw new Exception($"Không thể gửi dữ liệu tới máy in. Mã lỗi: {Marshal.GetLastWin32Error()}");

                Marshal.FreeCoTaskMem(pUnmanagedBytes);

                // Kết thúc quá trình in
                EndPagePrinter(hPrinter);
                EndDocPrinter(hPrinter);
            }
            finally
            {
                if (hPrinter != IntPtr.Zero)
                    ClosePrinter(hPrinter);
            }
        }
    }


}

