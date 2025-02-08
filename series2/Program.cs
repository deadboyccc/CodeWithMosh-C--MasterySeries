using System.Data;
using System.Text;

namespace series2;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(new StringBuilder().Append('-', 20));
        Console.WriteLine("Hello, World!");
        var p1 = Person.Parse("Joe", 12);
        System.Console.WriteLine(p1);
        Console.WriteLine(new StringBuilder().Append('-', 20));
        var p2 = new Person { Name = "Biden", Age = 101 };
        p2.friends.Add(p1);
        System.Console.WriteLine(p2);
        Console.WriteLine(new StringBuilder().Append('-', 20));

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
        public List<Person> friends;
        // one constructor with default value = cleaner, but this is just for learning :3
        public Person()
        {
            this.Name = "default";
            this.Age = 0;
            friends = new List<Person>();
        }
        public Person(string name, int age) : this()
        {
            this.Name = name;
            this.Age = age;
        }
        public Person(string name) : this()
        {
            this.Name = name;
            this.Age = 0;

        }
        public Person(int age) : this()
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
            // return $"Name: {Name}, Age: {Age}";
            return $"Name: {Name}, Age: {Age}, FriendsCount: {friends.Count()}";
        }
    }
}
