using System.Reflection;

namespace TTT
{
    class Properties
    {
        public static PropertyInfo[] ListOfPropertiesFrom(Type AType)
        {
            //if (InstanceOfAType == null) return null;
            return AType.GetProperties(BindingFlags.Public);
        }

        public static MemberInfo[] ListOfPropertiesFromInstance1(object InstanceOfAType)
        {
            if (InstanceOfAType == null) return null;
            Type TheType = InstanceOfAType.GetType();
            BindingFlags f = (BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            return TheType.GetMembers(f);
            //.GetProperties(f);
        }

        public static Dictionary<string, PropertyInfo> DictionaryOfPropertiesFromInstance(object InstanceOfAType)
        {
            if (InstanceOfAType == null) return null;
            Type TheType = InstanceOfAType.GetType();
            PropertyInfo[] Properties = TheType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            Dictionary<string, PropertyInfo> PropertiesMap = new();
            foreach (PropertyInfo Prop in Properties)
            {
                PropertiesMap.Add(Prop.Name, Prop);
            }
            return PropertiesMap;
        }
    }

    public class TEST
    {
        public int TEST1 = 111;
        protected int TEST2 = 222;
        private int TEST3 = 333;
    }
}