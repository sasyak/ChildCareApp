using System;
using System.Security.Cryptography.X509Certificates;

namespace ChildCareApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************************");
            Console.WriteLine("Welcome to ChildCare Center");

            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create a Child/Teacher");
                Console.WriteLine("2. Child CheckIn");
                Console.WriteLine("3. Child CheckOut");
                Console.WriteLine("4. View all the Children CheckedIn ");
                Console.WriteLine("5. View all the Teachers CheckedIn ");

                Console.WriteLine("Select Option");
                var option = Console.ReadLine();

                switch(option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting the Child Care Center");
                        return;
                    case "1":
                        Console.WriteLine("FirstName");
                            var firstName = Console.ReadLine();

                        Console.WriteLine("LastName");
                            var lastName = Console.ReadLine();

                        Console.WriteLine("ClassName");
                            var className = Console.ReadLine();

                        Console.WriteLine("Select Tyep of Person");
                        var personTypes = Enum.GetNames(typeof(TypeofPerson));
                        for (var i = 0; i < personTypes.Length; i++)
                        {
                            Console.WriteLine($"{i} {personTypes[i]}");
                        }

                        var personType = Enum.Parse < TypeofPerson > (Console.ReadLine());

                        var person = ChildCare.CreatePerson(firstName, lastName, className, personType);

                        Console.WriteLine($"FN:{person.FirstName} LN:{person.LastName} CN:{person.ClassName} Age:{person.Age} Id:{person.Id} Status:{person.Status}");
                        break;

                    case "2":

                        Console.WriteLine("Enther the Id for the CheckIn");
                        int checkinId = Convert.ToInt32(Console.ReadLine());
                        var childlist=ChildCare.DailyCheckIn(checkinId);
                        Console.WriteLine($"FN:{childlist.FirstName} LN:{childlist.LastName} CN:{childlist.ClassName} Age:{childlist.Age} Id:{childlist.Id} Status:{childlist.Status}");
                        break;

                    case "3":

                        Console.WriteLine("Enther the Id for the CheckIn");
                        int checkoutId = Convert.ToInt32(Console.ReadLine());
                        ChildCare.DailyCheckIn(checkoutId);
                        break;

                   case "4":
                        Console.WriteLine("Display All The CheckedIn students");
                        var displayClist=ChildCare.DispalyAllCheckedInChildren();
                        foreach(var d in displayClist)
                        {
                            Console.WriteLine($"FN:{d.FirstName} LN:{d.LastName} CN:{d.ClassName} Age:{d.Age} Id:{d.Id} Status:{d.Status}");
                        }
                       break;

                    case "5":
                        Console.WriteLine("Display All The CheckedIn Teachers");
                        var displayTlist=ChildCare.DispalyAllCheckedInTeachers();
                        foreach (var d in displayTlist)
                        {
                            Console.WriteLine($"FN:{d.FirstName} LN:{d.LastName} CN:{d.ClassName} Age:{d.Age} Id:{d.Id} Status:{d.Status}");
                        }
                        break;



                }



            }
        }
    }
}
