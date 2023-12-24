using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace partB
{
    public class Procedure : IPrint
    {
        private int price;
        private ProcedureTypes name;
        private TimeSpan duration;
        private BeautySpecialist specialist;

        public BeautySpecialist Specialist
        {
            get { return specialist; }
            set { specialist = value; }
        }

        public int Price
        {
            get { return price; }
            set
            {
                if(int.TryParse(value.ToString(), out _))
                {
                    price = value;
                }
            }
        }
        public ProcedureTypes Name
        {
            get { return name; }
            set
            {
                //перевірка, що Name знаходиться в мкжах перерахування ProcedureTypes
                if (Enum.IsDefined(typeof(ProcedureTypes), value))
                {
                    name = value;
                }
            }
        }

        public TimeSpan Duration
        {
            get { return duration; }
            set
            {
                if (value >= TimeSpan.Zero && value <= TimeSpan.FromHours(24))
                {
                    duration = value;
                }
            }
        }

        public Procedure(ProcedureTypes name, int price, TimeSpan duration) 
        {
            this.name = name;
            this.price = price;
            this.duration = duration;
        }

        public void PrintToDisplay()
        {
            Console.WriteLine($"Назва процедури: {Name}");
            Console.WriteLine($"Ціна: {Price}");
            Console.WriteLine($"Тривалість: {Duration}");
            Console.WriteLine($"Хто буде робити процедуру: {Specialist.FirstName}");
        }

    } 
}
