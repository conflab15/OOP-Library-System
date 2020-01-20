using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Library_System
{
    class CLI
    {
        Library lib = new Library("Bridgwater", "Blake Gardens, Bridgwater", "TA6 4ED"); //Instantiating a new Library Object
        bool login = false; //Boolean Variable for the Login Operation Logic
        Dictionary<string, string> AdminLogin = new Dictionary<string, string> 
        {
            { "Admin", "Administrator" }
        }; //Storing the Administrator Login Details to operate a Login System
        public void adminLogin()
        {
            login = true;
            while (login) //Operate while login is True
            {
                //Getting a Username and Password Attempt
                Console.WriteLine("Please enter the Admin Username: ");
                string userAttempt = Console.ReadLine();

                Console.WriteLine("Please enter the Password: ");
                string passAttempt = Console.ReadLine();

                //If attempted login matches the Stored Admin Credentials
                if (userAttempt == AdminLogin.Keys.ElementAt(0)) //Accessing Key Elements at specific location
                {
                    if (passAttempt == AdminLogin.Values.ElementAt(0)) //Accessing Valye Elements at specific Locations
                    {
                        Console.WriteLine("Login Accepted, Welcome back Admin");
                        login = false;
                        Menu();
                        //Go to Library System Menu
                    }
                    else
                    {
                        Console.WriteLine("Login Failed, please try again!"); //Login Failed Message
                    }
                }
                else
                {
                    Console.WriteLine("Login Failed, please try again!"); //LoginFailed message
                }
            }
        }
        public void Menu()
        {
            Console.WriteLine("Menu\n"); //Displaying the Menu Options and obtaining a choice from the User
            Console.WriteLine("Option 1: Add a Customer\nOption 2: Display Customers\nOption 3: Add a Book\nOption 4: Display Books\nOption 5: Make a Book Loan\nOption 6: Display Loans\nOption 7: Log out");
            Console.WriteLine("Please enter an Option Number: ");
            int menuOption;

            //Validation Technique, while the Attempted Input isn't an integer, display the message and ask for an Input again.
            while (!int.TryParse(Console.ReadLine(), out menuOption))
            {
                Console.WriteLine("The Value you've entered isn't a number, please try again.");
                Console.WriteLine("Please enter an Option Number");
            }

            switch (menuOption) //Switch Statement checks all the possible entries against the variable given to determine
                //different outputs or methods to be operated.
            {
                case 1:
                    //Launches method to create a new customer
                    Console.WriteLine("Adding Customer\n");
                    makeCustomer();
                    break;
                case 2:
                    Console.WriteLine("Displaying Customers");
                    showCustomers();
                    break;
                case 3:
                    //Launches method to create a new book
                    Console.WriteLine("Adding Book\n");
                    makeBook();
                    break;
                case 4:
                    showBooks();
                    break;
                case 5:
                    Console.WriteLine("Making a Loan\n");
                    makeLoan();
                    break;
                case 6:
                    showLoans();
                    break;
                case 7:
                    Console.WriteLine("Logging Out\n");
                    adminLogin();
                    break;
                default:
                    Console.WriteLine("Error, please try again!\n");
                    Menu();
                    break;
            }       
        }
        public void makeCustomer()
        {
            int i = 1; //Iteration Logic Variables
            foreach (Customers customer in lib.GetCustomers())
            {
                i++;
                //For every item in the Customers List of the Library, which is accessed through the GetCustomers() Method,
                //variable i is incremented by 1, which works out the next item within the List, so we avoid duplicated CustomerIDs
            }

            int custID = i; //CustomerID is assigned using the foreach loop above to ensure we don't duplicate ID Entries for a new Customer.

            //Gathering the Customers Details
            Console.WriteLine("Please enter the Customer Forename: ");
            string custForename = Console.ReadLine();
            Console.WriteLine("Please enter the Customer Surname: ");
            string custSurname = Console.ReadLine();
            Console.WriteLine("Please enter the Customer Contact Number, either Home or Mobile: ");
            string custContactNo = Console.ReadLine();

            Console.WriteLine("Thanks, the new Customer to be added is as follows: \n");
            Console.WriteLine("CustomerID: {0}\nCustomer Forename: {1}\nCustomer Surname: {2}\nCustomer Contact Number: {3}\n", 
                custID, custForename, custSurname, custContactNo);

            //Creating the new Object with the different data we have just entered into the system
            var cust1 = new Customers(lib, custID, custForename, custSurname, custContactNo);

            lib.AddCustomer(cust1); //The Library Method which adds the new Customer Object into the Customer List stored in the
            //Instance of the Library Class (This being lib)
            Menu();
        }
        public void showCustomers()
        {
            //Getting the Search Critera from the user to check against the List of Customers
            Console.WriteLine("Please enter the following Search Criteria: Customer Surname: ");
            string searchSurname = Console.ReadLine();

            Console.WriteLine("Showing Customers by Surname: {0}\n", searchSurname);
            //Iterating for each Object within the customer list which is returned through the GetCustomers() method. 
            //If the Surname given matches the Surname on the Object Iteration, all customer records with the Matching Surname will be displayed here.
            foreach (Customers customer in lib.GetCustomers())
            {
                if (searchSurname == customer.surName)
                {
                    Console.WriteLine("CustomerID: {0}", customer.customerID);
                    Console.WriteLine("Customer Forename: {0}", customer.foreName);
                    Console.WriteLine("Customer Surname: {0}", customer.surName);
                    Console.WriteLine("Customer Contact No: {0}\n", customer.contactNumber);
                }
            }

            Menu();
        }
        public void makeBook()
        {
            //Getting the Data about the Books from the User
            Console.WriteLine("Please enter the Title of the Book: ");
            string bookTitle = Console.ReadLine();
            Console.WriteLine("Please enter the Author of the Book:");
            string bookAuthor = Console.ReadLine();
            Console.WriteLine("Please enter the Genre of the Book:");
            string bookGenre = Console.ReadLine();
            Console.WriteLine("Please enter how many copies of the Book are being added to the Library: ");
            int copiesAvailable;

            while (!int.TryParse(Console.ReadLine(), out copiesAvailable))
            {
                Console.WriteLine("\nThe Value you've entered isn't a number, please try again.");
                Console.WriteLine("Please enter how many copies of the Book are being added to the Library: ");
            }

            Console.WriteLine("Thanks, the new book is as follows: \n");
            Console.WriteLine("Book Title: {0}\nBook Author: {1}\nBook Genre: {2}\nCopies of the Book Available: {3}\n", bookTitle, bookAuthor, bookGenre, copiesAvailable);
            //The Data is inputted into a new Book Object
            var book1 = new Books(lib, bookTitle, bookAuthor, bookGenre, copiesAvailable);
            //The new Book object just created is added to the Object List.
            lib.AddBooks(book1);

            Menu();
        }
        public void showBooks()
        {
            //Getting the Search Critera from the user to check against the List of Customers
            Console.WriteLine("Please enter the following Search Criteria: Book Title: ");
            string searchTitle = Console.ReadLine();
            
            Console.WriteLine("Showing Books by Title: {0}\n", searchTitle);
            //Iterating for each Object within the customer list which is returned through the GetCustomers() method. 
            //If the Surname given matches the Surname on the Object Iteration, all customer records with the Matching Surname will be displayed here.
            foreach (Books books in lib.GetBooks())
            {
                if (searchTitle == books.title)
                {
                    Console.WriteLine("Book Title: {0}", books.title);
                    Console.WriteLine("Book Author: {0}", books.author);
                    Console.WriteLine("Book Genre: {0}", books.genre);
                    Console.WriteLine("Copies Available: {0}\n", books.booksAvailable);
                }
            }
            Menu();
        }

        public void makeLoan()
        {
            //Creating a Loan ID. This checks against all of the current Loans, and ensures that an ID isn't used more than once.
            int i = 1;
            foreach (Loans loan in lib.GetLoans())
            {
                i++;
            }
            int loanID = i;

            //Getting the Relevant Details to construct a new Loan Object
            Console.WriteLine("Please enter the ID of the Customer making the Loan: ");
            int loanCustID; //For an integer entry, we ensure that the given data is an Integer, and doesn't proceed until an Integer is given

            while (!int.TryParse(Console.ReadLine(), out loanCustID))
            {
                Console.WriteLine("\nThe Value you've entered isn't a number, please try again.");
                Console.WriteLine("Please enter the ID of the Customer making the Loan: ");
            }

            Console.WriteLine("\nPlease enter the title of the book to be Loaned: ");
            string loanBookTitle = Console.ReadLine();

            //Here we get the Amount of Days which the book is to be loaned for, which gives the User Flexibility of the Loans being issued.
            Console.WriteLine("\nPlease enter the amount of days that the book is to be loaned for: ");
            int lengthOfLoan;

            while (!int.TryParse(Console.ReadLine(), out lengthOfLoan))
            {
                Console.WriteLine("\nThe Value you've entered isn't a valid number, please try again.");
                Console.WriteLine("\nPlease enter the amount of days that the book is to be loaned for: ");
            }
            
            //Here we are using the DateTime Method to add Days of the loan Length to nows date, to provide us with the 
            string returnDate = DateTime.Now.AddDays(lengthOfLoan).ToString("dd/MM/yy");

            //Outputting the Final Loan Details before submitting the Loan to the Loan Object List
            Console.WriteLine("\nThanks, the new Loan is as follows");
            Console.WriteLine("LoanID: {0}\nCustomer ID of Loan: {1}\nTitle of the Book being Loaned: {2}\nReturn due of the Book being Loaned: {3}\n",
                loanID, loanCustID, loanBookTitle, returnDate);

            //Creating a new Loan Object based upon the information given above.
            var loan1 = new Loans(lib, loanID, loanBookTitle, loanCustID, returnDate);

            //Adding the Loan Object to the Loans List through the Library Method.
            lib.AddLoans(loan1);
            Menu();
        }
        public void showLoans()
        {
            Console.WriteLine("Displaying Loans\n");
            Console.WriteLine("Showing Customers for Library: {0}", lib.location);
            Console.WriteLine("Address: {0}", lib.address);
            Console.WriteLine("Postcode: {0}\n", lib.postcode);

            //lib.GetLoans() returns everything in the Loans Object List, and here we format how each List Object is to be outputted to the User.
            foreach (Loans loan in lib.GetLoans())
            {
                Console.WriteLine("LoanID: {0}", loan.loanID);
                Console.WriteLine("Book on Loan: {0}", loan.loanTitle);
                Console.WriteLine("Loaned to CustomerID: {0}", loan.customerID);
                Console.WriteLine("Return Date for book: {0}\n", loan.returnDate);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Menu();
        }
    }
}
