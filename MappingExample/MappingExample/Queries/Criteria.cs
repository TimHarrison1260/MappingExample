//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace MappingExample.Queries
//{
//    public class Criteria
//    {
//        private string _sqlOperator;
//        private string _fieldName;
//        private object _value;

//        /// <summary>
//        /// Private constructor, so that the class cannot be instantiated directly
//        /// rether through the Static setter methods.
//        /// </summary>
//        /// <param name="sqlOperator"></param>
//        /// <param name="fieldName"></param>
//        /// <param name="value"></param>
//        private Criteria(string sqlOperator, string fieldName, object value)
//        {
//            this._sqlOperator = sqlOperator;
//            this._fieldName = fieldName;
//            this._value = value;
//        }

//        public static Criteria Equals(string fieldName, int value)
//        {
//            return new Criteria("=", fieldName, value);
//        }

//        public static Criteria Equals(string fieldName, object value)
//        {
//            return new Criteria("=", fieldName, value);
//        }

//        public string GenerateSQL()
//        {
//            //  Generate the SQL where clause
//            StringBuilder 
//        }

//    }
//}
