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

CheckIfUiCultureAndCultureAreConsistent();

Console.WriteLine();
Console.WriteLine("Done. Press any key to exit …");
Console.ReadKey(true);

void CheckIfUiCultureAndCultureAreConsistent()
{
    var consistent = ui.IetfLanguageTag == cur.IetfLanguageTag;

    PrintSection("Culture Consistency Check");
    
    if (consistent)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("UI culture and CurrentCulture are consistent.");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("UI culture and CurrentCulture differ!");
        Console.ResetColor();
        Console.WriteLine($"UI Culture:      {CultureInfo.CurrentUICulture.DisplayName} ({CultureInfo.CurrentUICulture.Name})");
        Console.WriteLine($"Current Culture: {CultureInfo.CurrentCulture.DisplayName} ({CultureInfo.CurrentCulture.Name})");
    }

    Console.ResetColor();
}

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