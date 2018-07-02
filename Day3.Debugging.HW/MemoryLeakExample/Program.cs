using System.Collections.Generic;

namespace MemoryLeakExample
{
    public class Program
    {
        public static void Main()
        {
            var list = new List<MemoryLeak>();
            var someClass = new SomeClass();
            for (int i = 0; i < 1000; i++)
            {
                list.Add(new MemoryLeak(someClass));
            }
        }
    }
}