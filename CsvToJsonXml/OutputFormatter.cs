using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CsvToJsonXml
{
    public abstract class OutputFormatter : IOutputFormatter
    {
        public string OutputFilename { get; set; }
        protected StreamWriter streamWriter;
        protected FileStream fileStream;
        protected string datasetName;
        protected string recordName;

        /// <summary>
        /// Object which dictates output file format and path.
        /// </summary>
        /// <param name="filename">Full output file path</param>
        /// <param name="datasetName">Name of property which describes the array of records</param>
        /// <param name="recordName">Name of the property which describes each record</param>
        public OutputFormatter(string filename, string datasetName = null, string recordName = null)
        {
            this.OutputFilename = filename;
            this.fileStream = new FileStream(this.OutputFilename, FileMode.Create, FileAccess.Write, FileShare.None);
            this.streamWriter = new StreamWriter(this.fileStream);
            this.datasetName = datasetName;
            this.recordName = recordName;
        }

        ~OutputFormatter()
        {
            this.Dispose();
        }

        public abstract void StartDocument();

        public abstract void EndDocument();

        public abstract void StartRecord();

        public abstract void EndRecord();

        public abstract void WriteElement(string elementName, string value);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (this.streamWriter != null)
            {
                this.streamWriter.Dispose();
                this.streamWriter = null;
            }
            if (this.fileStream != null)
            {
                this.fileStream.Dispose();
                this.fileStream = null;
            }
        }
    }
}
