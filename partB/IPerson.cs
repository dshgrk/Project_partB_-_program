using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace partB
{
    public interface IPerson
    {
        string FirstName {get; set;}
        string LastName {get; set;}
        int Age {get; set; }
        void AddProcedure(Booking booking);
        void DisplayInfo();
    }
}
