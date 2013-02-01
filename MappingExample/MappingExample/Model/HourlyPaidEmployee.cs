using System;

namespace MappingExample.Model
{
    /// <summary>
    /// represents an hourly paid employee
    /// </summary>
    public class HourlyPaidEmployee : Employee
    { 
        //CONSTRUCTORS

        /// <summary>
        /// constructor for HourlyPaidEmployee 
        /// </summary>
        /// <param name="employeeId">the employee's id number</param>
        /// <param name="name">the employee's name</param>
        /// <param name="username">the employee's username</param>
        /// <param name="phoneNumber">the employee's phone number</param>
        public HourlyPaidEmployee(int employeeId, string name, 
            string username, Address address,string phoneNumber) : 
            base(employeeId, name, username, address, phoneNumber)
        {
        }

        /// <summary>
        /// default constructor
        /// </summary>
        public HourlyPaidEmployee() : base()
        {
        }

        // METHODS

        /// <summary>
        /// the email address of the employee
        /// </summary>
        public override string Email()
        {
            return  username + "_h_" + "@example.com";
        }

        /// <summary>
        /// records an entry in a specified time sheet
        /// </summary>
        /// <param name="hours">the number of hours to record</param>
        /// <param name="payRate">payrate enumerated value</param>
        public void RecordTime( int hours, PayRate payRate)
        {
            throw new NotImplementedException();
        }
    }
}
