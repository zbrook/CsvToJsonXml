using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace CsvToJsonXml
{
    public class XmlOutputFormatter : OutputFormatter
    {
        XmlTextWriter xmlWriter;

        public XmlOutputFormatter(string filename, string datasetName, string recordName) : base(filename, datasetName, recordName)
        {
            this.xmlWriter = new XmlTextWriter(this.streamWriter);
            xmlWriter.Formatting = System.Xml.Formatting.Indented;
        }

        public override void StartDocument()
        {
            this.xmlWriter.WriteStartDocument();
            this.xmlWriter.WriteStartElement(this.datasetName);
        }

        public override void EndDocument()
        {
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
        }

        public override void StartRecord()
        {
            xmlWriter.WriteStartElement(this.recordName);
        }

        public override void EndRecord()
        {
            xmlWriter.WriteEndElement();
        }

        public override void WriteElement(string elementName, string value)
        {
            xmlWriter.WriteStartElement(elementName);
            xmlWriter.WriteString(value);
            xmlWriter.WriteEndElement();
        }

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
            if (this.xmlWriter != null)
            {
                this.xmlWriter.Dispose();
                this.xmlWriter = null;
            }
        }
    }
}
