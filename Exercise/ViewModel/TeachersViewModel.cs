using Exercise.Models;
using Exercise.Services;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Exercise.ViewModel
{
    public class TeachersViewModel : MainViewModel
    {
        public ObservableCollection<Teacher> Teachers { get; }
        public Teacher SelectedTeacher { get; set; } = new Teacher() { CourseTeach = CourseType.Python | CourseType.C_Sharp | CourseType.HTML | CourseType.CSS | CourseType.JavaScript | CourseType.Java | CourseType.Kotlin };
        public CourseType SelectedCourse { get; set; }
        public List<CourseType> CourseTypes => service.GetCourses().ToList();

        CourseType _teachersCourses;
        public CourseType TeachersCourses
        {
            get => SelectedTeacher.CourseTeach;
            set => Set(ref _teachersCourses, value, propertyName: nameof(TeachersCourses));
        }

        public ICommand TeacherCoursesCommand { get; private set; }
        public ICommand TeacherStudentsCommand { get; private set; }
        public ICommand AddCourseCommand { get; private set; }
        public ICommand RemoveCourseCommand { get; private set; }
        public TeachersViewModel(DataService service) : base(service)
        {
            TeacherCoursesCommand = new RelayCommand(GetTeacherCourses);
            TeacherStudentsCommand = new RelayCommand(ShowStudentsTeacher);
            AddCourseCommand = new RelayCommand(AddCourseClick, CanAddExecute);
            RemoveCourseCommand = new RelayCommand(RemoveCourseClick, CanRemoveExecute);

            if (!IsInDesignMode)
                Teachers = new ObservableCollection<Teacher>(service.GetTeachers());
        }
        private void GetTeacherCourses() => TeachersCourses = SelectedTeacher.CourseTeach;
        async void ShowStudentsTeacherAsync() => await Task.Run(ShowStudentsTeacher);
        void ShowStudentsTeacher() => service.GetStudentsByTeacher(SelectedTeacher);

        void AddCourseClick()
        {
            if (SelectedTeacher != null && !SelectedTeacher.CourseTeach.HasFlag(SelectedCourse))
            {
                service.AddCourseToTeacher(SelectedTeacher, SelectedCourse);
                TeachersCourses = SelectedTeacher.CourseTeach;
            }
        }
        void RemoveCourseClick()
        {
            if (SelectedTeacher.CourseTeach.HasFlag(SelectedCourse))
            {
                service.RemoveCourseFromTeacher(SelectedTeacher, SelectedCourse);
                TeachersCourses = SelectedTeacher.CourseTeach;
            }
        }
        bool CanAddExecute() => true;
        bool CanRemoveExecute() => true;
    }
}