using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChildCareApp
{
    public class ChildCare
    {
       private static ChildCareContext db = new ChildCareContext();   
       // private static List <Person> peoplelist = new List<Person>();
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

            db.Persons.Add(createchild);
            db.SaveChanges();
            
            return createchild;
        }

        public static Person DailyCheckIn(int Id)
        {
            var person = db.Persons.SingleOrDefault(p => p.Id == Id);
            if (person == null)
            {
                return null;
            }

            person.Checkin(Id);
            db.SaveChanges();
            createActivities(person.Id, TypeOfActivity.CheckInOut, "CheckIn");
            return person;

        }

        public static Person DailyCheckOut(int Id)
        {
            var person = db.Persons.SingleOrDefault(p => p.Id == Id);
            if (person == null)
            {
                throw new Exception("Need Input as person");
            }

            person.Checkout(Id);
            db.SaveChanges();
            createActivities(person.Id, TypeOfActivity.CheckInOut, "CheckOut");
            return person;
        }

        public static Person DailyActivity(int Id, string activtyName)
        {
            var person = db.Persons.SingleOrDefault(p => p.Id == Id);
            if (person == null)
            {
                throw new Exception("Need Input as person");
            }

            person.DayWorkdetails = activtyName;
            db.SaveChanges();
            createActivities(person.Id, TypeOfActivity.DayWork, "Kids Day Activities");
            return person;
        }

        public static IEnumerable<Person> DispalyAllCheckedInChildren()
        {
            return db.Persons.Where(p => p.PersonType==TypeofPerson.Child && p.Status);

        }

        public static IEnumerable<Person> DispalyAllChildren()
        {
            return db.Persons.Where(p => p.PersonType == TypeofPerson.Child);

        }

        public static IEnumerable<Person> DispalyAllCheckedInTeachers()
        {
            return db.Persons.Where(p => p.PersonType==TypeofPerson.Teacher && p.Status);

        }

        public static IEnumerable<Person> DispalyAllTeachers()
        {
            return db.Persons.Where(p => p.PersonType == TypeofPerson.Teacher);

        }
         public static IEnumerable<Activity> GetAllActivitiesById(int Id)
       {
           return db.ChildActivity.Where(t =>t.Id == Id).OrderByDescending(t => t.ActivityDate);

       }

        public static void createActivities(int id , TypeOfActivity activityType, string description = "")
          {
                var activities = new Activity
                {
                    ActivityDate = DateTime.UtcNow,
                    Description = description,
                    Id = id,
                    ActivityType = activityType
                };
            db.ChildActivity.Add(activities);
           db.SaveChanges();

            }
        }
        }
    


