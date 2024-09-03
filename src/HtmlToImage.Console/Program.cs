using HtmlToImage.Library;


string startupPath = AppContext.BaseDirectory;
var filePath = Path.Combine(startupPath, "../../../../../_SolutionItems/");

string sampleFilePath = Path.Combine(filePath, "SampleHtmlFile/Sample1.html");
string fileContent = await File.ReadAllTextAsync(sampleFilePath);

var outputPath = Path.Combine(filePath, $"ThumbnailImages/{Guid.NewGuid()}.png");
await ImageGenerator.GenerateImageAsync(fileContent, 400, 300, outputPath);