using HtmlToImage.Library;

var sampleFile = System.Configuration.ConfigurationManager.AppSettings["SampleFile"];
if (string.IsNullOrWhiteSpace(sampleFile)) throw new ArgumentException("SampleFile is not configured in AppSettings");

var outputPath = System.Configuration.ConfigurationManager.AppSettings["OutputPath"];
if (string.IsNullOrWhiteSpace(outputPath)) throw new ArgumentException("outputPath is not configured in AppSettings");

var imageWidth = System.Configuration.ConfigurationManager.AppSettings["ImageWidth"];
if (string.IsNullOrWhiteSpace(imageWidth)) throw new ArgumentException("ImageWidth is not configured in AppSettings");
if (!int.TryParse(imageWidth, out int width)) throw new ArgumentException("ImageWidth is not a valid integer");

var imageHeight = System.Configuration.ConfigurationManager.AppSettings["ImageHeight"];
if (string.IsNullOrWhiteSpace(imageHeight)) throw new ArgumentException("imageHeight is not configured in AppSettings");
if (!int.TryParse(imageHeight, out int height)) throw new ArgumentException("imageHeight is not a valid integer");

var htmlToImageProviderName = System.Configuration.ConfigurationManager.AppSettings["HtmlToImageProvider"];
if (string.IsNullOrWhiteSpace(htmlToImageProviderName)) throw new ArgumentException("htmlToImageProviderName is not configured in AppSettings");

string fileContent = await File.ReadAllTextAsync(sampleFile);

if (!outputPath.EndsWith('\\')) outputPath += "\\";
outputPath += $"{Guid.NewGuid()}.png";

var imageGenerator = HtmlToImageGeneratorFactory.GetHtmlToImageGenerator(htmlToImageProviderName);
await imageGenerator.GenerateImageAsync(fileContent, width, height, outputPath);