using System;
using Xunit;

namespace Examples
{
    public class Examples
    {
        public readonly struct ComplexNumber
        {
            public ComplexNumber(int r, int i)
              => (Real, Imagine) = (r, i);
            
            public readonly int Real, Imagine;
            
            public static ComplexNumber operator + (ComplexNumber a, ComplexNumber b)
              => new ComplexNumber(a.Real + b.Real, a.Imagine + b.Imagine);
            
            public static ComplexNumber operator - (ComplexNumber a, ComplexNumber b)
              => new ComplexNumber(a.Real - b.Real, a.Imagine - b.Imagine);
        }
        
        [Theory]
        [InlineData(1, 2, 3, 4, 4, 6)]
        [InlineData(1, 2, 30, 40, 31, 42)]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(-1, -2, 1, 2, 0, 0)]
        [InlineData(-1, -2, -3, -4, -4, -6)]
        public void ComplexNumberPlus(
            int xr, int xi,
            int yr, int yi,
            int zr, int zi)
        {
            var x = new ComplexNumber(xr, xi);
            var y = new ComplexNumber(yr, yi);
            
            Assert.Equal(new ComplexNumber(zr, zi), x + y);   
        }
        
        [Theory]
        [InlineData(1, 2, 3, 4, -2, -2)]
        [InlineData(10, 20, 3, 4, 7, 16)]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(-1, -2, -1, -2, 0, 0)]
        [InlineData(-1, -2, -3, -4, 2, 2)]
        public void ComplexNumberMinus(
            int xr, int xi,
            int yr, int yi,
            int zr, int zi)
        {
            var x = new ComplexNumber(xr, xi);
            var y = new ComplexNumber(yr, yi);
            
            Assert.Equal(new ComplexNumber(zr, zi), x - y);   
        }
    }
}
