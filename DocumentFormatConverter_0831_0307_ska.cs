// 代码生成时间: 2025-08-31 03:07:42
using System;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

/// <summary>
/// A simple document format converter that can convert Word documents to plain text.
/// </summary>
public class DocumentFormatConverter
{
    /// <summary>
    /// Converts a Word document to plain text.
    /// </summary>
    /// <param name="inputFilePath">The path to the Word document to convert.</param>
    /// <param name="outputFilePath">The path to save the converted plain text file.</param>
    public void ConvertWordToText(string inputFilePath, string outputFilePath)
    {
        try
        {
            // Check if input file exists
            if (!File.Exists(inputFilePath))
            {
                throw new FileNotFoundException("Input file not found.", inputFilePath);
            }

            // Open the Word document
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(inputFilePath, true))
            {
                // Assign the MainDocumentPart to a variable and get the root element (document body)
                MainDocumentPart mainPart = wordDocument.MainDocumentPart;
                Body body = mainPart.Document.Body;

                // Initialize a StringBuilder to store the text content
                var textBuilder = new StringBuilder();

                // Iterate through each paragraph in the document body and extract text
                foreach (var paragraph in body.Elements<Paragraph>())
                {
                    // Extract text from each paragraph and append to the StringBuilder
                    textBuilder.Append(paragraph.InnerText);
                    textBuilder.Append("
");
                }

                // Write the extracted text to the output file
                File.WriteAllText(outputFilePath, textBuilder.ToString());
            }
        }
        catch (Exception ex)
        {
            // Log or handle the exception as needed
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    /// <summary>
    /// Entry point for the converter application.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    public static void Main(string[] args)
    {
        // Check for valid arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: DocumentFormatConverter.exe <inputWordFilePath> <outputTextFilePath>");
            return;
        }

        // Create an instance of the converter and perform the conversion
        var converter = new DocumentFormatConverter();
        converter.ConvertWordToText(args[0], args[1]);
    }
}
