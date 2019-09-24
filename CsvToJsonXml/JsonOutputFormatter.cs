using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsvToJsonXml
{
    public class JsonOutputFormatter : OutputFormatter
    {
        JsonWriter jsonWriter;

        public JsonOutputFormatter(string filename, string datasetName = null) : base(filename, datasetName, null)
        {
            this.jsonWriter = new JsonTextWriter(this.streamWriter);
            this.jsonWriter.Formatting = Newtonsoft.Json.Formatting.Indented;
        }

        public override void StartDocument()
        {
            if (!string.IsNullOrEmpty(this.datasetName))
            {
                this.jsonWriter.WriteStartObject();
                this.jsonWriter.WritePropertyName(this.datasetName);
            }
            this.jsonWriter.WriteStartArray();
        }

        public override void EndDocument()
        {
            this.jsonWriter.WriteEndArray();
            if (!string.IsNullOrEmpty(this.datasetName))
                this.jsonWriter.WriteEndObject();
        }

        public override void StartRecord()
        {
            this.jsonWriter.WriteStartObject();
        }

        public override void EndRecord()
        {
            this.jsonWriter.WriteEndObject();
        }

        public override void WriteElement(string elementName, string value)
        {
            this.jsonWriter.WritePropertyName(elementName);
            this.jsonWriter.WriteValue(value);
        }
    }
}
