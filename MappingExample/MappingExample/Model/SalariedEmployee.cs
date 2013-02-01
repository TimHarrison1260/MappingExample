

namespace MappingExample.Model
{
    /// <summary>
    /// represents a salaried employee
    /// </summary>
    public class SalariedEmployee : Employee
    {
        // CONSTANTS

        private const int MAXGRADE = 10;
        
        // INSTANCE VARIABLES

        private int payGrade;

        // PROPERTIES

        /// <summary>
        /// the employee's pay grade
        /// </summary>
        public int PayGrade
        {
          get { return payGrade; }
          set { payGrade = value; }
        }

        //CONSTRUCTORS

        /// <summary>
        /// constructor for SalariedEmployee 
        /// </summary>
        /// <param name="employeeId">the employee's id number</param>
        /// <param name="name">the employee's name</param>
        /// <param name="username">the employee's username</param>
        /// <param name="location">the employee's initila location</param>
        /// <param name="phoneNumber">the employee's phone number</param>
        public SalariedEmployee(int employeeId, string name, 
            string username, Address address, string phoneNumber, 
            int payGrade) : 
            base(employeeId, name, username, address, phoneNumber)
        {
            if (payGrade >= 0 && payGrade <= MAXGRADE)
            {
                this.payGrade = payGrade;
            }
        }

        /// <summary>
        /// default constructor
        /// </summary>
        public SalariedEmployee() : base()
        {
            this.payGrade = 0;
        }

        // METHODS

        /// <summary>
        /// increment the pay grade
        /// </summary>
        public int PayIncrement()
        {
            if (this.payGrade < MAXGRADE)
            {
                this.payGrade++;
            }
            return this.payGrade;
        }
    }
}
