using Exercise.Services;
using GalaSoft.MvvmLight;
using System.Collections.Specialized;

namespace Exercise.ViewModel
{
    public class MainViewModel : ViewModelBase, INotifyCollectionChanged
    {
        protected readonly DataService service;


        public MainViewModel(DataService service)
        {
            this.service = service;
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public virtual void RaiseCollectionChanged(NotifyCollectionChangedEventArgs e) => CollectionChanged?.Invoke(this, e);
    }
}