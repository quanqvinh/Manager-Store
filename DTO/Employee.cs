using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public bool Male { get; set; }
        public string PhoneNumber { get; set; }
        public int WorkDays { get; set; }
        public double DailyWage { get; set; }
        public double MonthSalary { get; set; }
        public string Password { get; set; } 
        public string Role { get; set; }
        public bool StillWork { get; set; }
        public string UrlImage { get; set; }

        public Employee(int id, string name, DateTime birthday, string address, bool male, string phoneNumber, int workdays,
            double dailyWage, double monthSalary, string password, string role, bool stillWork, string urlImage)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
            Address = address;
            Male = male;
            PhoneNumber = phoneNumber;
            WorkDays = workdays;
            DailyWage = dailyWage;
            MonthSalary = monthSalary;
            Password = password;
            Role = role;
            StillWork = stillWork;
            UrlImage = urlImage;
        }
    }
}
