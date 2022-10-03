using System;

namespace TestProject1
{
    internal class TestCategoryAttribute : Attribute
    {
        private string v;

        public TestCategoryAttribute(string v)
        {
            this.v = v;
        }
    }
}