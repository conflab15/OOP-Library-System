using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Library_System
{
    class Books
    {
        //Object Variables, using Get Set because the Variable Data is being retrieved from somewhere else and then set here.
        public string title { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
        public int booksAvailable { get; set; }

        public Books(Library lib, string title, string author, string genre, int booksAvailable) //Class Constructor to define how each book is
            //created before adding it to the Book Object List
        {
            this.title = title;
            this.author = author;
            this.genre = genre;
            this.booksAvailable = booksAvailable;
        }
    }
}
