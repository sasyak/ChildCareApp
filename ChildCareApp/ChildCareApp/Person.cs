namespace ChildCareApp
{
    public enum TypeofPerson
    {
        Child,
        Teacher
    }
    public class Person
    {
        private static int lastId = 0;
        /// <summary>
        /// This is the child class where you define children details
        /// </summary>
        #region
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public string ClassName { get; set; }
        public bool Status { get; set; }
        public string DayWorkdetails { get; set; }
        public TypeofPerson PersonType { get; set; }
        #endregion
        #region Constructor
        public Person()
            {
           }
        #endregion

        #region methods

        public void Checkin(int Id)
        {
            Status = true;
        }
        public void Checkout(int Id)
        {
            Status = false;
        }

        #endregion
    }
}

