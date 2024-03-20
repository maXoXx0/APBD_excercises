using Exercise3.Models;
using Exercise3.Models.DTOs;
using Exercise3.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Exercise3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _studentsRepository;
        public StudentsController(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = _studentsRepository.GetStudents();
            return Ok(data);
        }

        [HttpGet("{index}")]
        public async Task<IActionResult> Get(string index)
        {
            var students = (List<Student>)_studentsRepository.GetStudents();
            var student  = students.ToList().Find(e => e.IndexNumber == index);

            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpPut("{index}")]
        public async Task<IActionResult> Put(string index, StudentPUT newStudentData)
        {
            var students = (List<Student>)_studentsRepository.GetStudents();
            var student = students.ToList().Find(e => e.IndexNumber == index);

            if (student == null)
                return Conflict();

            

            Student newSt = new Student()
            {
                FirstName = newStudentData.FirstName,
                LastName = newStudentData.LastName,
                IndexNumber = index,
                BirthDate = newStudentData.BirthDate,
                StudyName = newStudentData.StudyName,
                StudyMode = newStudentData.StudyMode,
                Email = newStudentData.Email,
                FathersName = newStudentData.FathersName,
                MothersName = newStudentData.MothersName
            };

            if (newSt.FirstName.Equals("") && newSt.LastName.Equals("") && newSt.IndexNumber.Equals("") && newSt.BirthDate.Equals("")
                && newSt.StudyName.Equals("") && newSt.StudyMode.Equals("") && newSt.Email.Equals("") && newSt.FathersName.Equals("")
                && newSt.MothersName.Equals(""))
            {
                return BadRequest();
            }
            await _studentsRepository.UpdateStudent(student, newSt);

            return Ok($"{newSt.FirstName},{newSt.LastName},{newSt.IndexNumber},{newSt.BirthDate},{newSt.StudyName},{newSt.StudyMode},{newSt.Email},{newSt.FathersName},{newSt.MothersName}");

        }

        [HttpPost]
        public async Task<IActionResult> Post(StudentPOST newStudent)
        {
            var students = (List<Student>)_studentsRepository.GetStudents();
            var student = students.ToList().Find(e => e.IndexNumber == newStudent.IndexNumber);

            if (student != null)
                return Conflict();

            

            Student st = new Student()
            {
                FirstName = newStudent.FirstName,
                LastName = newStudent.LastName,
                IndexNumber = newStudent.IndexNumber,
                BirthDate = newStudent.BirthDate,
                StudyName = newStudent.StudyName,
                StudyMode = newStudent.StudyMode,
                Email = newStudent.Email,
                FathersName = newStudent.FathersName,
                MothersName = newStudent.MothersName
            };

            if (st.FirstName.Equals("") && st.LastName.Equals("") && st.IndexNumber.Equals("") && st.BirthDate.Equals("")
                && st.StudyName.Equals("") && st.StudyMode.Equals("") && st.Email.Equals("") && st.FathersName.Equals("") 
                && st.MothersName.Equals(""))
            {
                return BadRequest();
            }    

            await _studentsRepository.AddStudent(st);

            return Created("Dodano nowego studenta", st);
        }

        [HttpDelete("{index}")]
        public async Task<IActionResult> Delete(string index)
        {
            var students = (List<Student>)_studentsRepository.GetStudents();
            var student = students.ToList().Find(e => e.IndexNumber == index);

            if (student == null)
            {
                return NotFound();
            }

            await _studentsRepository.DeleteStudent(student);
            return Ok($"Student {student.FirstName} {student.LastName} {student.IndexNumber} deleted successfully.");
        }

    }
}
