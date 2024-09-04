namespace HtmlToImage.Library;
public static class HtmlToImageGeneratorFactory
{
    public static IHtmlToImageGenerator GetHtmlToImageGenerator(string providerName)
    {
        switch (providerName)
        {
            case "Puppeteer":
                return new HtmlToImageGeneratorPuppeteer();
            case "EvoPdf":
                return new HtmlToImageGeneratorEvoPdf();
            case "Generic":
                return new HtmlToImageGeneratorGeneric();
            default:
                throw new NotSupportedException($"Provider {providerName} is not supported");
        }
    }
}
