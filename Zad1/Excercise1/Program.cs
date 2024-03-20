using System.Net;
using System.Text.RegularExpressions;


var client = new HttpClient();
if (args.Length < 1) throw new ArgumentNullException();
if (!Uri.IsWellFormedUriString(args[0], UriKind.Absolute)) throw new ArgumentException();

var url = args[0];
var httpClient = new HttpClient();
var regex = new Regex(@"[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+");
HashSet<String> set = new HashSet<String>();

var response = await httpClient.GetAsync(url);
var statusCode = ((int)response.StatusCode);

if (!(statusCode >= 200 && statusCode <= 299)) throw new Exception("Błąd w czasie pobierania strony");

string content = await response.Content.ReadAsStringAsync();

MatchCollection matches = regex.Matches(content);
foreach (Match match in matches)
{
    set.Add(match.Value);
}

if (set.Count > 0)
{
    foreach (var item in set)
    {
        Console.WriteLine(item);
    }
}
else
{
    throw new Exception("Nie znaleziono adresów email");
}