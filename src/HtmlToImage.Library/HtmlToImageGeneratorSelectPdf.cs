using SelectPdf;

namespace HtmlToImage.Library;

/// <summary>
/// https://selectpdf.com/community-edition/
/// /// Ensure to install the latest version of Select.HtmlToPdf.NetCore NuGet package
/// </summary>
public class HtmlToImageGeneratorSelectPdf : IHtmlToImageGenerator
{
    public async Task GenerateImageAsync(string html, int width, int height, string targetPath, string targetFileName, string targetFileExtension)
    {
        await Task.Delay(1);

        var converter = new SelectPdf.HtmlToImage()
        {
            WebPageWidth = width,
            WebPageHeight = height
        };
        var img = converter.ConvertHtmlString(html);

        var outputFile = $"{targetPath}{targetFileName}.{targetFileExtension}";
        img.Save(outputFile);

        GeneratePdf(html, targetPath, targetFileName);
    }


    private static void GeneratePdf(string html, string targetPath, string targetFileName)
    {
        var converter = new HtmlToPdf();

        var doc = converter.ConvertHtmlString(html);

        var outputFile = $"{targetPath}{targetFileName}.pdf";

        doc.Save(outputFile);

        doc.Close();
    }
}
