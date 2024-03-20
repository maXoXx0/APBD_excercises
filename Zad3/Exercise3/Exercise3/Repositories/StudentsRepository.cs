using Exercise3.Models;
using Exercise3.Services;

namespace Exercise3.Repositories
{
    public interface IStudentsRepository
    {
        IEnumerable<Student> GetStudents();
        Task DeleteStudent(Student student);
        Task AddStudent(Student student);
        Task UpdateStudent(Student student, Student newData);
    }

    public class StudentsRepository : IStudentsRepository
    {

        private readonly IFileDbService _fileDbService;

        public StudentsRepository(IFileDbService fileDbService)
        {
            _fileDbService = fileDbService;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _fileDbService.Students;
        }

        public async Task DeleteStudent(Student student)
        {
            if (_fileDbService.Students.ToList().Contains(student))
            {
                List<Student> stList = _fileDbService.Students.ToList();
                stList.Remove(student);
                _fileDbService.Students = stList;
            }

             await _fileDbService.SaveChanges();
        }

        public async Task AddStudent(Student student)
        {
            List<Student> stList = _fileDbService.Students.ToList();
            stList.Add(student);
            _fileDbService.Students = stList;

            await _fileDbService.SaveChanges();
        }

        public async Task UpdateStudent(Student student, Student newData)
        {
            List<Student> stList = _fileDbService.Students.ToList();
            stList.Remove(student);
            stList.Add(newData);
            _fileDbService.Students = stList;

            await _fileDbService.SaveChanges();
        }
    }
}