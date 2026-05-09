using System.Text;

string directoryPath = "sales";

// this create sales directory if it doesn't exist
if (!Directory.Exists(directoryPath))
{
    Directory.CreateDirectory(directoryPath);
}

// Create sample sales files
File.WriteAllText(Path.Combine(directoryPath, "week1.txt"), "1500.50");
File.WriteAllText(Path.Combine(directoryPath, "week2.txt"), "2750.75");
File.WriteAllText(Path.Combine(directoryPath, "week3.txt"), "3200.00");

Console.WriteLine("Sales files created successfully.");

GenerateSalesSummary(directoryPath);

static void GenerateSalesSummary(string directoryPath)
{
    string[] files = Directory.GetFiles(directoryPath);

    decimal totalSales = 0;

    StringBuilder report = new StringBuilder();

    report.AppendLine("Sales Summary");
    report.AppendLine("----------------------------");

    List<string> detailLines = new List<string>();

    foreach (string file in files)
    {
        string content = File.ReadAllText(file);

        if (decimal.TryParse(content, out decimal sales))
        {
            totalSales += sales;

            string fileName = Path.GetFileName(file);

            detailLines.Add($"{fileName}: {sales:C}");
        }
    }

    report.AppendLine($"Total Sales: {totalSales:C}");
    report.AppendLine();
    report.AppendLine("Details:");

    foreach (string line in detailLines)
    {
        report.AppendLine($"  {line}");
    }

    string reportPath = Path.Combine(directoryPath, "SalesSummaryReport.txt");

    File.WriteAllText(reportPath, report.ToString());

    Console.WriteLine("Sales summary report generated.");
    Console.WriteLine();
    Console.WriteLine(report.ToString());
}