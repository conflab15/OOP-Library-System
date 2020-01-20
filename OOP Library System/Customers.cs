using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Library_System
{
    class Customers
    {
        //Object Variables, using Get Set because the Variable Data is being retrieved from somewhere else and then set here.
        //All Customers are created here, and then passed to the Customers List int
        public int customerID { get; set; }//Customers Variables
        public string foreName { get; set; } //Applying a get set to get the data elsewhere and then set it here.
        public string surName { get; set; }
        public string contactNumber { get; set; }

        //The Constructor takes in Data, and processes it, and the program later adds it to a list of Objects.
        //Items can be accessed by using customerInstanceName.customerID (etc.)
        
        public Customers(Library lib, int customerID, string foreName, string surName, string contactNumber) //Class Constructor
        {
            this.customerID = customerID;
            this.foreName = foreName;
            this.surName = surName;
            this.contactNumber = contactNumber;
        }  
    }
}
