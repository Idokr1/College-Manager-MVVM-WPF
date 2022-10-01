using Exercise.Models;
using Exercise.Services;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Exercise.ViewModel
{
    public class StudentsViewModel : MainViewModel
    {
        public ObservableCollection<Student> Students { get; set; }
        public Student SelectedStudent { get; set; } = new Student();

        public ICommand ChangeGradeCommand { get; private set; }

        public StudentsViewModel(DataService service) : base(service)
        {
            ChangeGradeCommand = new RelayCommand(ChangeGradeClick);
            service.StudentsByTeacher += UpdateStudents;

            if (!IsInDesignMode)
                Students = new ObservableCollection<Student>(service.GetStudents());
        }

        void ChangeGradeClick()
        {
            service.ChangeStudentGrade(SelectedStudent, SelectedStudent.Grade);

        }

        void UpdateStudents(Teacher teacher)
        {
            Students?.Clear();
            teacher.Students.ToList().ForEach(student => Students.Add(student));
        }
    }
}