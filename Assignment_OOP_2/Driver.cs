using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_OOP_2
{
    public class Driver
    {
        


        public int DriverID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public Driver(int driverID, string fullName, string phoneNumber)
        {
            DriverID = driverID;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }
    }
}   
