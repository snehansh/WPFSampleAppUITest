using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSampleAppTest
{
    public class NumberHolder : INotifyPropertyChanged
    {
        private int number = 0;

        public int Number
        {
            get { return number; }
            set
            {
                number = value;
                FirePropertyChanged("Number");
            }
        }

        private void FirePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
