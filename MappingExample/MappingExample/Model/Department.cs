using System.Collections.Generic;

namespace MappingExample.Model
{
    /// <summary>
    /// represents a department
    /// </summary>
    class Department
    {
        // INSTANCE VARIABLES
        private string departmentName;
        private List<Employee> employees;

        /// <summary>
        /// the department name
        /// </summary>
        public string DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }
        
        /// <summary>
        /// the employees
        /// </summary>
        public List<Employee> Employees
        {
            get { return employees; }
        }

        // CONSTRUCTOR

        /// <summary>
        /// constructor for department 
        /// </summary>
        public Department()
        {
            employees = new List<Employee>();
        }

        // METHODS

        public void AddEmployee(Employee newEmployee)
        {
            employees.Add(newEmployee);
        }
    }
}
