using Exercise.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise.Services
{
    public interface IDataService
    {
        event Action<Teacher> StudentsByTeacher;
        Task<IEnumerable<Teacher>> GetTeachersAsync();
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<IEnumerable<CourseType>> GetCoursesAsync();
        void GetStudentsByTeacherAsync(Teacher teacher);
        void AddCourseToTeacher(Teacher teacher, CourseType course);
        void RemoveCourseFromTeacher(Teacher teacher, CourseType course);
    }
}
