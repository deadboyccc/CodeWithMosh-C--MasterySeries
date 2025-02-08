using System.Data;
using System.Text;

namespace series2;

internal class Program
{
    static void Main(string[] args)
    {
        #region Person Class 
        Console.WriteLine(new StringBuilder().Append('-', 20));
        Console.WriteLine("Hello, World!");
        var p1 = Person.Parse("Joe", 12);
        System.Console.WriteLine(p1);
        Console.WriteLine(new StringBuilder().Append('-', 20));
        var p2 = new Person { Name = "Biden", Age = 101 };
        p2.friends.Add(p1);
        System.Console.WriteLine(p2);
        Console.WriteLine(new StringBuilder().Append('-', 20));
        #endregion

        #region Person Class 'adding friends' method
        p1.AddFriends(
            new Person("Hillary", 99),
            new Person("Trump", 100)
        );
        p1.friends.ForEach(p => Console.WriteLine(p.Name));
        #endregion

        #region arrays functional methods
        var arr1 = new List<int> { 1, 2, 3, 4, 5 };

        // reduce = Aggregation
        int sum = arr1.Aggregate(0, (accu, num) => accu + num);
        int evenSum = arr1.Aggregate(0, (acc, num) => num % 2 == 0 ? acc += num : acc);
        Console.WriteLine($"Sum of the numbers: {sum}");
        Console.WriteLine($"Sum of the even numbers: {evenSum}");

        // map = select
        var mappedArr = arr1.Select(num => num * 2).ToList();
        Console.WriteLine("Mapped array: " + string.Join(", ", mappedArr));

        // filter = filter
        var filteredArr = arr1.Where(num => num % 2 == 0).ToList();
        Console.WriteLine("Filtered array: " + string.Join(", ", filteredArr));
        #endregion







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
        public void AddFriends(params Person[] people)
        {
            foreach (var person in people)
            {
                friends.Add(person);
            }
        }
        public override string ToString()
        { // return $"Name: {Name}, Age: {Age}";
            return $"Name: {Name}, Age: {Age}, FriendsCount: {friends.Count()}";
        }
    }
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
        public void Move(Point p)
        {
            // Defensive programming 
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            Move(p.X, p.Y);
        }
    }
}
