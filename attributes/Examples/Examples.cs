using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Examples
{
    public class Examples
    {
        public class NothingAttribute : Attribute {}
        public class PropertyAttribute : Attribute
        {
            public string Property1;
            public int Property2;
            
            public PropertyAttribute() : this("hello", 0) {}
            public PropertyAttribute(string property1)
              => (Property1, Property2) = (property1, 0);
            public PropertyAttribute(string property1, int property2)
              => (Property1, Property2) = (property1, property2);
        }
        
        [Nothing]
        public void NothingMethod() {}
        
        [Property]
        public void DefaultMethod() {}
        
        [Property("property1")]
        public void Property1Method() {}
        
        [Property("good bye", 42)]
        public void PropertiesMethod() {}
        
        [Fact]
        public void MemberInfoExample()
        {
            var methods = typeof(Examples).GetMethods();
            var nothing = methods.Where(m => m.Name == "NothingMethod").FirstOrDefault();
            Assert.Equal("NothingMethod", nothing.Name);
        }
        
        [Fact]
        public void PropertyExample()
        {
            var x = (PropertyAttribute) Attribute.GetCustomAttribute(
                typeof(Examples).GetMethods().SingleOrDefault(m => m.Name == "DefaultMethod")
                ,typeof(PropertyAttribute));
            Assert.Equal("hello", x.Property1);
            Assert.Equal(0, x.Property2);
            
            var y = (PropertyAttribute) Attribute.GetCustomAttribute(
                typeof(Examples).GetMethods().SingleOrDefault(m => m.Name == "Property1Method")
                ,typeof(PropertyAttribute));
            Assert.Equal("property1", y.Property1);
            Assert.Equal(0, y.Property2);
            
            var z = (PropertyAttribute) Attribute.GetCustomAttribute(
                typeof(Examples).GetMethods().SingleOrDefault(m => m.Name == "PropertiesMethod")
                ,typeof(PropertyAttribute));
            Assert.Equal("good bye", z.Property1);
            Assert.Equal(42, z.Property2);
        }
    }
}
