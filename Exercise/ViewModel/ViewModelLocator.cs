using CommonServiceLocator;
using Exercise.Services;
using GalaSoft.MvvmLight.Ioc;

namespace Exercise.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<DataService>(true);
            SimpleIoc.Default.Register<MainViewModel>();            
            SimpleIoc.Default.Register<TeachersViewModel>();
            SimpleIoc.Default.Register<StudentsViewModel>();

        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public TeachersViewModel Teachers => ServiceLocator.Current.GetInstance<TeachersViewModel>();
        public StudentsViewModel Students => ServiceLocator.Current.GetInstance<StudentsViewModel>();

    }
}