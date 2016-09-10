using System;
using System.Collections;
using System.Collections.Generic;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = CreateList(typeof(string));
            list.Add("hello1");
            list.Add("hello2");
            list.Add("hello3");
            list.Add("hello4");
            list.Add("hello5");
            // list.Add(2);         System.ArgumentException
        }

        private static IList CreateList(Type t)
        {
            var listType = typeof(List<>);
            var constructedListType = listType.MakeGenericType(t);
            var instance = Activator.CreateInstance(constructedListType);
            return (IList)instance;
        }

    }
}
