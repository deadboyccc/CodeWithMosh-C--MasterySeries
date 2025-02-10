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

    }

    private static void EncryptAndSendNotifcations()
    {
        var Encrypter = new Encrypt("pass123");
        Encrypter.DoTheEncryption();
        Encrypter.DoTheEncryption();
    }
    #region Delegate to send notifications(sms&email etc...) after encoding a password
    public class Encrypt
    {
        public string? str;
        public delegate void SendNotification(string message);
        public Encrypt(string textToEncrypt)
        {
            str = textToEncrypt;

        }

        public void DoTheEncryption()
        {
            // Encrypt the string
            str = "jfewopaijfeapfejiaowjfpioejf@#j42913028____XD";
            // attaching methods to the delegate so that the delagete object calls them :3(not implementing an event)
            SendNotification sendNotificationService;
            sendNotificationService = new SmsSenderService().Send;
            sendNotificationService += new EmailSenderSerivce().Send;
            sendNotificationService.Invoke("Done Encrypting! ");
            // call the delegate

        }
        public interface ISenderService
        {
            void Send(string message);
        }
        public class EmailSenderSerivce : ISenderService
        {
            public void Send(string message)
            {
                // simple log
                Console.WriteLine($"Email sent: {message}");
            }
        }
        public class SmsSenderService : ISenderService
        {
            public void Send(string message)
            {
                // simple log
                Console.WriteLine($"SMS sent: {message}");
            }
        }
    }
    #endregion

    private static void DependencyInjection()
    {
        var result = new Calculator().Add(10.342, 2342.14);
        Console.WriteLine(result);
        var databaseMigrator = new DbMigrator(new ConsoleLogger());
        databaseMigrator.Migrate();
        databaseMigrator.Migrate();
        var FileLogDBMigrator = new DbMigrator(new FileLogger());
        FileLogDBMigrator.Migrate();
        FileLogDBMigrator.Migrate();
        FileLogDBMigrator.Migrate();
        var StreamLogDBMigrator = new DbMigrator(new StreamLogger());
        StreamLogDBMigrator.Migrate();
        StreamLogDBMigrator.Migrate();
        StreamLogDBMigrator.Migrate();
    }
    #region interfaces
    public class StreamLogger : ILogger
    {
        public void Log(string message)
        {
            // use "using" so if an error happens or outside the scope of the block it will auto dispose/close the stream/file hanlder
            using (var StreamWriter = new StreamWriter("./data/log.txt", true))
            {

                StreamWriter.WriteLine($"Log: {message}");
                StreamWriter.Dispose();
            }
        }

        public void LogError(string message)
        {
            using (var StreamWriter = new StreamWriter("./data/error.txt", true))
            {
                StreamWriter.WriteLine($"Error: {message}");
                StreamWriter.Dispose();
            }
        }
    }

    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            File.AppendAllText("./data/log.txt", message);

        }

        public void LogError(string message)
        {
            File.AppendAllText("./data/error.txt", message);

        }
    }
    public class DbMigrator
    {
        private readonly ILogger logger;

        // dependency injection (in the constructor u write out the needed depenencies for the Migrator class)
        // injecting the depencies into the constructor 
        public DbMigrator(ILogger logger)
        {
            this.logger = logger;
        }
        public void Migrate()
        {
            logger.Log("Migrating database...");
            var num = new Random().Next(1, 3);
            if (num == 1)
            {
                ReportErrors();

            }

        }
        private void ReportErrors()
        {
            logger.LogError("Error during migration");
        }

    }
    public interface ILogger
    {
        void Log(string message);
        void LogError(string message);
    }
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{DateTime.Now}] {message}");
            Console.ForegroundColor = default;
        }
        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{DateTime.Now}] ERROR: {message}");
            Console.ForegroundColor = default;
        }

    }
    public interface IArithmeticAdd
    {
        double Add(double a, double b);
    }
    public class Calculator : IArithmeticAdd
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
    }
    #endregion

    private static void poly()
    {
        Circle circle = new Circle() { Width = 5, Height = 5, X = 10, Y = 10 };
        Rectangle rectangle = new Rectangle();
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
            Console.WriteLine("Drawing Triangle");

        }
    }
    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing Circle");
        }

    }
    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing Rectangle");

        }

    }
    public abstract class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public abstract void Draw();
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
                Console.WriteLine("true ");
            }

            textBox.Width = 100;
            shape.Width = 50;
            Console.WriteLine(shape.Width);
            var objList = new ArrayList();
            objList.Add(new Car("137", 4));
            objList.Add(1);
            foreach (var obj in objList)
            {
                await WaitOneSec();
                Console.WriteLine(obj.GetType());

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
            public override void Draw()
            {
                throw new NotImplementedException();
            }
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
                Console.WriteLine($"Vehile Init {legalNum}");
                LegalNum = legalNum;
            }
        }
        public class Car : Vehicle
        {
            public int Doors { get; set; }
            public Car(string legalNum, int doors) : base(legalNum)
            {
                Console.WriteLine($"Car Init {legalNum}");
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
                Console.WriteLine($"[{DateTime.Now}] {message}");
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
                Console.WriteLine($"add hyperlink: {url}");
            }
        }
        class PresentationObject

        {
            public int Width { get; set; }
            public int Height { get; set; }
            public void Copy()
            {
                Console.WriteLine("copy");

            }
            public void Duplicate()
            {
                Console.WriteLine("duplicate");

            }

        }

        #endregion

        private static void draftie()
        {
            #region Person Class 
            Console.WriteLine(new StringBuilder().Append('-', 20));
            Console.WriteLine("Hello, World!");
            var p1 = Person.Parse("Joe", 12);
            Console.WriteLine(p1);
            Console.WriteLine(new StringBuilder().Append('-', 20));
            var p2 = new Person { Name = "Biden", Age = 101 };
            p2.friends.Add(p1);
            Console.WriteLine(p2);
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