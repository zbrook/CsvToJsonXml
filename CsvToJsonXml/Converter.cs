using System;
using System.Collections.Generic;
using System.IO;

namespace CsvToJsonXml
{
    public class Converter
    {
        public static void Convert(IEnumerable<IOutputFormatter> converters, string inputFilename, string delimiter = ",")
        {
            using (StreamReader inputFile = new StreamReader(inputFilename))
            {
                string line = inputFile.ReadLine(); // first line
                if (line == null)
                {
                    throw new Exception("First line in file " + inputFilename + " was null!");
                }

                string[] propertyNames = line.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var converter in converters)
                    converter.StartDocument();

                int currentLineNumber = 0;
                while ((line = inputFile.ReadLine()) != null)
                {
                    currentLineNumber++;
                    if (string.IsNullOrEmpty(line))
                        continue;

                    foreach (var converter in converters)
                        converter.StartRecord();

                    string[] values = line.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);

                    if (values.Length != propertyNames.Length)
                        throw new Exception("Line " + currentLineNumber.ToString() + ": expected " + propertyNames.Length + ", read " + values.Length);

                    for (int x = 0; x < values.Length; x++)
                    {
                        foreach (var converter in converters)
                            converter.WriteElement(propertyNames[x], values[x]);
                    }

                    foreach (var converter in converters)
                        converter.EndRecord();
                }

                foreach (var converter in converters)
                {
                    converter.EndDocument();
                    converter.Dispose();
                }
            }
        }
    }
}
