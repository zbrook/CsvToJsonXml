using System;
using System.Collections.Generic;
using System.Text;

namespace CsvToJsonXml
{
    public interface IOutputFormatter : IDisposable
    {
        string OutputFilename { get; set; }

        void StartDocument();
        void EndDocument();
        void StartRecord();
        void EndRecord();
        void WriteElement(string elementName, string value);
    }
}
