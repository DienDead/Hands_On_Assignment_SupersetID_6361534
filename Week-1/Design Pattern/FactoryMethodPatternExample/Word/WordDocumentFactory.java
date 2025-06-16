package factorymethodpatternexample.Word;

import factorymethodpatternexample.Document;
import factorymethodpatternexample.DocumentFactory;

// Factory for Word Documents
public class WordDocumentFactory extends DocumentFactory {
    @Override
    public Document createDocument() {
        return new WordDocument();
    }
}
