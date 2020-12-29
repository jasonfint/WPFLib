using System;
using System.Collections.Generic;
using System.Windows;

namespace 序列化和反序列化
{
    [Serializable] //给Person类添加该特性，表示Person类可以进行序列化

    public class Person

    {

        public Person(string name, int age, string gender)

        {

            this.Name = name;

            this.Age = age;

            this.Gender = gender;

        }

        public Person()
        {
            mypeople = new List<Person>();
            mypeople.Add(new Person("章", 22, "三"));
            mypeople.Add(new Person("李", 22, "三"));
            mypeople.Add(new Person("王", 22, "三"));
        }

        public string Name { get; set; }
        public string Name1 { get; set; } = "我就是我";
        public string Name2 { get; set; } = "我就是我2";
        public string Name3 { get; set; } = "我就是我3";
        public string Name4 { get; set; } = "我就是我4";
        public string Name5 { get; set; }
        public string Name6 { get; set; }
        public string Name7 { get; set; }
        public string Name8{ get; set; }
        public string TwoName { get; set; } = "我就是我，不一样的烟火，你拿我咋的";
        public string ThreeName { get; set; } = "我就是我，不一样的烟火，你拿我咋的3";
        public string TwoName2 { get; set; } = "我就是我，不一样的烟火，你拿我咋的";
        public string TwoName5 { get; set; } = "我就是我，不一样的烟火，你拿我咋的";
        public string TwoName6{ get; set; } = "我就是我，不一样的烟火，你拿我咋的";
        public string TwoName7 { get; set; } = "我就是我，不一样的烟火，你拿我咋的";
        public Point point1 { get; set; } = new Point(0,20);
        public Point point2 { get; set; } = new Point(0, 20);
        public bool ni { get; set; } = false;
        public bool ni2 { get; set; } = false;
        public bool ni3 { get; set; } = false;
        public bool ni4{ get; set; } = false;
        public int Age { get; set; }

        public string Gender { get; set; }
         
        public List<Person> mypeople { get; set; }
        public Dictionary<int,Person> dicpeople { get; set; }
        public Point point { get; set; } = new Point(10,10);
        public Rect rect { get; set; } = new Rect(new Point(10,10),new Point(20,20));
        public string SayHello()

        {

            return string.Format("大家好，我叫{0},年龄{1},性别{2}", Name, Age, Gender);

        }

    }
}