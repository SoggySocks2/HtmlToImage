namespace HtmlToImage.Library;
public class HtmlToImageGeneratorGeneric : IHtmlToImageGenerator
{
    public async Task GenerateImageAsync(string html, int width, int height, string targetPath, string targetFileName, string targetFileExtension)
    {
        await (Task.Delay(1));

        throw new NotImplementedException(nameof(HtmlToImageGeneratorGeneric));
    }
}
