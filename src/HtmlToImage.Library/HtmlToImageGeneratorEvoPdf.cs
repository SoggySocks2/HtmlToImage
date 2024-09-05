using EvoPdfClient;

namespace HtmlToImage.Library;

/// <summary>
/// https://www.evopdf.com/netcore-html-to-pdf-converter.aspx
/// Before using this library, you need to install the EVO PDF Server which can be downloaded from https://www.evopdf.com/netcore-html-to-pdf-converter.aspx
/// Ensure to install the latest version of EvoPdf.Client NuGet package
/// </summary>
public class HtmlToImageGeneratorEvoPdf : IHtmlToImageGenerator
{
    private readonly string _evoPdfServerIpAddress;
    private readonly uint _evoPdfServerPort;

    public HtmlToImageGeneratorEvoPdf()
    {
        var evoPdfServerIpAddress = System.Configuration.ConfigurationManager.AppSettings["EvoPdfServerIP"];
        if (string.IsNullOrWhiteSpace(evoPdfServerIpAddress)) throw new ArgumentException("EvoPdfServerIP is not configured in AppSettings");

        var evoPdfServerPort = System.Configuration.ConfigurationManager.AppSettings["EvoPdfServerPort"];
        if (string.IsNullOrWhiteSpace(evoPdfServerPort)) throw new ArgumentException("evoPdfServerPort is not configured in AppSettings");
        if (!uint.TryParse(evoPdfServerPort, out uint port)) throw new ArgumentException("evoPdfServerPort is not a valid integer");

        _evoPdfServerPort = port;
        _evoPdfServerIpAddress = evoPdfServerIpAddress;

    }
    public async Task GenerateImageAsync(string html, int width, int height, string targetPath, string targetFileName, string targetFileExtension)
    {
        // Emulate an await operation since this is required to be an async method to be compatible identical to the other implementations
        await Task.Delay(1);

        // Create a HTML to Image converter object with default settings
        var htmlToPdfConverter = new HtmlToPdfConverter(_evoPdfServerIpAddress, _evoPdfServerPort)
        {
            // leave empty to run in demo mode
            LicenseKey = "",
            PdfDocumentOptions = {
                PdfPageSize = PdfPageSize.A9
            }
        };

        // convert a HTML string to a memory buffer
        byte[] htmlToPdfBuffer = htmlToPdfConverter.ConvertHtml(html, null);

        //create the converter object and set the user options
        var pdfToImageConverter = new PdfToImageConverter
        {
            //leave empty to run in demo mode
            LicenseKey = "",

            //set the color space of the resulted images
            ColorSpace = PdfPageImageColorSpace.RGB,

            //set the resolution of the resulted images
            Resolution = 150
        };

        pdfToImageConverter.ConvertPdfPagesToImageFile(htmlToPdfBuffer, targetPath, targetFileName);
        GeneratePdf(html, targetPath, targetFileName);
    }

    private void GeneratePdf(string html, string targetPath, string targetFileName)
    {
        var htmlToPdfConverter = new HtmlToPdfConverter(_evoPdfServerIpAddress, _evoPdfServerPort)
        {
            // leave empty to run in demo mode
            LicenseKey = "",
            PdfDocumentOptions = {
                PdfPageSize = PdfPageSize.A4
            }
        };

        var outputFile = $"{targetPath}{targetFileName}.pdf";
        htmlToPdfConverter.ConvertHtmlToFile(html, null, outputFile);
    }
}
