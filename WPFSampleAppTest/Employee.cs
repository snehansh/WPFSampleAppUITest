using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid
{
    public class Employee : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private bool _wasReelected;
        public bool WasReelected
        {
            get { return _wasReelected; }
            set
            {
                _wasReelected = value;
                OnPropertyChanged();
            }
        }

        private Party _affiliation;
        public Party Affiliation
        {
            get { return _affiliation; }
            set
            {
                _affiliation = value;
                OnPropertyChanged();
            }
        }

        public static ObservableCollection<Employee> GetEmployees()
        {
            return new ObservableCollection<Employee>()
            {
                new Employee() {
                    Name ="Washington",
                    Title ="President 1",
                    WasReelected=true,
                    Affiliation=Party.Independent
                },
                new Employee()
                {
                    Name="Adams",
                    Title="President 2",
                    WasReelected=false,
                    Affiliation=Party.Federalist
                },
                new Employee()
                {
                    Name="Jefferson",
                    Title="President 3",
                    WasReelected=true,
                    Affiliation=Party.DemocratRepublican
                },
                new Employee()
                {
                    Name="Madison",
                    Title="President 4",
                    WasReelected=true,
                    Affiliation=Party.DemocratRepublican
                },
                new Employee()
                {
                    Name="Monroe",
                    Title="President 5",
                    WasReelected=true,
                    Affiliation=Party.DemocratRepublican
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }
    }

    public enum Party
    {
        Independent,
        Federalist,
        DemocratRepublican,
    }
}
