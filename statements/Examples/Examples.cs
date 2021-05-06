using System;
using Xunit;

namespace Examples
{
    public class Examples
    {
        [Fact]
        public void JumpForExample()
        {
            Assert.Equal(10, forloop(0, x => x < 10, x => ++x));
            // Assert.Equal(10, forloop(0, x => x < 10, x => x++)); // endless loop
            Assert.Equal(10, forloop(0, x => x < 10, x => x + 2));
            Assert.Equal(22, forloop(1, x => x % 11 != 0, x => x + 3));
            Assert.Equal("AAA", forloop("", s => s.Length < 3, s => s + "A"));
            
            T forloop<T>(T start, Func<T, bool> condition, Func<T, T> increment)
            {
                var i = start;
                
                test:
                if (!condition(i)) return i;
                
                i = increment(i);
                goto test;
            }
        }
        
        [Fact]
        public void JumpWhileExample()
        {
            var x = 1;
            
            top:
            if (x % 13 == 0) goto exit;
            
            x *= 3;
            goto top;
            
            exit:
            Assert.True(x % 13 == 0);
        }
        
        [Fact]
        public void JumpDoExample()
        {
            var x = 1;
            
            top:
            x *= 3;
            
            if (x % 13 == 0) goto exit;
            goto top;
            
            exit:
            Assert.True(x % 13 == 0);
        }
    }
}
