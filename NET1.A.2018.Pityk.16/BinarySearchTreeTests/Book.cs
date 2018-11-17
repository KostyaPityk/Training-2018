using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeTests
{
    public class Book
    {
        public string name;
        public int pages;

        public Book(string name, int pages)
        {
            this.name = name;
            this.pages = pages;
        }

        public override bool Equals(object obj)
        {
            Book comparerBook = obj as Book;

            if (name == comparerBook.name && pages == comparerBook.pages)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
