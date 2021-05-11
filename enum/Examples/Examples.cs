using System;
using Xunit;

namespace Examples
{
    public class Examples
    {
        public enum Direction { North, South, West, East };
        
        [Fact]
        public void EnumConvertionExamples()
        {
            var way = Direction.West;
            Assert.Equal(2, (int) way);
            
            Assert.Equal(0, (int) Direction.North);
            Assert.Equal(3, (byte) Direction.East);
            
            int other = (int) Direction.South;
            Assert.Equal((int) Direction.South, other);
            
            Direction that = (Direction) 3;
            Assert.Equal(Direction.East, that);
        }
        
        [Flags]
        public enum Communication { Email = 1, SSM = 2, Twitter = 4, Snapchat = 8, Phone = 16};
        
        [Fact]
        public void FlagEnumExamples()
        {
            var preference = Communication.SSM | Communication.Email;
            Assert.True((preference & Communication.SSM) != 0);
            Assert.False((preference & Communication.Phone) != 0);
            Assert.Equal("Email, SSM", preference.ToString());
            
            Communication x = Communication.Snapchat;
            x |= Communication.Twitter;
            Assert.False((x & Communication.SSM) != 0);
            Assert.True((x & Communication.Snapchat) != 0);
            Assert.Equal("Twitter, Snapchat", x.ToString());
        }
    }
}
