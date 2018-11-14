using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Test
{
    public class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Human()
        {
            Age = new Random().Next();
            Name = "Test";
        }

        public static Human CreateHuman() => new Human();
    }
}
