using System;
using System.Text.RegularExpressions;

namespace MappingExample.Model
{
    /// <summary>
    /// represents a UK postcode, e.g. G4 
    /// </summary>
    public class PostCode
    {
        //INSTANCE VARIABLES

        private string area;
        private string property;

        //PROPERTIES

        /// <summary>
        /// the psotcode area, e.g. G4
        /// </summary>
        public string Area
        {
            get { return area; }
            set { area = value; }
        }
        
        /// <summary>
        /// the postcode property or group of properties, e.g. 0BA
        /// </summary>
        public string Property
        {
            get { return property; }
            set { property = value; }
        }

        public string FullCode
        {
            get { return String.Format("{0} {1}", area, property); }
        }

        //CONSTRUCTORS

        /// <summary>
        /// constructor for postcode using area and property
        /// </summary>
        /// <param name="area">the postcode area</param>
        /// <param name="property">the postcode property</param>
        public PostCode(string area, string property)
        {
            this.area = area;
            this.property = property;
        }


        /// <summary>
        /// constructor for postcode using full postcode
        /// </summary>
        /// <param name="fullCode">string containing full postcode</param>
        public PostCode(string fullCode)
        {
            string UK_POST_PATTERN = @"^(?<AREA>[A-PR-UWYZ0-9][A-HK-Y0-9][AEHMNPRTVXY0-9]?[ABEHMNPRVWXY0-9]?)(?<SPACE> {1,2})(?<PROPERTY>[0-9][ABD-HJLN-UW-Z]{2}|GIR 0AA)$";
            string area = null;
            string property = null;

            Regex ukPostRegex = new Regex(UK_POST_PATTERN, RegexOptions.Compiled);

            Match match = ukPostRegex.Match(fullCode);
            if (match.Success)
            {
                area = match.Groups["AREA"].Value;
                property = match.Groups["PROPERTY"].Value;
            }
            this.area = area;
            this.property = property;
        }

    }
}
