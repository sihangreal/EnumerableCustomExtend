using System;
using System.Collections.Generic;
using System.Linq;

namespace EnumerableCustomExtend
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> list1 = new List<Person>()
            {
                new Person() { Name="朱文达",Age=20},
                new Person () { Name="徐良兴",Age=16},
                new Person () { Name="宋应",Age=14},
                new Person () { Name="郑捷伟",Age=14},
            };

            List<Person> list2 = new List<Person>()
            {
                new Person() { Name="朱文达",Age=18},
                new Person () { Name="徐良兴",Age=16},
                new Person () { Name="宋应",Age=14},
                new Person () { Name="陈思行",Age=12},
            };

            //去重
            //var list = list1.MyDistinct(v=>v.Age);

            //交集
            //var list = list1.MyIntersect(list2,v=>v.Name);
            //var list = list1.MyIntersect(list2, v=>v.Age.GetHashCode()*v.Name.GetHashCode());

            //差集
            // var list = list1.MyExcept(list2,v=>v.Age);

            //并集
            var list = list1.MyUnion(list2,v=>v.Name);

            list.ToList().ForEach(v => { Console.WriteLine(v.Name); });
            Console.ReadKey();
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

}
