using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace partB
{
    public class Client : IPerson
    {
        private string firstName;
        private string lastName;
        private int age;
        private List<Booking> listOfBooking;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (IsValidName(value))
                {
                    firstName = value;
                }
                else
                {
                    Console.WriteLine("Ім'я повинно містити тільки українські букви!");
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
                else
                {
                    Console.WriteLine("Прізвище повинно містити тільки українські букви!");
                }
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 14 || value > 100)
                {
                    Console.WriteLine("Вік має бути більше 14-ти років");
                }
                else if (int.TryParse(value.ToString(), out _))
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("Можна вводити тільки числа");
                }
            }
        }

        public List<Booking> ListOfBooking
        {
            get { return listOfBooking; }
            set
            {
                listOfBooking = value;
            }
        }

        public Client(string name, int age)
        {
            firstName = name;
            this.age = age;
            listOfBooking = new List<Booking>();
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Ім'я клієнта: {FirstName}");
            Console.WriteLine($"Вік клієнта: {Age}");
            Console.WriteLine("Список запланованих процедур:");
            if (ListOfBooking.Count > 0)
            {
                foreach (var booking in ListOfBooking)
                {
                    Console.WriteLine($"Назва: {booking.Procedure.Name}");
                    Console.WriteLine($"Дата та час: {booking.BookingTime}");
                }
            }
            else Console.WriteLine("У клієнта немає запланованих процедур");

        }

        public void AddProcedure(Booking booking)
        {
            ListOfBooking.Add(booking);
        }

        public void RemoveProcedure()
        {
            ListOfBooking.Remove(ListOfBooking[ListOfBooking.Count-1]);
        }

        public void ClearProcedures()
        {
            ListOfBooking.Clear();
        }

        public bool IsValidName(string input)
        {
            return Regex.IsMatch(input, "^[А-ЩЬЮЯЇІЄҐа-щьюяїієґ]+$");
        }

    }
}
