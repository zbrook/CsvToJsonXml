Simple utility which converts CSV to XML and/or JSON.

1. Instantiate one OutputFormatter class of appropriate type for each desired output format
1. Run the static Converter.Convert method

See unit tests for example use.

If you feed the JsonOutputterFormat a "datasetName", it will create an object to encapsulate the array of records from CSV. Otherwise the JSON output file will be a naked array.
