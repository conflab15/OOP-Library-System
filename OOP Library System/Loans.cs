using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Library_System
{
    class Loans
    {
        //Object Variables, using Get Set because the Variable Data is being retrieved from somewhere else and then set here.

        public int loanID { get; set; }
        public string loanTitle { get; set; }
        public int customerID { get; set; }
        public string returnDate { get; set; }

        //Loans Class takes the Library, Book title and CustomerID and adds it to the loans list
        public Loans(Library lib, int loanID, string loanTitle, int customerID, string returnDate)
        {
            this.loanID = loanID;
            this.loanTitle = loanTitle;
            this.customerID = customerID;
            this.returnDate = returnDate;
        }
    }
}
