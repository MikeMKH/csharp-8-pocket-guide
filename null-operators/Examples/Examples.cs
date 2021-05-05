using System;
using Xunit;

namespace Examples
{
    public class Examples
    {
        [Fact]
        public void NullCoalescingAssignmentExamples()
        {
            string x = null;
            string y = "hello";
            
            x ??= "one";
            y ??= "two";
            
            Assert.Equal("one", x);
            Assert.Equal("hello", y);
        }
    }
}
