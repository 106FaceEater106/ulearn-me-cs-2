using System.Collections.Generic;
using System.Linq;
using Inheritance.DataStructure;
using NUnitLite;

class Program
{
	static void Main(string[] args)
	{
        //new AutoRun().Execute(args);

        var f = new Category("1", MessageType.Incoming, MessageTopic.Error);
        var a = new Category("1", MessageType.Incoming, MessageTopic.Error);
        System.Console.WriteLine(f.GetHashCode());
        System.Console.WriteLine(a.GetHashCode());
	}
}
