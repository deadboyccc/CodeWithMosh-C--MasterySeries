using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace series2;

internal class Program
{
    static void Main(string[] args)
    {
        Circle circle = new Circle() { Width = 5, Height = 5, X = 10, Y = 10 };
        Rectangle rectangle = new Rectangle() { Width = 10, Height = 5, X = 5, Y = 5 };
        Triangle triangle = new Triangle() { Width = 5, Height = 5, X = 15, Y = 15 };
        List<Shape> shapeList = new(){
            circle, rectangle, triangle
        };
        foreach (var shape in shapeList)
        {
            shape.Draw();
        }

    }
    #region poly
    public class Triangle : Shape
    {
        public override void Draw()
        {
            System.Console.WriteLine("Drawing Triangle");
            base.Draw();

        }
    }
    public class Circle : Shape
    {
        public override void Draw()
        {
            System.Console.WriteLine("Drawing Circle");
            base.Draw();
        }

    }
    public class Rectangle : Shape
    {
        public override void Draw()
        {
            System.Console.WriteLine("Drawing Rectangle");
            base.Draw();

        }

    }
    public class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public virtual void Draw()
        {
            System.Console.WriteLine($"Drawing Shape at ({X},{Y}) with Width: {Width}, Height: {Height}");
        }
        #endregion

        private static async Task Inheritance1()
        {
            // both ref the same location in heap
            // upcast from child to parent - form base to derived
            //define a stream to the same file but with only read capabilities
            var textBox = new TextBox();
            var shape = textBox;
            var castedTextBo = shape as TextBox;
            // null checking
            castedTextBo?.Draw();
            if (castedTextBo is TextBox)
            {
                System.Console.WriteLine("true ");
            }

            textBox.Width = 100;
            shape.Width = 50;
            System.Console.WriteLine(shape.Width);
            var objList = new ArrayList();
            objList.Add(new Car("137", 4));
            objList.Add(new Shape());
            objList.Add(1);
            foreach (var obj in objList)
            {
                await WaitOneSec();
                System.Console.WriteLine(obj.GetType());

            }
        }

        public static Task WaitOneSec()
        {

            return Task.Delay(1000);
        }
        #region upcasting and downcasting
        public class TextBox : Shape
        {
            public string? Font { get; set; }
            public int FontSize { get; set; }
        }
        #endregion
        private static void InheritanceEx()
        {
            var c1 = new Car("137", 2);
        }
        #region Inheritance
        public class Vehicle
        {
            public string LegalNum { get; set; }
            public Vehicle(string legalNum)
            {
                System.Console.WriteLine($"Vehile Init {legalNum}");
                LegalNum = legalNum;
            }
        }
        public class Car : Vehicle
        {
            public int Doors { get; set; }
            public Car(string legalNum, int doors) : base(legalNum)
            {
                System.Console.WriteLine($"Car Init {legalNum}");
                Doors = doors;
            }
        }
        public class GoldCustomer : Customer
        {
            public void OfferVoucher()
            {
                Console.WriteLine("Offering 11% voucher for next purchase");
                this.Promote();
            }

        }
        public class Customer
        {
            public int index { get; set; }
            public string? Name { get; set; }
            public void Promote()
            {
                var loyaltyLevel = CalculateRating();
                switch (loyaltyLevel)
                {
                    case 1:
                        Console.WriteLine("Customer is a Silver Member");
                        break;
                    case 2:
                        Console.WriteLine("Customer is a Gold Member");
                        break;
                    case 3:
                        Console.WriteLine("Customer is a Platinum Member");
                        break;
                    default:
                        Console.WriteLine("Customer is not a member");
                        break;
                }
            }
            private int CalculateRating()
            {
                return new Random().Next(1, 4);
            }
        }
        #endregion

        private static void association()
        {
            var DbMigrator = new DbMigrator(new Logger());
            var installer = new Installer(new Logger());

            DbMigrator.Migrate();
            installer.Install();
        }
        #region composition
        class Logger
        {
            public void LogMessage(string message)
            {
                System.Console.WriteLine($"[{DateTime.Now}] {message}");
            }
        }
        class DbMigrator
        {
            private readonly Logger Logger;
            public DbMigrator(Logger loggerInstance)

            {
                Logger = loggerInstance;

            }

            public void Migrate()
            {
                Logger.LogMessage("DbMigrator started migration");
            }
        }
        class Installer
        {
            private readonly Logger logger;

            public Installer(Logger loggerInstance)
            {
                this.logger = loggerInstance;
            }
            public void Install()
            {
                logger.LogMessage("Installer started installation");
            }
        }
        #endregion
        #region association/composition 
        class Text : PresentationObject
        {
            public string? FontName { get; set; }
            public int FontSize { get; set; }
            public string? TextContent { get; set; }
            public void addHyperlink(string url)
            {
                System.Console.WriteLine($"add hyperlink: {url}");
            }
        }
        class PresentationObject

        {
            public int Width { get; set; }
            public int Height { get; set; }
            public void Copy()
            {
                System.Console.WriteLine("copy");

            }
            public void Duplicate()
            {
                System.Console.WriteLine("duplicate");

            }

        }

        #endregion

        private static void draftie()
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

        class Test
        {
            private readonly Dictionary<string, string> test = new();
            // implementing an index overload
            public string this[string key]
            {
                get
                {
                    if (test.ContainsKey(key))
                    {
                        return test[key];
                    }
                    else
                    {
                        return "Key not found";
                    }
                }
                set
                {
                    // value = rhs = keyword
                    test[key] = value;
                }
            }
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
            // ctro =constructor, prop = property snippets
            // auto property = create private fields behind the scenes
            public string Name { get; set; }
            public int Age { get; set; }
            public int AgeInDays
            {
                // get
                // {
                //     return Age * 365;
                // }
                // using the TimeSpan class
                get
                {
                    return new TimeSpan(Age, 0, 0).Days;
                }
            }
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
}