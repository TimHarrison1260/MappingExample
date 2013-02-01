using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using MappingExample.Model;

namespace MappingExample.DataMappers
{
    /// <summary>
    /// Data Mapper class to managed the persistence of Employee objects in the underlying database.
    /// </summary>
    public class EmployeeMapper : IEmployeeMapper
    {
        //  Connection string for SQLCE compact database.
        const string constEmployeeConnectionString = "Data Source=\"D:\\Users\\Tim.CAULDSTANES\\Documents\\Visual Studio 2012\\Projects\\MSc\\NDbT\\MappingExample\\MappingExample\\Data\\Database.sdf\"";
//        const string constEmployeeConnectionString = "Data Source=\"D:\\Users\\Tim.CAULDSTANES\\My Documents\\Visual Studio 2012\\Projects\\MSc\\NDbT\\MappingExample\\MappingExample\\Data\\Database.sdf\"";
        
        //  The basic sql for getting an Employee.
        private const string constGetEmployeeSQL = "Select e.Id as EmployeeId, e.Name, e.UserName, e.PhoneNumber, e.SupervisorId, " +
                            "e.DeptId, e.AddressId, e.Type, e.PayGrade, d.Name as DeptName, a.PostCode, a.PropertyName, a.PropertyNumber " +
                            "From Employee e Join Department d on d.Id = e.DeptId Join Address a on a.Id = e.AddressId " +
                            "where e.Id = ";

        private const string constGetHourlyPaidEmployeesSQL = "Select e.Id as EmployeeId, e.Name, e.UserName, e.PhoneNumber, " +
                            "e.SupervisorId, e.DeptId, e.AddressId, e.Type, e.PayGrade, d.Name as DeptName, a.PostCode, a.PropertyName, " +
                            "a.PropertyNumber " +
                            "From Employee e Join Department d on d.Id = e.DeptId Join Address a on a.Id = e.AddressId " +
                            "where e.Type = 2";

        private const string constInsertAddressSQL = "Insert into Address (PropertyName, PropertyNumber, PostCode) " +
                            "Values (@PropertyName, @PropertyNumber, @PostCode)";

        private const string constInsertEmployeeSQL = "Insert into Employee (Name, UserName, PhoneNumber, SupervisorId, DeptId, AddressId, Type, PayGrade) " +
                            "Values (@Name, @UserName, @PhoneNumber, @SupervisorId, @DeptId, @AddressId, @Type, @PayGrade)";

        private const string constGetIDSQL = "Select @@IDENTITY;";

        //  Instantiate the Identity Map for the Employee.
        IdentityMap<Employee> EmployeeIdentityMap = new IdentityMap<Employee>();

