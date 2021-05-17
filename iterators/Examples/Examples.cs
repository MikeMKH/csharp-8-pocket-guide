using System;
using System.Collections.Generic;
using Xunit;

namespace Examples
{
    public class Examples
    {
        [Fact]
        public void ComposingSequencesExample()
        {
            var values = Filter(x => x % 2 == 0, Sequence(5));
            Assert.Equal(new [] { 0, 2, 4 }, values);
            
            IEnumerable<int> Sequence(int end)
            {
                int counter = 0;
                while (counter < end)
                {
                    Console.WriteLine($"counter={counter}");
                    yield return counter;
                    counter++;
                }
            }
            
            IEnumerable<int> Filter(Func<int, bool> filter, IEnumerable<int> sequence)
            {
                foreach(var value in sequence)
                {
                    Console.WriteLine($"value={value}");
                    if (filter(value))
                    {
                        Console.WriteLine("\tyield value");
                        yield return value;
                    }
                }
            }
        }
        /*
        counter=0
        value=0
                yield value
        counter=1
        value=1
        counter=2
        value=2
                yield value
        counter=3
        value=3
        counter=4
        value=4
                yield value
        */
    }
}
