using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsvToJsonXmlTests
{
    [TestClass]
    public class CsvConversionTest
    {
        string inputFilename = @"";
        string jsonOutputFilename = @"";
        string xmlOutputFilename = @"";
        string datasetName = "Records";
        string recordName = "Record";

        [TestMethod]
        public void GenerateJsonAndXml()
        {
            CsvToJsonXml.JsonOutputFormatter jsonFormatter = new CsvToJsonXml.JsonOutputFormatter(jsonOutputFilename, datasetName);
            CsvToJsonXml.XmlOutputFormatter xmlFormatter = new CsvToJsonXml.XmlOutputFormatter(xmlOutputFilename, datasetName, recordName);
            CsvToJsonXml.Converter.Convert(new CsvToJsonXml.IOutputFormatter[] { jsonFormatter, xmlFormatter }, inputFilename, true);
        }

        [TestMethod]
        public void GenerateJsonAsObject()
        {
            CsvToJsonXml.JsonOutputFormatter jsonFormatter = new CsvToJsonXml.JsonOutputFormatter(jsonOutputFilename, datasetName);
            CsvToJsonXml.Converter.Convert(new CsvToJsonXml.IOutputFormatter[] { jsonFormatter }, inputFilename, true);
        }

        [TestMethod]
        public void GenerateJsonAsArray()
        {
            CsvToJsonXml.JsonOutputFormatter jsonFormatter = new CsvToJsonXml.JsonOutputFormatter(jsonOutputFilename);
            CsvToJsonXml.Converter.Convert(new CsvToJsonXml.IOutputFormatter[] { jsonFormatter }, inputFilename, true);
        }
    }
}
