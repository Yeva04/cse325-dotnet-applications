Console.WriteLine("Hello, World!");

//string concatenate
//Console.WriteLine("The current time is " + DateTime.Now);

// Using an interpolated string instead of string concatenation
Console.WriteLine($"The current time is {DateTime.Now}");

// Calculate days until next Christmas
DateTime today = DateTime.Now;
DateTime christmas = new DateTime(today.Year, 12, 25);

// If Christmas has already passed this year, use next year's Christmas
if (today > christmas)
{
    christmas = new DateTime(today.Year + 1, 12, 25);
}

int daysUntilChristmas = (christmas - today).Days;

Console.WriteLine($"There are {daysUntilChristmas} days until Christmas!");