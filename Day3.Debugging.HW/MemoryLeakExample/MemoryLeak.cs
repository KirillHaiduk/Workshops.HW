using System;

namespace MemoryLeakExample
{
    public class MemoryLeak
    {
        private SomeClass someClass;

        public MemoryLeak(SomeClass someClass)
        {
            this.someClass = someClass;
            someClass.SomeEvent += SomeClass_SomeEvent;
        }

        private void SomeClass_SomeEvent(object sender, EventArgs e)
        {
        }
    }

    public class SomeClass
    {
        public event EventHandler SomeEvent;
    }
}