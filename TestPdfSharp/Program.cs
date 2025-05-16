using SATOPrinterAPI;
using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Printer printer = new Printer();
        Driver satoDriver = new Driver();
        
        List<Driver.Info> drivers = satoDriver.GetDriverList();
        foreach (Driver.Info driver in drivers) 
        {
            Console.WriteLine(driver);
        }   
    }
}