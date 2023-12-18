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
        private List<Booking> listOfProcedures;
        private Procedure.Name specialization;

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

        public List<Booking> ListOfProcedures
        {
            get { return listOfProcedures; }
            set
            {
                listOfProcedures = value;
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
        }

        public bool IsValidName(string input)
        {
            return Regex.IsMatch(input, "^[А-ЩЬЮЯЇІЄҐа-щьюяїієґ]+$");
        }

        public decimal CalculateMonthSalary(DateTime month, ref int salary)
        {
            decimal bonuses = 0;

            if (ListOfProcedures != null)
            {
                foreach (var booking in ListOfProcedures)
                {
                    bonuses += booking.Procedure.Price * 0.1m;
                }
            }

            salary += (int)bonuses;

            return bonuses;
        }


        public void AddProcedure(Booking booking)
        {
            ListOfProcedures.Add(booking);
        }

        public void RemoveProcedure(Booking booking)
        {
            ListOfProcedures.Remove(booking);
        }

        public void ClearProcedures()
        {
            ListOfProcedures.Clear();
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Ім'я майстра: {FirstName}");
            Console.WriteLine($"Вік майстра: {Age}");
            Console.WriteLine($"Заробітна плата майстра: {Salary}");
            Console.WriteLine($"Спеціалізація: {Specialization}");
            Console.WriteLine("Список запланованих процедур:");
            if (ListOfProcedures != null)
            {
                foreach (var booking in ListOfProcedures)
                {
                    Console.WriteLine(booking);
                }
            }
            else Console.WriteLine("У клієнта немає запланованих процедур");
        }
    }
}
