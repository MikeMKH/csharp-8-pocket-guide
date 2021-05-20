using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Examples
{
    public class Examples
    {
        [Fact]
        public void LazyLoadExample()
        {
            var values = new List<int> { 1 };
            IEnumerable<int> query = values.Select(x => x * 10);
            values.Add(2);
            var result1 = query.ToArray();
            Assert.Equal(new [] { 10, 20 }, result1);
            
            Assert.Equal(new [] { 1, 2 }, values);
            var result2 = values.Select(x => x * 100).ToArray();
            values.Clear();
            Assert.Equal(0, values.Count);
            Assert.Equal(new [] { 100, 200 }, result2);
        }
        
        [Fact]
        public void QueryContinuationsExample()
        {
            var result =
              from c in "The quick brown fox".Split()
              select c.ToUpper() into upper
              where upper.StartsWith("B")
              select upper;
            
            Assert.Equal(new [] { "BROWN" }, result);
        }
        
        [Fact]
        public void MultipleGenatorsExample()
        {
            var numbers = new [] { 1, 2, 3 };
            var letters = new [] { 'A', 'B' };
            
            var x =
              from n in numbers
              from l in letters
              select $"{n}{l}";
            
            Assert.Equal(new [] { "1A", "1B",
                                  "2A", "2B",
                                  "3A", "3B" }, x.ToArray());
            
            var y =
              from l in letters
              from n in numbers
              select $"{n}{l}";
            
            Assert.Equal(new [] { "1A", "2A", "3A",
                                  "1B", "2B", "3B" }, y.ToArray());
        }
    }
}
