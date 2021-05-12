using System;
using Xunit;

namespace Examples
{
    public class Examples
    {
        delegate int Transformer(int x);
        
        [Fact]
        public void SquareExample()
        {
            Transformer f = Square;
            
            Assert.Equal(4, f(2));
            Assert.Equal(9, f(3));
            Assert.Equal(111 * 111, f(111));
            
            Transformer g = new Transformer(Square);
            
            Assert.Equal(f(22), g.Invoke(22));
            Assert.Equal(f.Invoke(42), g(42));
            
            int Square(int n) => n * n;    
        }
        
        [Fact]
        public void PluginExample()
        {
            int [] values = { 1, 2, 3, 4, 5 };
            int expected;
            
            Transform(values, Increment);
            expected = 2;
            foreach(var value in values)
            {
                Assert.Equal(expected, value);
                expected++;
            }
            
            Transform(values, Decrement);
            expected = 1;
            foreach(var value in values)
            {
                Assert.Equal(expected, value);
                expected++;
            }
            
            void Transform(int [] xs, Transformer t)
            {
                for(int i = 0; i < xs.Length; i++)
                {
                    xs[i] = t(xs[i]);
                }
            }
            
            int Increment(int n) => n + 1;
            int Decrement(int n) => n - 1;
        }
        
        [Fact]
        public void MulticastExample()
        {
            bool calledFoo = false;
            Transformer t = Foo;
            bool calledBar = false;
            t += Bar;
            
            var result = t(2);
            Assert.True(calledFoo);
            Assert.True(calledBar);
            Assert.False(result % 3 == 0); // Foo result is discarded
            Assert.True(result % 5 == 0);
            Assert.Equal(10, result);
            
            int Foo(int n)
            {
                calledFoo = true;
                return n * 3;
            }
            
            int Bar(int n)
            {
                calledBar = true;
                return n * 5;
            }
        }
    }
}
