using Exercise.Models;
using System.Windows;

namespace Exercise
{
    public partial class MainWindow : Window
    {
        readonly Model1Container data = new Model1Container();
        public MainWindow()
        {
            InitializeComponent();

            ////uncomment and run the program to add some data to the DB then comment it again

            //var t1 = new Teacher { Name = "Teacher1", CourseTeach = CourseType.Java | CourseType.JavaScript };
            //var t2 = new Teacher { Name = "Teacher2", CourseTeach = CourseType.Kotlin | CourseType.C_Sharp };
            //var t3 = new Teacher { Name = "Teacher3", CourseTeach = CourseType.C_Sharp | CourseType.JavaScript | CourseType.HTML };
            //var t4 = new Teacher { Name = "Teacher4", CourseTeach = CourseType.Python | CourseType.Java };
            //var s1 = new Student { Name = "Student1", Grade = 87 };
            //var s2 = new Student { Name = "Student2", Grade = 81 };
            //var s3 = new Student { Name = "Student3", Grade = 53 };
            //var s4 = new Student { Name = "Student4", Grade = 90 };
            //var s5 = new Student { Name = "Student5", Grade = 72 };
            //t1.Students.Add(s1);
            //t1.Students.Add(s3);
            //t2.Students.Add(s1);
            //t2.Students.Add(s2);
            //t3.Students.Add(s3);
            //t3.Students.Add(s4);
            //t3.Students.Add(s2);
            //t4.Students.Add(s2);
            //t4.Students.Add(s5);
            //data.People.Add(t1);
            //data.People.Add(t2);
            //data.People.Add(t3);
            //data.People.Add(t4);
            //data.People.Add(s1);
            //data.People.Add(s2);
            //data.People.Add(s3);
            //data.People.Add(s4);
            //data.People.Add(s5);
            //data.SaveChanges();

        }
    }
}
