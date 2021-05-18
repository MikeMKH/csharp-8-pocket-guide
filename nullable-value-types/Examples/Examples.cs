using System;
using Xunit;

namespace Examples
{
    public class Examples
    {
        [Fact]
        public void BoxingUnboxingNullableExample()
        {
            object o = "hello"; // boxing
            int? x = o as int?; // unboxing
            Assert.Null(x);
            
            var v = (object) 5; // boxing
            int? y = v as int?; // unboxing
            Assert.IsType<int>(y);
            Assert.Equal(5, y);
        }
        
        [Fact]
        public void OperatorLiftingExample()
        {
            int? x = 5;
            int? y = 6;
            Assert.True(x < y);
            Assert.False(x > y);
            
            Assert.True(null == null);
            Assert.True((bool?) null == (bool?) null);
            
            int? z = null;
            Assert.Null(x + z);
            
            bool? n = null, t = true, f = false;
            Assert.Null(n | n);
            Assert.Null(n | f);
            Assert.True(n | t);
            Assert.Null(n & n);
            Assert.False(n & f);
            Assert.Null(n & t);
        }
        
        [Fact]
        public void NullableWithNullCoalescingOperator()
        {
            int? x = null;
            int y = x ?? 8;
            Assert.IsType<int>(y);
            Assert.Equal(8, y);
            
            int? a = null, b = null, c = 42;
            Assert.Equal(42, a ?? b ?? c);
        }
        
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(3, "Fizz")]
        [InlineData(4, "4")]
        [InlineData(5, "Buzz")]
        [InlineData(6, "Fizz")]
        [InlineData(7, "7")]
        [InlineData(15, "FizzBuzz")]
        [InlineData(33, "Fizz")]
        [InlineData(45, "FizzBuzz")]
        [InlineData(55, "Buzz")]
        public void FizzBuzzExample(int value, string expected)
        {
            var actual = FizzBuzz(value);
            Assert.Equal(expected, actual);
            
            string FizzBuzz(int n)
            {
                Func<int, int, bool> isDivisible = (x, divisor) => x % divisor == 0;
                string fizz = isDivisible(value, 3) ? "Fizz" : null;
                string buzz = isDivisible(value, 5) ? "Buzz" : null;
                string result = string.IsNullOrEmpty(fizz + buzz) ? value.ToString() : fizz + buzz;
                return result;
            }
        }
    }
}
