using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Library_System
{
    class Program
    {
        static void Main(string[] args)
        {
            ///<summary>
            ///Initialising a new CLI Class, everything within the Program, including Methods, creating new objects,
            ///and giving data to lists is done within the CLI Class.
            ///The Library Class holds all of the methods for the programs operations, and stores all of the information created.
            ///The Customers, Books and Loans Classes define how the Objects are constructed before they're added to their respective 
            ///Object Lists.
            /// </summary>
            var IO = new CLI();

            //Running the Login Method
            IO.adminLogin();
        }
    }
}
