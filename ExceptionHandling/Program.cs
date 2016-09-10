using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    [Serializable]
    public class StackNetwork : Exception
    {
        private readonly int stackTail;
        public StackNetwork()
        {
            
        }

        public StackNetwork(string message) : base(message)
        {

        }

        public StackNetwork(string message, int stackTail) : base(message)
        {
            this.stackTail = stackTail;
        }

        public StackNetwork(string message, Exception inner) : base(message, inner)
        {

        }

        public StackNetwork(string message, int stackTail, Exception inner) : base(message, inner)
        {
            this.stackTail = stackTail;
        }
    }
}
