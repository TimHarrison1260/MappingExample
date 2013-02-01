//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace MappingExample.Queries
//{
//    public class EmployeeQuery
//    {
//        private Employee _employee = null;
//        private ICollection<Criteria> _criteria;

//        /// <summary>
//        /// Default Constructor
//        /// </summary>
//        public EmployeeQuery() { }

//        public void AddCriteria(Criteria criteria)
//        {
//            _criteria.Add(criteria);            
//        }

//        public Employee Execute(EmployeeMapper mapper)
//        {
//            return mapper.GetById(
//        }

//        public string GenerateWhereClause()
//        {
//            //  Iterate throgh all criteria and create the WHERE clauses
//            //  Logically AND them together.
//            StringBuilder bldr = new StringBuilder();
//            foreach (var c in _criteria)
//            {


//            }
//            return bldr.ToString();
//        }
//    }
//}
