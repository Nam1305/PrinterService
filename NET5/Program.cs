using System;
using System.Collections.Generic;
using SATOPrinterAPI;
using static SATOPrinterAPI.Printer;
using System.IO;

namespace NET5
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\vnintern01\Desktop\VN197400-60203T (22).pdf";
            Printer printer = new Printer();
            Driver driver = new Driver();
            printer.Interface = InterfaceType.TCPIP; // Hoặc giá trị tương ứng trong API
            printer.TCPIPAddress = "10.73.132.4";
            printer.TCPIPPort = "9100";
            printer.Connect();
            byte[] pdfBytes = File.ReadAllBytes(path);
            driver.SendRawData("TestPrint", pdfBytes);

        }
    }
}