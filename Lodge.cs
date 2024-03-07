using System.Reflection;
using System;

namespace Serialization
{
    public class Lodge
    {
        public string Name { get; set; }
        public string Rooms { get; set; }
        public string Description { get; set; }
        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(Lodge);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo?.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(Lodge);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo?.SetValue(this, value, null);
            }
        }
    }
}
