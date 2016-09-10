using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types1
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        interface IUserData
        {
            string FirstName { get; set; }
            string LastName { get; set; }
        }

        struct InfoData : IUserData
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        class Source
        {
            internal void CheckAndProceed(List<InfoData> data)
            {
                var dest = new Destination();
                //do something
                var castData = data.Cast<IUserData>().ToList();

                dest.ProceedData(castData);
            }
        }

        class Destination
        {
            internal void ProceedData(List<IUserData> data)
            {
                foreach (var item in data)
                {
                    //do something
                }
            }
        }
    }
}
