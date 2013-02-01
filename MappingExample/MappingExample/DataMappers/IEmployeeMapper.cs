using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MappingExample.Model;

namespace MappingExample.DataMappers

{
    /// <summary>
    /// Defines the contract for the Employee Data mapper class
    /// </summary>
    public interface IEmployeeMapper
    {
        /// <summary>
        /// Gets the Employee, for the specified Id.
        /// </summary>
        /// <param name="id">The Id of the employee</param>
        /// <returns>The Employee object</returns>
        Employee GetById(int id);

        /// <summary>
        /// Gets all Hourly Paid employees
        /// </summary>
        /// <returns>A list of hourly paid employees</returns>
        List<Employee> GetAllHourlyPaid();

        /// <summary>
        /// Store an Hourly Paid employee in the underlying database
        /// </summary>
        /// <param name="employee">The Hourly Paid Employee</param>
        /// <returns>The Identity of the employee just added.</returns>
        int StoreHourlyPaid(HourlyPaidEmployee employee);

    }
}
