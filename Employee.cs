using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Tra_Sua
{

    public class Employee : INotifyPropertyChanged
    {
        private string _employeeId;
        public string EmployeeId
        {
         
                get { return _employeeId; }
                set
        {
                    _employeeId = value;
                    OnPropertyChanged(nameof(EmployeeId));
                }
            }
        

        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
