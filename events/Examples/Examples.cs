using System;
using Xunit;

namespace Examples
{
    public class Examples
    {
        public delegate void ValueChangedHandler<T>(T oldValue, T newValue);
        
        public class Changer<T>
        {
            private T _value;
            public T Value
            {
                get => _value;
                set
                {
                    if (!_value.Equals(value))
                    {
                        if (ValueChanged is not null) ValueChanged(_value, value);
                        _value = value;
                    }
                }
            }
            public Changer(T value) => _value = value;
            
            public event ValueChangedHandler<T> ValueChanged;
        }
        
        [Fact]
        public void EventExample()
        {
            var wasCalled = false;
            var wasAlsoCalled = false;
            Changer<string> changer = new ("hello");
            changer.ValueChanged += (oldValue, newValue) => Assert.NotEqual(oldValue, newValue);
            changer.ValueChanged += (_, _) => wasCalled = true;
            changer.ValueChanged += (_, _) => wasAlsoCalled = true;
            
            Assert.False(wasCalled);
            Assert.False(wasAlsoCalled);
            Assert.Equal("hello", changer.Value);
            
            changer.Value = "good bye";
            
            Assert.True(wasCalled);
            Assert.True(wasAlsoCalled);
            Assert.Equal("good bye", changer.Value);
        }
    }
}
