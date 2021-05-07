using System;
using Xunit;

namespace Examples
{
    public class Examples
    {
        [Fact]
        public void BoxingAndUnboxingExamples()
        {
            int x = 8;
            object o = x; // box
            // Assert.False(x == o); // reference type semantics // error CS0019: Operator '==' cannot be applied to operands of type 'int' and 'object'
            Assert.True(x.Equals(o)); // value type semantics
            
            int y = (int) o; // unbox
            Assert.IsType<int>(o);
            Assert.IsType<int>(y);
        }
        
        [Fact]
        public void InvalidCastExceptionExample()
        {
            int x = 8;
            object o = x; // box
            
            var invalidCastException = Record.Exception(() => { long z = (long) o; });
            Assert.IsType<System.InvalidCastException>(invalidCastException);
            
            // int z = (int) "8"; // error CS0030: Cannot convert type 'string' to 'int'
        }
        
        [Fact]
        public void GetTypeExamples()
        {
            int x = 8;
            
            Assert.Equal("Int32", x.GetType().Name);
            Assert.Equal("System.Int32", x.GetType().FullName);
            Assert.True(x.GetType() == typeof(int)); // reference type semantics
            
            Func<int, int> add1 = x => x + 1;
            Action<int> write1 = _ => System.Console.WriteLine("1");
            Func<int> give1 = () => 1;
            Predicate<int> is1 = x => x == 1;
            Func<int, bool> is2 = x => x == 2;
            
            Assert.Equal("Func`2", add1.GetType().Name);
            Assert.Equal("Action`1", write1.GetType().Name);
            Assert.Equal("Func`1", give1.GetType().Name);
            Assert.Equal("Predicate`1", is1.GetType().Name);
            Assert.Equal("Func`2", is2.GetType().Name);
            
            // var foo = (Predicate<int>) is2; // error CS0030: Cannot convert type 'System.Func<int, bool>' to 'System.Predicate<int>'
            // var bar = (Func<int, bool>) is1; // error CS0030: Cannot convert type 'System.Predicate<int>' to 'System.Func<int, bool>'
        }
    }
}
