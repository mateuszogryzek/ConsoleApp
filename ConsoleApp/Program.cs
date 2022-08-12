namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
        var printer = new DataPrinter();
        printer.PrintData("data.csv", false);
        }
    }
}
