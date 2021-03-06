﻿using System;
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
                Console.WriteLine("2. CheckIn");
                Console.WriteLine("3. CheckOut");
                Console.WriteLine("4. View all the Children CheckedIn ");
                Console.WriteLine("5. View all the Teachers CheckedIn ");
                Console.WriteLine("6. View all Children ");
                Console.WriteLine("7. View all the Teachers ");
                Console.WriteLine("8. View all the Child Activity ");
                Console.WriteLine("9. Add Child Daily Activity ");
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
                    case "6":
                        Console.WriteLine("Display All The  students");
                        var displayAllChildrenlist = ChildCare.DispalyAllChildren();
                        foreach (var d in displayAllChildrenlist)
                        {
                            Console.WriteLine($"FN:{d.FirstName} LN:{d.LastName} CN:{d.ClassName} Age:{d.Age} Id:{d.Id} Status:{d.Status}");
                        }
                        break;

                    case "7":
                        Console.WriteLine("Display All The Teachers");
                        var displayAllTeacherlist = ChildCare.DispalyAllTeachers();
                        foreach (var d in displayAllTeacherlist)
                        {
                            Console.WriteLine($"FN:{d.FirstName} LN:{d.LastName} CN:{d.ClassName} Age:{d.Age} Id:{d.Id} Status:{d.Status}");
                        }
                        break;

                    case "8":
                        Console.WriteLine("Enter the child id");
                        int childId = Convert.ToInt32(Console.ReadLine());
                        var activity = ChildCare.GetAllActivitiesById(childId);
                        foreach (var d in activity)
                        {
                            Console.WriteLine($"FN:{d.ActivityDate} LN:{d.ActivityType} CN:{d.Description} Age:{d.Id} ");
                        }
                        break;

                    case "9":
                        Console.WriteLine("Enter the child id");
                        childId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Activity");
                        var activityname= Convert.ToString(Console.ReadLine());
                        var dayactivity = ChildCare.DailyActivity(childId, activityname);
                        break;


                }



            }
        }
    }
}
