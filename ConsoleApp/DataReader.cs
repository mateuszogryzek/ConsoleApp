using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
    
    public class DataReader
    {
        IEnumerable<ImportedObject> ImportedObjects;

        public IEnumerable<ImportedObject> ImportData(string fileToImport)
        {
            ImportedObjects = new List<ImportedObject>();

            try
            {
                var streamReader = new StreamReader(fileToImport);

                var importedLines = new List<string>();
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    importedLines.Add(line);
                }

                for (int i = 0; i < importedLines.Count; i++)
                {
                    var importedLine = importedLines[i];
                    var values = importedLine.Split(';');
                    var importedObject = new ImportedObject();
                    importedObject.Type = values[0];
                    importedObject.Name = values[1];
                    importedObject.Schema = values[2];
                    importedObject.ParentName = values[3];
                    importedObject.ParentType = values[4];
                    importedObject.DataType = values[5];
                    importedObject.IsNullable = values[6];
                    ((List<ImportedObject>)ImportedObjects).Add(importedObject);
                }

                // clear and correct imported data
                foreach (var importedObject in ImportedObjects)
                {
                    importedObject.Type = importedObject.Type.Trim().Replace(" ", "").Replace(Environment.NewLine, "").ToUpper();
                    importedObject.Name = importedObject.Name.Trim().Replace(" ", "").Replace(Environment.NewLine, "");
                    importedObject.Schema = importedObject.Schema.Trim().Replace(" ", "").Replace(Environment.NewLine, "");
                    importedObject.ParentName = importedObject.ParentName.Trim().Replace(" ", "").Replace(Environment.NewLine, "");
                    importedObject.ParentType = importedObject.ParentType.Trim().Replace(" ", "").Replace(Environment.NewLine, "");
                }

                // assign number of children
                for (int i = 0; i < ImportedObjects.Count(); i++)
                {
                    var importedObject = ImportedObjects.ToArray()[i];
                    foreach (var impObj in ImportedObjects)
                    {
                        if (impObj.ParentType == importedObject.Type)
                        {
                            if (impObj.ParentName == importedObject.Name)
                            {
                                importedObject.NumberOfChildren = 1 + importedObject.NumberOfChildren;
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ImportedObjects;
        }
    }
}
