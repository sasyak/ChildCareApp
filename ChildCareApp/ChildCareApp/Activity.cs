using System;
using System.Collections.Generic;
using System.Text;

namespace ChildCareApp
{
    public enum TypeOfActivity
    {
        CheckInOut,
        DayWork
    }
    public class Activity
    {
           public int ActivityId { get; set; }
            public DateTime ActivityDate { get; set; }
            public string Description { get; set; }
            public TypeOfActivity ActivityType { get; set; }
            public int Id { get; set; }
            public Person Person { get; set; }
        }
    }
