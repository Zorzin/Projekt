using System;
using System.ComponentModel;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Windows.Forms.VisualStyles;
using Projekt.Annotations;

namespace Projekt
{
    internal class BusStop:INotifyPropertyChanged, IDataErrorInfo
    {
        private static DbConnect dbConnect = new DbConnect();
        private int _id;
        private string _name;

        public int Id
        {
            get { return _id; }    
            set { _id = value; OnPropertyChanged("Id"); }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value !=null)
                {
                    dbConnect.UpdateFromString("update projekt.busstop set busstopname='" + value + "' where idbusstop=" + Id + ";");
                }
                _name = value;
            }
        }

        public override string ToString()
        {
            return Id.ToString()+ ": " + Name;
        }

        public string BusStopShow
        {
            get { return ToString(); }
        }

        public BusStop(int id, string name)
        {
            Name = name;
            _id = id;
        }

        public BusStop()
        {
            Id = 0;
            Name = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                new PropertyChangedEventArgs(property));
        }

        public string this [string columnName]
        {
            get
            {
                switch (columnName)
                {
                    
                    case "Id":
                        if (Id.ToString().Length<1)
                        {
                            return "id can't be empty";
                        }
                        if(Id<1)
                        {
                            return "id can't be smaller than 1";
                        }
                        break;
                    case "Name":
                        if (string.IsNullOrEmpty(Name))
                        {
                            Name = "nazwa";
                            return "name can't be empty";
                        }
                        break;
                    default:
                        break;
                }
                return null;
            }
        }

        public string Error { get { return null; } }
    }
}