using System;
using Xunit;

namespace Examples
{
    public class Examples
    {
        [Fact]
        public void IndicesExamples()
        {
            var letters = new [] {'a', 'e', 'i', 'o', 'u'};
            
            Assert.Equal('u', letters[^1]);
            Assert.Equal('o', letters[^2]);
            
            Index first = 0;
            Index last = ^1;
            Assert.Equal('a', letters[first]);
            Assert.Equal('u', letters[last]);
        }
        
        [Fact]
        public void RangeExamples()
        {
            var letters = new [] {'a', 'e', 'i', 'o', 'u'};
            
            Assert.Equal(new [] {'a', 'e'}, letters[..2]);   
            Assert.Equal(new [] {'i', 'o', 'u'}, letters[2..]);
            Assert.Equal(new [] {'o', 'u'}, letters[^2..^0]);
            
            Range firstTwo = 0..2;
            Range lastTwo = ^2..^0;
            Assert.Equal(new [] {'a', 'e'}, letters[firstTwo]);
            Assert.Equal(new [] {'o', 'u'}, letters[lastTwo]);
        }
    }
}
