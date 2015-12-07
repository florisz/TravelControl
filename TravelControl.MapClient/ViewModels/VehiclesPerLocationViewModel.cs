using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelControl.MapClient.ViewModels
{
    public class VehiclesPerLocation
    {
        public int Count { get; set; }
        public string LocationId { get; set; }
        public Location Location { get; set; }
    }

    public class VehiclesPerLocationViewModel : INotifyPropertyChanged
    {
        public VehiclesPerLocationViewModel()
        {
            VehiclesPerLocation = new ObservableCollection<VehiclesPerLocation>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<VehiclesPerLocation> _vehiclesPerLocation;
        public ObservableCollection<VehiclesPerLocation> VehiclesPerLocation
        {
            get { return _vehiclesPerLocation; }
            set
            {
                _vehiclesPerLocation = value;
                OnPropertyChanged("VehiclesPerLocation");
            }
        }

    }
}
