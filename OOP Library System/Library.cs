using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Library_System
{
    class Library
    {
        //The Library Class Stores all of the Data needed, and all operations happen here. 
        //Class Fields needed for Operation
        public string location { get; set; }
        public string address { get; set; }
        public string postcode { get; set; }
        //Lists to store Details of the Customers, Books and Loans
        List<Customers> customers; //Customers List
        List<Books> books; //Books List
        List<Loans> loans; //Loans list

        public Library(string location, string address, string postcode) //Library Constructor
        {
            this.location = location;
            this.address = address;
            this.postcode = postcode;
            //Initialising the List Variables for the Object based on the Class so we can use them within the program
            customers = new List<Customers>();
            books = new List<Books>();
            loans = new List<Loans>();
        }
        //All of the Methods for Operation are below. They take data from the CLI Class Variables, and pass them to the respective Lists
        public void AddCustomer(Customers customer)
        {
            customers.Add(customer); //Add the Customer in the Customer Class to the Library Customer List
            //Customer Details are obtained from the constructor in the Customer Class
            //Constructor creates Customer objects, which gets data and inputs it to the new object, and in the Constructor, it passes over the Details to add to the list
        }
        public void AddBooks(Books book)
        {
            books.Add(book); //Add the Book in the Book Class to the Library Books List
            //Book Details are obtained from the Constructor in the Books Class
            //Constructor creates Book Objects, the createBook Method inputs the information into the Objects Data, and submits it to the list
        }
        public void AddLoans(Loans loan)
        {
            loans.Add(loan); //Add the loan to the loans list
            //Loan Details are obtained from the Constructor in the Loans Class
            //Constructor creates Loan Objects, the createCustomer Method inputs the information for the Object, and submits it to the list
        }
        //Returns the Items within each lists, the methods within the CLI Class then format how the Data is outputted to the user.
        public List<Customers> GetCustomers()
        {
            return customers; 
            //Returns every Customer Item to the GetCustomers method when called, which can be formatted to output 
            //in a seperate method
        }
        public List<Books> GetBooks()
        {
            return books;
            //Returns all book details, which can be formatted to output using a foreach loop and specifying each object 
            //as a method.
        }
        public List<Loans> GetLoans()
        {
            return loans;
            //Returns all loan details, which can be formatted to output using a foreach loop and specifying each object
            //as a method.
        }
    }
}
