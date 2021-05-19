using System;
using Xunit;

namespace Examples
{
    public class Examples
    {
        [Fact]
        public void CompilerDirectiveExample()
        {
            #nullable enable
            
            string warning = null; // warning CS8600: Converting null literal or possible null value to non-nullable type
            Assert.Null(warning);
            
            string? noIssue = null;
            Assert.Null(noIssue);
            
            #nullable disable
            
            string fine = null;
            Assert.Null(fine);
        }
        
        [Fact]
        public void NullForgivingOperator()
        {
            #nullable enable
            string? s1 = "hello";
            Assert.Equal(5, UnsafeSize(s1));
            Assert.Equal(5, SafeSize(s1));
            
            string? s2 = null;
            var nullReferenceException = Record.Exception(() => UnsafeSize(s2));
            Assert.IsType<NullReferenceException>(nullReferenceException);
            Assert.Equal(0, SafeSize(s2));
            
            int UnsafeSize(string? s) => s!.Length;
            int SafeSize(string? s) => s is null ? 0 : s.Length; // no compiler warning
            #nullable disable
        }
    }
}
