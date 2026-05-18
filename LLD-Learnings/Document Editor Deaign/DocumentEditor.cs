using System;
using System.Collections.Generic;

namespace DocumentEditorLLD
{
    // =========================================================
    // 1. Common Interface for All Document Elements
    // =========================================================

    public interface IDocumentElement
    {
        void Render();
    }

    // =========================================================
    // 2. Text Element
    // =========================================================

    public class TextElement : IDocumentElement
    {
        public string Text { get; set; }

        public TextElement(string text)
        {
            Text = text;
        }

        public void Render()
        {
            Console.WriteLine($"Text: {Text}");
        }
    }

    // =========================================================
    // 3. Image Element
    // =========================================================

    public class ImageElement : IDocumentElement
    {
        public string ImagePath { get; set; }

        public ImageElement(string imagePath)
        {
            ImagePath = imagePath;
        }

        public void Render()
        {
            Console.WriteLine($"Image: {ImagePath}");
        }
    }

    // =========================================================
    // 4. Document Class
    // =========================================================

    public class Document
    {
        private readonly List<IDocumentElement> elements=new List<IDocumentElement>();

        public void AddElement(IDocumentElement element)
        {
            elements.Add(element);
        }

        public void Render()
        {
            Console.WriteLine("----- Document Content -----");

            foreach (var element in elements)
            {
                element.Render();
            }

            Console.WriteLine("----------------------------");
        }
    }

    // =========================================================
    // 5. Storage Interface
    // =========================================================

    public interface IStorageService
    {
        void Save(Document document);
    }

    // =========================================================
    // 6. File Storage Implementation
    // =========================================================

    public class FileStorageService : IStorageService
    {
        public void Save(Document document)
        {
            Console.WriteLine("Document saved to FILE storage.");
        }
    }

    // =========================================================
    // 7. Database Storage Implementation
    // =========================================================

    public class DatabaseStorageService : IStorageService
    {
        public void Save(Document document)
        {
            Console.WriteLine("Document saved to DATABASE.");
        }
    }

    // =========================================================
    // 8. Document Editor
    // =========================================================

    public class DocumentEditor
    {
        private readonly Document document;
        private readonly IStorageService storageService;

        public DocumentEditor(IStorageService storageService)
        {
            document = new Document();
            this.storageService = storageService;
        }

        public void AddText(string text)
        {
            document.AddElement(new TextElement(text));
        }

        public void AddImage(string imagePath)
        {
            document.AddElement(new ImageElement(imagePath));
        }

        public void RenderDocument()
        {
            document.Render();
        }

        public void SaveDocument()
        {
            storageService.Save(document);
        }
    }

    // =========================================================
    // 9. Main Program
    // =========================================================

    class Program
    {
        static void Main(string[] args)
        {
            IStorageService storageService =
                new FileStorageService();

            // Create editor
            DocumentEditor editor =
                new DocumentEditor(storageService);

            // Add content
            editor.AddText("Hello World");

            editor.AddImage("company_logo.png");

            editor.AddText("This is a low level design example.");

            // Render document
            editor.RenderDocument();

            // Save document
            editor.SaveDocument();

            Console.ReadLine();
        }
    }
}