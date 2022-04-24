using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAMTraining.Utility.DesignPatterns
{
    internal class Library
    {
        private static int counter = 0;
        private Library()
        {
            counter++;
            Console.WriteLine("Counter Value : " + counter.ToString());
        }
        public static Library objInstance;
        private static readonly object mylockobject = new object();  //Multi threaded 

        public static Library GetInstance()
        {
            lock (mylockobject)
            {
                if (objInstance == null)
                    objInstance = new Library();
            }
            return objInstance;
        }
        public string getBookDetails()
        {
            return "The Secret - written by Rhonda Byrne.";
        }

        public string getBook1Details()
        {
            return "Thulazi - written by Balakumaran.";
        }
    }
}