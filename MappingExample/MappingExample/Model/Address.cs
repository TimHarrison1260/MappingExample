using System;

namespace MappingExample.Model
{
    public class Address
    {
        // INSTANCE VARIABLES

        private string propertyName; 
        private int propertyNumber;
        private PostCode postCode;

        // PROPERTIES

        /// <summary>
        /// the property name
        /// </summary>
        public string PropertyName
        {
            get { return propertyName; }
            set { propertyName = value; }
        }

        /// <summary>
        /// the property number
        /// </summary>
        public int PropertyNumber
        {
            get { return propertyNumber; }
            set { propertyNumber = value; }
        }

        /// <summary>
        /// the postcode
        /// </summary>
        public PostCode PostCode
        {
            get { return postCode; }
            set { postCode = value; }
        }

        // CONSTRUCTOR

        /// <summary>
        /// constructor for adress
        /// </summary>
        /// <param name="propertyName">the property name</param>
        /// <param name="propertyNumber">the property number</param>
        /// <param name="postCode">the postcode</param>
        public Address(string propertyName, int propertyNumber,
            PostCode postCode)
        {
            this.propertyName = propertyName;
            this.propertyNumber = propertyNumber;
            this.postCode = postCode;
        }

        // METHODS

        /// <summary>
        /// lookup up the full street and town text using some service...
        /// </summary>
        /// <returns>the street and town name as a string</returns>
        public string LookupPostcode()
        { 
            throw new NotImplementedException();
        }

    }
}
