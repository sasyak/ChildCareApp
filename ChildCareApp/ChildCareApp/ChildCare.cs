using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChildCareApp
{
    public class ChildCare
    {

       private static List <Person> peoplelist = new List<Person>();
        public static Person CreatePerson(string firstName,string lastName,string className,TypeofPerson person)
        {
            var createchild = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                ClassName = className,
                PersonType=person
            };
            if (person == TypeofPerson.Child)
            {
                createchild.Age = 5;
            }
            
            peoplelist.Add(createchild);

            return createchild;


        }

        public static Person DailyCheckIn(int Id)
        {
            var person = peoplelist.SingleOrDefault(p => p.Id == Id);
            if (person == null)
            {
                return null;
            }

            person.Checkin(Id);
            return person;
        }

        public static Person DailyCheckOut(int Id)
        {
            var person = peoplelist.SingleOrDefault(p => p.Id == Id);
            if (person == null)
            {
                return null;
            }

            person.Checkout(Id);
            return person;
        }

        
        public static List<Person> DispalyAllCheckedInChildren()
        {
            return peoplelist.FindAll(p => p.PersonType==TypeofPerson.Child && p.Status);

        }

        public static IEnumerable<Person> DispalyAllChildren()
        {
            return peoplelist.FindAll(p => p.PersonType == TypeofPerson.Child);

        }

        public static IEnumerable<Person> DispalyAllCheckedInTeachers()
        {
            return peoplelist.FindAll(p => p.PersonType==TypeofPerson.Teacher && p.Status);

        }

        public static IEnumerable<Person> DispalyAllTeachers()
        {
            return peoplelist.FindAll(p => p.PersonType == TypeofPerson.Teacher);

        }
    }
}