        /// <summary>
        /// Gets the Employee, for the specified Id.
        /// </summary>
        /// <param name="id">The Id of the employee</param>
        /// <returns>The Employee object</returns>
        public Employee GetById(int id)
        {
            //  Check if employee is already loaded
            if (EmployeeIdentityMap.Contains(id))
                return EmployeeIdentityMap.GetById(id);

            Employee emp = null;
            string supervisorId = string.Empty;

            //  Not yet loaded, attempt to get it from the database.
            using (SqlCeConnection EmployeeSqlConn = new SqlCeConnection(constEmployeeConnectionString))
            {
                //  Set up the SQL Command
                SqlCeCommand cmd = EmployeeSqlConn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = constGetEmployeeSQL + id.ToString();

                EmployeeSqlConn.Open();
                //  Using construct to control.
                using (SqlCeDataReader reader =  cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                {
                    while (reader.Read())
                    {
                        //  build the domain model from the result of the query.
                        emp = MapTableToEmployeeClass(reader); // Would use a helper class, such as QueryTranslator.
                        //  supervisorId 
                        if (reader["SupervisorId"] != System.DBNull.Value)
                        {
                            supervisorId = reader["SupervisorId"].ToString();
                            //  Would retrieve the departmentId so that this employee can be added to the departments Employee collection.
                        }
                    }
                }
            }
            //  Check if the employee has a supervisor and retrieve if it does.
            if (supervisorId != string.Empty)
            {
                Employee supervisor = GetById(Convert.ToInt32(supervisorId));
                emp.Supervisor = supervisor;
            }

            //  Add to the IdentityMap
            EmployeeIdentityMap.Store(emp.EmployeeId, emp);
            //  Return the object
            return emp;
        }

        /// <summary>
        /// Gets all Hourly Paid employees
        /// </summary>
        /// <returns>A list of hourly paid employees</returns>
        public List<Employee> GetAllHourlyPaid()
        {
            List<Employee> employees = new List<Employee>();

            //  Not yet loaded, attempt to get it from the database.
            using (SqlCeConnection EmployeeSqlConn = new SqlCeConnection(constEmployeeConnectionString))
            {
                //  Set up the SQL Command
                SqlCeCommand cmd = EmployeeSqlConn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = constGetHourlyPaidEmployeesSQL;

                EmployeeSqlConn.Open();
                //  Using construct to control.
                using (SqlCeDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                {
                    while (reader.Read())
                    {
                        //  build the domain model from the result of the query.
                        Employee emp = MapTableToEmployeeClass(reader); // Would use a helper class, such as QueryTranslator.
                        //  supervisorId 
                        int supervisorId = 0;
                        if (reader["SupervisorId"] != System.DBNull.Value)
                        {
                            supervisorId = (int)reader["SupervisorId"];
                            //  Would retrieve the departmentId so that this employee can be added to the departments Employee collection.
                        }
                        emp.Supervisor = GetById(supervisorId);
                        //  Now add the employee to the identity map
                        EmployeeIdentityMap.Store(emp.EmployeeId, emp);
                        //  Add to the output list
                        employees.Add(emp);
                    }
                }
            }

            return employees;
        }

        /// <summary>
        /// Store an Hourly Paid employee in the underlying database
        /// </summary>
        /// <param name="employee">The Hourly Paid Employee</param>
        /// <returns>The Identity of the employee just added.</returns>
        public int StoreHourlyPaid(HourlyPaidEmployee employee)
        {
            //  Construct an Address Record, from Address and Postcode (within Address)
            int addressId = employee.EmployeeId;
            string propertyName = employee.Address.PropertyName;
            string propertyNumber = employee.Address.PropertyNumber.ToString();
            string postCode = employee.Address.PostCode.FullCode;

            //  Construct the Employee record
            string name = employee.Name;
            string userName = employee.Username;
            string phoneNumber = employee.PhoneNumber;
            int supervisor = employee.Supervisor.EmployeeId;
            int DeptId = 1;     // The sample data is not populating this.
            byte Type = 2;      //  This is the type for HourlyPaid employee.
            int? payGrade = 0;

            int newId = 0;

            using (SqlCeConnection EmployeeSqlConn = new SqlCeConnection(constEmployeeConnectionString))
            {
                //  Set up the SQL Command
                SqlCeCommand cmd = EmployeeSqlConn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                //  Use the InsertAddress command
                cmd.CommandText = constInsertAddressSQL;
                cmd.Parameters.AddWithValue("@PropertyName", propertyName);
                cmd.Parameters.AddWithValue("@PropertyNumber", propertyNumber);
                cmd.Parameters.AddWithValue("@PostCode", postCode);

                EmployeeSqlConn.Open();
                //  Add the address to the database and get id back (INSERT)
                //      Normally we would check if the Address existed first.
                var rowsAffected = cmd.ExecuteNonQuery();
                cmd.CommandText = constGetIDSQL;
                SqlCeDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                var tmp = rdr[0].ToString();
                addressId = Convert.ToInt32(tmp);

                //  Add the employee and get the Id back
                cmd.CommandText = constInsertEmployeeSQL;
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@SupervisorId", supervisor);
                cmd.Parameters.AddWithValue("@DeptId", DeptId);
                cmd.Parameters.AddWithValue("@AddressId", addressId);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@PayGrade", payGrade);

                rowsAffected = cmd.ExecuteNonQuery();
                cmd.CommandText = constGetIDSQL;
                rdr = cmd.ExecuteReader();
                rdr.Read();
                tmp = rdr[0].ToString();
                newId = Convert.ToInt32(tmp);
            }

            //  Return the new Employee Id
            return newId;
        }



        private Employee MapTableToEmployeeClass(SqlCeDataReader reader)
        {
            Employee emp = null;
            //  Strip out the values from the query .
            int id = (int) reader["EmployeeId"];
            string name =(string) reader["Name"];
            string userName = (string)reader["UserName"];
            string phoneNumber = (string)reader["PhoneNumber"];
            //  Optional field, Nulls possible.
            int supervisorId = 0;
            if(reader["SupervisorId"] != System.DBNull.Value)
                supervisorId = (int)reader["SupervisorId"];        // Can be null.  Dooooooohh!  Thicko.

            int deptId = (int)reader["DeptId"];
            int addressId = (int)reader["AddressId"];
            string Type = ((byte)reader["Type"]).ToString();
            //  optional field.
            int paygrade = 0;
            if (reader["PayGrade"] != System.DBNull.Value)
                paygrade = (int)reader["PayGrade"];

            string deptname = (string)reader["DeptName"];
            string postcode = (string)reader["PostCode"];
            string propertyName = (string)reader["PropertyName"];
            //  Optional field.
            int propertyNumber = 0;
            if (reader["propertyNumber"] != System.DBNull.Value)
                int.TryParse((string)reader["PropertyNumber"], out propertyNumber);
            
            //  Construct a PostCode class
            PostCode postCode = new PostCode(postcode);

            //  Construct an Address class
            Address address = new Address(propertyName, propertyNumber, postCode); 
            
            //  Construct the Department class
            Department department = new Department();
            department.DepartmentName = deptname;
            
            //  Instantiate the relevent employee class
            if (Type == "1")
                emp = new SalariedEmployee(id, name, userName, address, phoneNumber, paygrade);
            else
                emp = new HourlyPaidEmployee(id, name, userName, address, phoneNumber);

            return emp;
        }
    }
}
