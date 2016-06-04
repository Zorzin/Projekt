using System.ComponentModel;
using System.Runtime.CompilerServices;
using Projekt.Annotations;

namespace Projekt
{
    internal class BusStop:INotifyPropertyChanged
    {
        private int _id;

        public int Id
        {
            get { return _id; }    
            set { _id = value; OnPropertyChanged("Id"); }
        }

        public string Name { get; set; }
        public int Area { get; set; }
        public BusStop(int id, string name, int area)
        {
            Name = name;
            Area = area;
            _id = id;
        }

        public BusStop()
        {
            Id = -1;
            Name = null;
            Area = -1;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                new PropertyChangedEventArgs(property));
        }
    }
}