using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAMTraining.Utility.DesignPatterns
{
    public class Book
    {
        static void Main(string[] args)
        {
            Library book = Library.GetInstance();

            Library book1 = Library.GetInstance();

            string sBookName = book.getBookDetails();

            string sBook1Name = book1.getBook1Details();

            Console.WriteLine(sBookName);

            Console.WriteLine(sBook1Name);

            Console.ReadLine();
        }
    }
}