using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;

namespace HtmlToImage.Library;

/// <summary>
/// https://products.aspose.com/html/net/
/// ** Ensure to install the latest version of Aspose.HTML NuGet package **
/// </summary>
public class HtmlToImageGeneratorAspose : IHtmlToImageGenerator
{
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
    }
}
