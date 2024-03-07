using System;
using System.Collections.Generic;
using System.Reflection;

namespace Serialization
{
    public class SkiResort
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public List<SkiRun> SkiRuns { get; set; }
        public List<Lodge> Lodges { get; set; } 
        public List<SkiEquipment> SkiEquipment { get; set; }
        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(SkiResort);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo?.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(SkiResort);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo?.SetValue(this, value, null);
            }
        }
    }
}
