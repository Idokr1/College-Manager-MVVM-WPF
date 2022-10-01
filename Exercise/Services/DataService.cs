using Exercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Services
{
    public class DataService : IDataService
    {
        readonly Model1Container data = new Model1Container();

        public event Action<Teacher> StudentsByTeacher;

        public IEnumerable<Student> GetStudents() => data.People.OfType<Student>();
        public Task<IEnumerable<Student>> GetStudentsAsync() => Task.Run(GetStudents);

        public IEnumerable<Teacher> GetTeachers() => data.People.OfType<Teacher>();
        public Task<IEnumerable<Teacher>> GetTeachersAsync() => Task.Run(GetTeachers);


        public IEnumerable<CourseType> GetCourses() => Enum.GetValues(typeof(CourseType)).Cast<CourseType>();
        public Task<IEnumerable<CourseType>> GetCoursesAsync() => Task.Run(GetCourses);


        public void GetStudentsByTeacher(Teacher teacher) => StudentsByTeacher?.Invoke(teacher);
        public async void GetStudentsByTeacherAsync(Teacher teacher) => await Task.Run(() => GetStudentsByTeacher(teacher));


        public void ChangeStudentGrade(Student student, int newGrade)
        {
            student.Grade = newGrade;
            data.SaveChanges();
        }

        public void AddCourseToTeacher(Teacher teacher, CourseType course)
        {
            if (!teacher.CourseTeach.HasFlag(course))
            {
                teacher.CourseTeach |= course;
                data.SaveChanges();
            }
        }
        public void RemoveCourseFromTeacher(Teacher teacher, CourseType course)
        {
            if (teacher.CourseTeach.HasFlag(course))
            {
                teacher.CourseTeach -= course;
                data.SaveChanges();
            }
        }
    }
}
