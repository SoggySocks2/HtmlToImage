using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using Aspose.Pdf;

namespace HtmlToImage.Library;

/// <summary>
/// https://products.aspose.com/html/net/
/// </summary>
public class HtmlToImageGeneratorAspose : IHtmlToImageGenerator
{
    /// <summary>
    /// Ensure to install the latest version of Aspose.HTML NuGet package
    /// </summary>
    /// <returns></returns>
    public async Task GenerateImageAsync(string html, int width, int height, string targetPath, string targetFileName, string targetFileExtension)
    {
        await Task.Delay(1);

        using var document = new HTMLDocument(html, string.Empty);
        var options = new ImageSaveOptions(ImageFormat.Png)
        {
            HorizontalResolution = width,
            VerticalResolution = height,
            Format = ImageFormat.Png,
            BackgroundColor = System.Drawing.Color.White
        };

        var widthLength = Length.FromPixels(width);
        options.PageSetup.AnyPage.Size.Width = widthLength;

        var heightLength = Length.FromPixels(height);
        options.PageSetup.AnyPage.Size.Height = heightLength;

        var outputPath = $"{targetPath}{targetFileName}.{targetFileExtension}";
        Converter.ConvertHTML(document, options, outputPath);

        GeneratePdf(html, targetPath, targetFileName);
    }
    /// <summary>
    /// Ensure to install the latest version of Aspose.PDF NuGet package
    /// </summary>
    /// <returns></returns>
    private static void GeneratePdf(string html, string targetPath, string targetFileName)
    {
        var pdfDocument = new Document();

        var page = pdfDocument.Pages.Add();
        page.Paragraphs.Add(new HtmlFragment(html));

        var outputPath = $"{targetPath}{targetFileName}.pdf";
        pdfDocument.Save(outputPath);
    }
}
