package factorymethodpatternexample.Excel;

import factorymethodpatternexample.Document;
import factorymethodpatternexample.DocumentFactory;

// Factory for Excel Documents
public class ExcelDocumentFactory extends DocumentFactory {
    @Override
    public Document createDocument() {
        return new ExcelDocument();
    }
}