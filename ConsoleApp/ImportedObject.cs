namespace ConsoleApp
{
    public class ImportedObject
    {
        public string Name { get; set; }

        public string Schema;

        public string Type { get; set; }

        public string ParentName;

        public string ParentType { get; set; }

        public string DataType { get; set; }

        public string IsNullable { get; set; }

        public double NumberOfChildren;
    }
}
