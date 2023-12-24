using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace partB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Procedure> procedures;
            List<BeautySpecialist> specialists;
            List<Client> clients = new List<Client>();
            Client client = new Client("", 0);

            InitializeProcedures(out procedures);
            InitializeSpecialists(procedures, out specialists);
            AddSpecialistToProced(procedures, specialists);
           

            while (true)
            {
                Console.WriteLine("Меню:\n 0. Вихід \n 1. Клієнт\n 2. Майстер\n 3. Список процедур\n 4. Запис\nОберіть опцію:");
                int choice = int.Parse(Console.ReadLine());
                
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Роботу програми завершено");
                        Environment.Exit(0);

                        break;

                    case 1:
                        Console.WriteLine("1) Додати\n2) Видалити\n3) Переглянути інформацію про клієнтів\n");
                        int choice1 = int.Parse(Console.ReadLine());
                        MethodForClient(choice1, ref client, ref clients);

                        break;

                    case 2:
                        Console.WriteLine("1) Переглянути інформацію \n2) Порахувати заробітну плату");
                        int choice2 = int.Parse(Console.ReadLine());
                        if (choice2 == 1)
                        {
                            Console.WriteLine("Інформація про майстрів:");
                            foreach(var sp in specialists)
                            {
                                sp.DisplayInfo();
                                Console.Write("\n\n");
                            }
                        }
                        else if (choice2 == 2)
                        {
                            Console.WriteLine("Оберіть майстра зі списку:");
                            int v = -1;
                            foreach (var sp in specialists)
                            {
                                Console.WriteLine($"{v += 1}) {sp.FirstName}");
                            }
                            int choice3 = int.Parse(Console.ReadLine());

                            if (choice3 >= 0 && choice3 < specialists.Count)
                            {
                                Console.WriteLine("Введіть рік:");
                                int selectedYear = int.Parse(Console.ReadLine());

                                Console.WriteLine("Введіть місяць (число від 1 до 12):");
                                int selectedMonth = int.Parse(Console.ReadLine());

                                if (selectedMonth >= 1 && selectedMonth <= 12)
                                {
                                    DateTime selectedDate = new DateTime(selectedYear, selectedMonth, 1);

                                    List<Booking> bookingsForMonth = specialists[choice3].GetBookingsForMonth(selectedDate);

                                    if (bookingsForMonth.Any())
                                    {
                                        decimal newSalary = specialists[choice3].CalculateMonthSalary(selectedDate);

                                        Console.WriteLine($"Заробітна плата майстра {specialists[choice3].FirstName} за {selectedDate.ToString("MMMM yyyy")}: {newSalary} грн");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Для майстра {specialists[choice3].FirstName} в обраному місяці записів немає, заробітна плата залишається незмінною.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Обрано некоректний місяць");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Обрано некоректного майстра");
                            }
                        }

                        else Console.WriteLine("Обрано некоректну опцію");

                        break;

                    case 3:
                        foreach (var proced in procedures)
                        {
                            proced.PrintToDisplay();
                            Console.Write("\n");
                        }

                        break;

                    case 4:
                        
                        if (clients.Count != 0)
                        {
                            Console.WriteLine("1) Додати \n2) Видалити");
                            int choice4 = int.Parse(Console.ReadLine());

                            if (choice4 == 1)
                            {
                                Console.WriteLine("Оберіть процедуру:");
                                int i = -1;
                                foreach (var proced in procedures)
                                {
                                    Console.Write($"{i += 1} ");
                                    Console.WriteLine(proced.Name);
                                }
                                int obranaProced = int.Parse(Console.ReadLine());

                                Booking booking = new Booking(procedures[obranaProced], procedures[obranaProced].Specialist);
                                do
                                {
                                    Console.Write("Введіть дату та час в форматі YYYY-MM-DD hh:mm: ");
                                    string inputDate = Console.ReadLine();

                                    try
                                    {
                                        booking.BookingTime = DateTime.ParseExact(inputDate, "yyyy-MM-dd HH:mm", null);
                                        break;
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Неправильний формат вводу. Спробуйте ще раз.");
                                    }
                                } while (true);


                                specialists[obranaProced].AddProcedure(booking);

                                int k = -1;
                                foreach (var cl in clients)
                                {
                                    Console.WriteLine($" {k += 1} - {cl.FirstName}");
                                }

                                Console.WriteLine("Оберіть клієнта:");
                                int selectedClientName = int.Parse(Console.ReadLine());

                                clients[selectedClientName].AddProcedure(booking);
                                
                            }
                            else if (choice4 == 2)
                            {
                                client.RemoveProcedure();
                            }
                        }
                        else Console.WriteLine("В базі немає клієнтів");

                        break;
                }
            }
        }

        public static void InitializeProcedures(out List<Procedure> procedures)
        {
            //Створюємо список процедур в салоні
            procedures = new List<Procedure>();
            Procedure procedure1 = new Procedure(ProcedureTypes.HairCut, 200, TimeSpan.FromMinutes(10));
            procedures.Add(procedure1);
            Procedure procedure2 = new Procedure(ProcedureTypes.HairColoring, 800, TimeSpan.FromHours(3));
            procedures.Add(procedure2);
            Procedure procedure3 = new Procedure(ProcedureTypes.Manicure, 700, TimeSpan.FromHours(2));
            procedures.Add(procedure3);
            Procedure procedure4 = new Procedure(ProcedureTypes.Pedicure, 600, TimeSpan.FromHours(1));
            procedures.Add(procedure4);
            Procedure procedure5 = new Procedure(ProcedureTypes.MakeUp, 500, TimeSpan.FromMinutes(90));
            procedures.Add(procedure5);
            Procedure procedure6 = new Procedure(ProcedureTypes.LipsInjection, 6000, TimeSpan.FromMinutes(40));
            procedures.Add(procedure6);
            Procedure procedure7 = new Procedure(ProcedureTypes.Lashes, 1000, TimeSpan.FromHours(4));
            procedures.Add(procedure7);
            Procedure procedure8 = new Procedure(ProcedureTypes.BrowDye, 350, TimeSpan.FromMinutes(30));
            procedures.Add(procedure8);
            Procedure procedure9 = new Procedure(ProcedureTypes.BrowTattoo, 5000, TimeSpan.FromMinutes(50));
            procedures.Add(procedure9);
        }
         
        public static void InitializeSpecialists(List<Procedure> procedures, out List<BeautySpecialist> specialists)
        {
            specialists = new List<BeautySpecialist>();
            BeautySpecialist specialist1 = new BeautySpecialist("Анастасія", 33, procedures[0], 10000);
            specialists.Add(specialist1);
            BeautySpecialist specialist2 = new BeautySpecialist("Діана", 30, procedures[1], 10000);
            specialists.Add(specialist2);
            BeautySpecialist specialist3 = new BeautySpecialist("Марина", 18, procedures[2], 10000);
            specialists.Add(specialist3);
            BeautySpecialist specialist4 = new BeautySpecialist("Ксенія", 20, procedures[3], 10000);
            specialists.Add(specialist4);
            BeautySpecialist specialist5 = new BeautySpecialist("Олена", 25, procedures[4], 10000);
            specialists.Add(specialist5);
            BeautySpecialist specialist6 = new BeautySpecialist("Вікторія", 26, procedures[5], 10000);
            specialists.Add(specialist6);
            BeautySpecialist specialist7 = new BeautySpecialist("Поліна", 31, procedures[6], 10000);
            specialists.Add(specialist7);
            BeautySpecialist specialist8 = new BeautySpecialist("Марія", 22, procedures[7], 10000);
            specialists.Add(specialist8);
            BeautySpecialist specialist9 = new BeautySpecialist("Ганна", 29, procedures[8], 10000);
            specialists.Add(specialist9);
        }

        public static void AddSpecialistToProced(List<Procedure> procedures, List<BeautySpecialist> specialists)
        {
            procedures[0].Specialist = specialists[0];
            procedures[1].Specialist = specialists[1];
            procedures[2].Specialist = specialists[2];
            procedures[3].Specialist = specialists[3];
            procedures[4].Specialist = specialists[4];
            procedures[5].Specialist = specialists[5];
            procedures[6].Specialist = specialists[6];
            procedures[7].Specialist = specialists[7];
            procedures[8].Specialist = specialists[8];
        }


        public static void MethodForClient(int choice, ref Client client, ref List<Client> clients)
        {
            if (choice == 1)
            {
                do
                {
                    Console.Write("Введіть ім'я клієнта: ");
                    client.FirstName = Console.ReadLine();

                } while (string.IsNullOrEmpty(client.FirstName));

                do
                {
                    Console.Write("Введіть вік клієнта: ");
                    client.Age = int.Parse(Console.ReadLine());

                } while (client.Age == 0);

                client = new Client(client.FirstName, client.Age);
                clients.Add(client);
                Console.WriteLine("Клієнта додано");
            }
            else if (choice == 2)
            {
                clients.Remove(client);
                clients[clients.Count - 1].ClearProcedures();
            }
            else if (choice == 3)
            { 
                if (clients.Count !=0)
                {
                    Console.WriteLine("Інформація про клієнтів:");
                    foreach (var cl in clients)
                    {
                        cl.DisplayInfo();
                        Console.WriteLine("\n");
                    }
                }
                else Console.WriteLine("В базі немає жодного клієнта\n");
            }
            else Console.WriteLine("Обрано некоректну опцію\n");
        }

    }
}
