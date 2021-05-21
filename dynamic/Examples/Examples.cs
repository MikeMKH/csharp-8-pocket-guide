using System;
using System.Dynamic;
using Xunit;

namespace Examples
{
    public class Examples
    {
        public class DynamicRecorder : DynamicObject
        {
            public string Caller { get; set; }
            
            public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
            {
                Caller = binder.Name;
                result = args;
                return true;
            }
        }
        
        [Fact]
        public void CustomBindingExample()
        {
            dynamic d = new DynamicRecorder();
            
            var x = d.Hello();
            Assert.Equal("Hello", d.Caller);
            Assert.Equal(0, x.Length);
            
            var y = d.Foo("1", 2, 3.0, '4', new { value = 5 });
            Assert.Equal("Foo", d.Caller);
            Assert.Equal(5, y.Length);
            Assert.Equal("1", y[0]);
            Assert.Equal(2, y[1]);
            Assert.Equal(3.0, y[2]);
            Assert.Equal('4', y[3]);
            Assert.Equal(5, y[4].value);
        }
        
        [Fact]
        public void LanguageBindingExample()
        {
            var i = Mean(2, 6);
            Assert.Equal(4, i);
            
            var f = Mean(2.1, 6.5);
            Assert.Equal(4.3, f);
            
            var d = Mean(2.12d, 6.52d);
            Assert.Equal(4.32d, d);
            
            var runtimeBinderException = Record.Exception(() => Mean("hello", "world"));
            Assert.IsType<Microsoft.CSharp.RuntimeBinder.RuntimeBinderException>(runtimeBinderException);
            
            dynamic Mean(dynamic x, dynamic y) => (x + y) / 2;
        }
    }
}
