using Excercise2;
using System.Text.Json;


if (args.Length != 4)
{
    throw new ArgumentOutOfRangeException();
}

if (!File.Exists(args[0]) || !File.Exists(args[2]))
{
    throw new FileNotFoundException();
}

if (!Directory.Exists(args[1]))
{
    throw new DirectoryNotFoundException();
}
if (!args[3].Equals("json")){
    throw new InvalidOperationException();
}



string path = args[0];
var students = new HashSet<Student>(new StudentComparer());

string[] studentlines = await File.ReadAllLinesAsync(path);

var kierunekMap = new Dictionary<string, int>();
var studies = new HashSet<ActiveStudies>();

await File.WriteAllTextAsync(args[1], string.Empty);
foreach (string line in studentlines)
{
    var data = line.Split(',');
    if (data.Length != 9)
    {
        //Console.WriteLine("Wiersz nie posiada odpowiedniej ilości kolumn: " + line);
        await File.AppendAllTextAsync(args[1], "Wiersz nie posiada odpowiedniej ilości kolumn: " + line + '\n');
    }
    else
    {
        var puste = false;
        foreach (string val in data)
        {
            if (val.Equals(""))
            {
                puste = true;
                //Console.WriteLine("Wiersz nie może posiadać pustych kolumn:" + line);
                await File.AppendAllTextAsync(args[1], "Wiersz nie może posiadać pustych kolumn:" + line + '\n');
            }
        }
        if (!puste)
        {
            var student = new Student
            {
                Imie = data[0],
                Nazwisko = data[1],
                Kierunek = data[2],
                Tryb = data[3],
                NrIndeksu = int.Parse(data[4]),
                Data = DateOnly.Parse(data[5]),
                Email = data[6],
                ImieMatki = data[7],
                ImieOjca = data[8],
            };

            if (students.Contains(student))
            {
                //Console.WriteLine($"Duplikat: " + line);
                await File.AppendAllTextAsync(args[1], "Duplikat: " + line + '\n');
            }
            else
            {
                students.Add(student);

                if (kierunekMap.Keys.Contains(student.Kierunek))
                {
                    kierunekMap[student.Kierunek] += 1;
                }
                else
                {
                    kierunekMap.Add(student.Kierunek, 1);

                }
            }
        }
    }
}
JsonSerializerOptions serializerOptions = new JsonSerializerOptions
{
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
};

var uczelnia = new Uczelnia
{
    createdAt = DateOnly.FromDateTime(DateTime.Now),
    author = "Maksymilian Janas",
    students = students,
    activeStudies = studies
};


foreach (var kierunek in kierunekMap)
{
    ActiveStudies activeStudies = new ActiveStudies
    {
        name = kierunek.Key,
        numberOfStudents = kierunek.Value
    };
    studies.Add(activeStudies);
}


var jdata = new Data
{
    uczelnia = uczelnia

};

var json = JsonSerializer.Serialize(jdata, serializerOptions);
//var json2 = JsonSerializer.Serialize(uczelnia, serializerOptions);
Console.WriteLine(json);

await File.WriteAllTextAsync(args[2], json);
