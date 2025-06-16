package factorymethodpatternexample.Pdf;

import factorymethodpatternexample.Document;
import factorymethodpatternexample.DocumentFactory;

// Factory for PDF Documents
public class PdfDocumentFactory extends DocumentFactory {
    @Override
    public Document createDocument() {
        return new PdfDocument();
    }
}