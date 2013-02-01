
namespace MappingExample.Model
{
    /// <summary>
    /// enumeration of possible pay rates
    /// </summary>
    public enum PayRate
    {
        Day,
        Weekend,
        Holiday
    }
    
    /// <summary>
    /// represents an employee 
    /// </summary>
    public abstract class Employee
    {
        //CONSTANTS
        protected const string EMAIL_SUFFIX = "@example.com";

        //INSTANCE VARIABLES
        protected int employeeId;
        protected string name;
        protected string username;
        private Address address;
        protected string phoneNumber;
        private Employee supervisor;


        //PROPERTIES

        /// <summary>
        /// the employee id number
        /// </summary>
        public int EmployeeId
        {
            get { return employeeId; }
        }

        /// <summary>
        /// the name of the employee
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// the username of the employee
        /// </summary>
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        /// <summary>
        /// the address of the employee
        /// </summary>
        public Address Address
        {
            get { return address; }
            set { address = value; }
        }

        /// <summary>
        /// the phone number of the employee
        /// </summary>
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        /// <summary>
        /// the employee's supervisor
        /// </summary>
        public Employee Supervisor
        {
            get { return supervisor; }
            set { supervisor = value; }
        }

        //CONSTRUCTORS

        /// <summary>
        /// constructor for Employee base class
        /// </summary>
        /// <param name="employeeId">the employee's id number</param>
        /// <param name="name">the employee's name</param>
        /// <param name="username">the employee's username</param>
        /// <param name="phoneNumber">the employee's phone number</param>
        public Employee(int employeeId, string name, string username, Address address,
            string phoneNumber)
        {
            this.employeeId = employeeId;
            this.name = name;
            this.username = username;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }

        /// <summary>
        /// default constructor
        /// </summary>
        public Employee()
        {
            this.employeeId = -1;
            this.name = "default";
            this.username = "default";
            this.address = null;
            this.phoneNumber = null;
        }

        //METHODS

        /// <summary>
        /// the email address of the employee
        /// </summary>
        public virtual string Email()
        {
            return username + "@example.com"; 
        }

    }
}
