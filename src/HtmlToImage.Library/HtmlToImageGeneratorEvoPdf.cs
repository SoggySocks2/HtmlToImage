namespace HtmlToImage.Library;

/// <summary>
/// https://www.evopdf.com/netcore-html-to-pdf-converter.aspx
/// Before using this library, you need to install the EVO PDF Server.
/// ** Ensure to install the latest version of EvoPdf.Client NuGet package **
/// </summary>
public class HtmlToImageGeneratorEvoPdf : IHtmlToImageGenerator
{
    public async Task GenerateImageAsync(string html, int width, int height, string targetPath)
    {
        await (Task.Delay(1));

        throw new NotImplementedException(nameof(HtmlToImageGeneratorEvoPdf));
    }
}
