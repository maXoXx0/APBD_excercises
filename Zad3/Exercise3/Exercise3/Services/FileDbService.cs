using Exercise3.Models;

namespace Exercise3.Services
{
    public interface IFileDbService
    {
        public IEnumerable<Student> Students { get; set; }
        Task SaveChanges();
    }

    public class FileDbService : IFileDbService
    {
        private readonly string _pathToFileDatabase;
        public IEnumerable<Student> Students { get; set; } = new List<Student>();
        public FileDbService(IConfiguration configuration)
        {
            _pathToFileDatabase = configuration.GetConnectionString("Default") ?? throw new ArgumentNullException(nameof(configuration));
            Initialize();
        }

        private void Initialize()
        {
            if (!File.Exists(_pathToFileDatabase))
            {
                return;
            }
            var lines = File.ReadLines(_pathToFileDatabase);

            var students = new List<Student>();

            foreach (var line in lines)
            {

                //Tutaj należy przeparsować dane ze zmiennej lines, tak jak w drugim zadaniu
                var data = line.Split(',');
                var student = new Student
                {
                    FirstName = data[0],
                    LastName = data[1],
                    IndexNumber = data[2],
                    BirthDate = data[3],
                    StudyName = data[4],
                    StudyMode = data[5],
                    Email = data[6],
                    FathersName = data[7],
                    MothersName = data[8],
                };
                students.Add(student);
            }
            Students = students;
        }

        public async Task SaveChanges()
        {
            List<string> data = new List<string>();
            foreach (var student in Students)
            {
                data.Add($"{student.FirstName},{student.LastName},{student.IndexNumber},{student.BirthDate},{student.StudyName},{student.StudyMode},{student.Email},{student.FathersName},{student.MothersName}");
            }
            
            await File.WriteAllLinesAsync(
                _pathToFileDatabase, 
                data //tutaj należy zapewnić listę stringów zawierającą odpowiednio sformatowane dane studentów
                     // np. Jan,Kowalski,s1234,3/20/1991,Informatyka,Dzienne,kowalski@wp.pl,Jan,Anna
                );
        }

    }
}
