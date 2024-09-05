using PuppeteerSharp;

namespace HtmlToImage.Library;

/// <summary>
/// https://www.puppeteersharp.com/docs/index.html
/// ** Ensure to install the latest version of PuppeteerSharp NuGet package **
/// You may need to install additional dependencies for Chromium to run properly on Linux. For example, you might need
/// to install libglib2.0-0, libnss3, libnspr4, libatk1.0-0, libatk-bridge2.0-0, libcups2, libdrm2, libdbus-1-3, libxkbcommon0, 
/// libxcomposite1, libxdamage1, libxrandr2, libgbm1, libasound2, and other related libraries. 
/// These can typically be installed using your distribution's package manager.
///
/// If you're running Puppeteer-Sharp in a Docker container on Linux, you'll need to ensure your Docker image includes these dependencies.
/// </summary>
public class HtmlToImageGeneratorPuppeteer : IHtmlToImageGenerator
{
    public async Task GenerateImageAsync(string html, int width, int height, string targetPath, string targetFileName, string targetFileExtension)
    {
        var browserFetcher = new BrowserFetcher();

        /* Will download the latest version of Chromium for the current platform if not already installed */
        await browserFetcher.DownloadAsync();

        await using var browser = await Puppeteer.LaunchAsync(
            new LaunchOptions { Headless = true });

        await using var page = await browser.NewPageAsync();

        await page.SetViewportAsync(new ViewPortOptions
        {
            Width = width,
            Height = height
        });

        await page.SetContentAsync(html);

        await page.ScreenshotAsync($"{targetPath}{targetFileName}.{targetFileExtension}");
        await browser.CloseAsync();

        await GeneratePdf(html, targetPath, targetFileName);
    }

    private static async Task GeneratePdf(string html, string targetPath, string targetFileName)
    {
        var browserFetcher = new BrowserFetcher();
        await browserFetcher.DownloadAsync();

        var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true
        });
        var page = await browser.NewPageAsync();
        await page.SetContentAsync(html);

        var outputFile = $"{targetPath}{targetFileName}.pdf";
        await page.PdfAsync(outputFile);
    }
}
