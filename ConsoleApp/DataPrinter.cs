using System;
using System.Diagnostics;

namespace ConsoleApp
{
    public class DataPrinter
    {
        readonly DataReader dataReader = new DataReader();
        private Stopwatch sw = new Stopwatch();
        
        public void PrintData(string fileToImport, bool isDataPrint)
        {
            if (isDataPrint == false) return;

            var importedObjects = dataReader.ImportData(fileToImport);
            
            foreach (var database in importedObjects)
            {
                if (database.Type != "DATABASE") continue;
                Console.WriteLine($"Database '{database.Name}' ({database.NumberOfChildren} tables)");

                // print all database's tables
                foreach (var table in importedObjects)
                {
                    if (table.ParentType.ToUpper() != database.Type) continue;
                    if (table.ParentName != database.Name) continue;
                    Console.WriteLine($"\tTable '{table.Schema}.{table.Name}' ({table.NumberOfChildren} columns)");


                    // print all table's columns
                    foreach (var column in importedObjects)
                    {
                        if (column.ParentType.ToUpper() != table.Type) continue;
                        if (column.ParentName == table.Name)
                            Console.WriteLine($"\t\tColumn '{column.Name}' with {column.DataType} data type {(column.IsNullable == "1" ? "accepts nulls" : "with no nulls")}");
                    }
                }
            }
           
            Console.ReadLine();
        }
    }
}
