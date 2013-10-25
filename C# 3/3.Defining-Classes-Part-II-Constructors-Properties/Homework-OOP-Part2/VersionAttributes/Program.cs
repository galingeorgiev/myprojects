/*Create a [Version] attribute that can be applied to
 *structures, classes, interfaces, enumerations and
 *methods and holds a version in the format major.minor
 *(e.g. 2.11). Apply the version attribute to a sample
 *class and display its version at runtime.*/
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace VersionAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface |
        AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)]
    public class VersionAttribute : Attribute
    {
        private int major;
        private int minor;

        public VersionAttribute(int major, int minor)
        {
            this.major = major;
            this.minor = minor;
        }

        public int Major
        {
            get{ return this.major; }
        }

        public int Minor
        {
            get { return this.minor; }
        }

        public override string ToString()
        {
            return string.Format("{0}.{1}", this.major, this.minor);
        }
    }

    [Version(2,13)]
    class Program
    {
        static void Main()
        {
            Type type = typeof(Program);
            VersionAttribute attributes = (VersionAttribute)type.GetCustomAttribute(typeof(VersionAttribute),true);
            Console.WriteLine(attributes);
        }
    }
}
