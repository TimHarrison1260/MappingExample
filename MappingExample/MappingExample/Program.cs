using System;
using System.Collections.Generic;

using MappingExample.DataMappers;
using MappingExample.Model;

namespace MappingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //create mapper instance 
            EmployeeMapper em = new EmployeeMapper();

            // Get the same employee twice
            Employee emp1 = em.GetById(1);
            Employee emp2 = em.GetById(1);

            // check that the same object is returned by each call
            bool sameobject1 = emp1.Equals(emp2);

            // Get all hourly paid employees
            List<Employee> hpes = em.GetAllHourlyPaid();

            // Check that objects are not duplicated (may need to change these to match your data)
            // first hpe has empl1 as supervisor
            bool sameobject2 = emp1.Equals(hpes[0].Supervisor);         //  S/B TRUE
            // second hpe has first hpe as supervisor       NO DATA Has not been retrieved for this supervisor, although it's in the identity Map.
            bool sameobject3 = hpes[0].Equals(hpes[1].Supervisor);      //  S/B FALSE

            //  Get the supervisor for hpes[1], should have Id of 3
            Employee emp3 = em.GetById(3);
            bool sameobject4 = emp3.Equals(hpes[1].Supervisor);         //  S/B TRUE

            // Create a new hourly paid employee
            HourlyPaidEmployee newhpe = new HourlyPaidEmployee();
            Address newaddress = new Address("Entity Park", 100, new PostCode("KA1 1BX"));
            newhpe.Address = newaddress;
            newhpe.Name = "Michael";
            newhpe.Username = "michael";
            newhpe.PhoneNumber = "2222";
            newhpe.Supervisor = emp1;

            // store and retrieve - object from database should have ID set
            int newID = em.StoreHourlyPaid(newhpe);
            Employee newEmp = em.GetById(newID);

            // set break point here and inspect objects with debugger
            Console.ReadLine();
        }
    }
}
