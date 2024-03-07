

using System.Reflection;
using System;

namespace Serialization
{
    public class SkiRun
    {
        public string Name { get; set; }    
        public string Difficulty { get; set; }
        public string Length { get; set; }  
        public string Description { get; set; }
        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(SkiRun);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo?.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(SkiRun);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo?.SetValue(this, value, null);
            }
        }

    }
}
