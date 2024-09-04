namespace HtmlToImage.Library;
public interface IHtmlToImageGenerator
{
    Task GenerateImageAsync(string html, int width, int height, string targetPath, string targetFileName, string targetFileExtension);
}
