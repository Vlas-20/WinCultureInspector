using System.Globalization;

Console.OutputEncoding = System.Text.Encoding.UTF8;

PrintHeader("WinCultureInspector -- Basic Information");

PrintSection("Current UI Language");
var ui = CultureInfo.CurrentUICulture;
Console.WriteLine($"Name:        {ui.DisplayName} ({ui.Name})");
Console.WriteLine($"NativeName:  {ui.NativeName}");

PrintSection("Current Culture (Formats)");
var cur = CultureInfo.CurrentCulture;
Console.WriteLine($"Name:        {cur.DisplayName} ({cur.Name})");
Console.WriteLine($"IetfTag:     {cur.IetfLanguageTag}");
Console.WriteLine($"Date today:  {DateTime.Now.ToString("F", cur)}");

PrintSection("Region -- Information about the region is derived from the Culture Information");
var region = new RegionInfo(cur.Name);
Console.WriteLine($"Region:      {region.DisplayName} ({region.Name})");
Console.WriteLine($"ISO:         {region.TwoLetterISORegionName}/{region.ThreeLetterISORegionName}");
Console.WriteLine($"Currency:    {region.CurrencyNativeName} ({region.CurrencySymbol})");

Console.WriteLine();
Console.WriteLine("Done. Press any key to exit …");
Console.ReadKey(true);

void PrintHeader(string title)
{
    Console.WriteLine(title);
    Console.WriteLine(new string('=', title.Length));
    Console.WriteLine();
}

void PrintSection(string title)
{
    Console.WriteLine();
    Console.WriteLine(title);
    Console.WriteLine(new string('-', title.Length));
}