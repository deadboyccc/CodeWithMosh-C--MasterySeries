using System.Data;

namespace series2;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var p1 = Person.Parse("ahmed", 12);
        System.Console.WriteLine(p1);
    }
    abstract class LivingBeing
    {
        protected abstract string Species { get; set; }
        protected abstract string DNA { get; set; }
        protected abstract int Age { get; set; }
        protected abstract void Eat();
        protected abstract void Sleep();

    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person()
        {
            this.Name = "default";
            this.Age = 0;
        }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public Person(string name)
        {
            this.Name = name;
            this.Age = 0;

        }
        public Person(int age)
        {
            this.Name = "default";
            this.Age = age;

        }
        public static Person Parse(string name, int age)
        {
            var p1 = new Person(name, age);
            return p1;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
