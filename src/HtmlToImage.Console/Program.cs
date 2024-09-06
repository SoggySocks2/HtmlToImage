using HtmlToImage.Library;

var sampleFile = System.Configuration.ConfigurationManager.AppSettings["SampleFile"];
if (string.IsNullOrWhiteSpace(sampleFile)) throw new ArgumentException("SampleFile is not configured in AppSettings");

var outputPath = System.Configuration.ConfigurationManager.AppSettings["OutputPath"];
if (string.IsNullOrWhiteSpace(outputPath)) throw new ArgumentException("outputPath is not configured in AppSettings");
if (!outputPath.EndsWith('\\')) outputPath += "\\";

var outputFileExtention = System.Configuration.ConfigurationManager.AppSettings["OutputFileExtention"];
if (string.IsNullOrWhiteSpace(outputFileExtention)) throw new ArgumentException("OutputFileExtention is not configured in AppSettings");
outputFileExtention = outputFileExtention.Replace('.', ' ').Trim();

var imageWidth = System.Configuration.ConfigurationManager.AppSettings["ImageWidth"];
if (string.IsNullOrWhiteSpace(imageWidth)) throw new ArgumentException("ImageWidth is not configured in AppSettings");
if (!int.TryParse(imageWidth, out int width)) throw new ArgumentException("ImageWidth is not a valid integer");

var imageHeight = System.Configuration.ConfigurationManager.AppSettings["ImageHeight"];
if (string.IsNullOrWhiteSpace(imageHeight)) throw new ArgumentException("imageHeight is not configured in AppSettings");
if (!int.TryParse(imageHeight, out int height)) throw new ArgumentException("imageHeight is not a valid integer");

var htmlToImageProviderName = System.Configuration.ConfigurationManager.AppSettings["HtmlToImageProvider"];
if (string.IsNullOrWhiteSpace(htmlToImageProviderName)) throw new ArgumentException("htmlToImageProviderName is not configured in AppSettings");

if (htmlToImageProviderName.Equals("Test", StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine("Test provider is selected. No image will be generated.");
    Console.WriteLine("Press any key to exit.");
    return;
}

var imageGenerator = HtmlToImageGeneratorFactory.GetHtmlToImageGenerator(htmlToImageProviderName);

var outputFileName = $"{Guid.NewGuid()}";
string fileContent = await File.ReadAllTextAsync(sampleFile);
await imageGenerator.GenerateImageAsync(fileContent, width, height, outputPath, outputFileName, outputFileExtention);