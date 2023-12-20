using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace partB
{
    public class Booking : IPrint
    {
        private BeautySpecialist beautySpecialist;
        private Client client;
        private DateTime bookingTime;
        private Procedure procedure;

        public BeautySpecialist BeautySpecialist
        {
            get { return beautySpecialist; }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Помилка: Не вказано майстра.");
                }
                else
                {
                    beautySpecialist = value;
                }
            }
        }

        public Client Client
        {
            get { return client; }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Помилка: Не вказано клієнта.");
                }
                else
                {
                    client = value;
                }
            }
        }

        public DateTime BookingTime
        {
            get { return bookingTime; }
            set
            {
                if (value < DateTime.Now)
                {
                    Console.WriteLine("Помилка: Невірна дата та час запису.");
                }
                else
                {
                    bookingTime = value;
                }
            }
        }

        public Procedure Procedure
        {
            get { return procedure; }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Помилка: Не вказана процедура.");
                }
                else
                {
                    procedure = value;
                }
            }
        }

        public Booking(Client client, Procedure procedure, DateTime bookingTime, BeautySpecialist beautySpecialist)
        {
            this.client = client;
            this.procedure = procedure; 
            this.bookingTime = bookingTime;
            this.procedure = procedure;
        }

        public void PrintToDisplay()
        {
            Console.WriteLine("Деталі запису:");
            Console.WriteLine($"Клієнт: {Client.FirstName}");
            Console.WriteLine($"Майстер: {BeautySpecialist.FirstName}");
            Console.WriteLine($"Процедура: {Procedure.Name}");
            Console.WriteLine($"Дата та час: {BookingTime}");
        }
    }
}
