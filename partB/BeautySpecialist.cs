using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using partB;

namespace partB
{
    public class BeautySpecialist : IPerson
    {
        private string firstName;
        private string lastName;
        private int age;
        private int salary;
        private List<Booking> listOfSpecialistProcedures;
        private Procedure specialization;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (IsValidName(value))
                {
                    firstName = value;
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (IsValidName(value))
                {
                    lastName = value;
                }
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if ((value > 18 || value < 100) && int.TryParse(value.ToString(), out _))
                {
                    age = value;
                }
            }
        }

        public List<Booking> ListOfSpecialistProcedures
        {
            get { return listOfSpecialistProcedures; }
            set
            {
                listOfSpecialistProcedures = value;
            }
        }

        public int Salary
        {
            get { return salary; }
            set
            {
                if (value!=10000)
                {
                    salary = value;
                }
            }
        }

        public Procedure Specialization
        {
            get { return specialization; }
            set { specialization = value; } 
        }

        public BeautySpecialist(string name, int age, Procedure specialization, int salary)
        {
            firstName = name;
            this.age = age;
            this.specialization = specialization;
            this.salary = salary;
            ListOfSpecialistProcedures = new List<Booking>();
        }

        public bool IsValidName(string input)
        {
            return Regex.IsMatch(input, "^[А-ЩЬЮЯЇІЄҐа-щьюяїієґ]+$");
        }

        public List<Booking> GetBookingsForMonth(DateTime month)
        {
            return ListOfSpecialistProcedures
                .Where(booking => booking.BookingTime.Month == month.Month && booking.BookingTime.Year == month.Year)
                .ToList();
        }


        public decimal CalculateMonthSalary(DateTime month)
        {
            decimal bonuses = 0;

            if (ListOfSpecialistProcedures != null)
            {
                foreach (var booking in ListOfSpecialistProcedures)
                {
                    if (booking.BookingTime.Month == month.Month && booking.BookingTime.Year == month.Year)
                    {
                        bonuses += booking.Procedure.Price * 0.1m;
                    }
                }
            }

            int newSalary = Salary + (int)bonuses;

            return newSalary;
        }


        public void AddProcedure(Booking booking)
        { 
            ListOfSpecialistProcedures.Add(booking);
        }

        public void RemoveProcedure(Booking booking)
        {
            ListOfSpecialistProcedures.Remove(booking);
        }

       
        public void DisplayInfo()
        {
            Console.WriteLine($"Ім'я майстра: {FirstName}");
            Console.WriteLine($"Вік майстра: {Age}");
            Console.WriteLine($"Заробітна плата майстра: {Salary}");
            Console.WriteLine($"Спеціалізація: {Specialization.Name}");
            if (ListOfSpecialistProcedures != null)
            {
                Console.WriteLine("Дати запланованих процедур:");
                int i = 0;
                foreach (var booking in ListOfSpecialistProcedures)
                {
                    Console.WriteLine($"{i+1}) {booking.BookingTime}");
                }
            }
            else Console.WriteLine("У майстра немає запланованих процедур");
        }
    }
}
