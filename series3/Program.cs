using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;

namespace series3;
class Program
{
    static void Main(string[] args)
    {

    }
    private static void ExceptionHandling()
    {
        StreamReader? streamReader = null;
        try
        {
            streamReader = new StreamReader("./data.txt");
            string? line;
            while ((line = streamReader.ReadLine()) != null)
            {
                Console.WriteLine(line?.Shortern(5));
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Closing the file...");
            streamReader?.Close();

        }
        // the more cleaner way using (using) xD
        try
        {
            using (var streamReaderClean = new StreamReader("./data.txt"))
            {
                string? line;
                while ((line = streamReaderClean.ReadLine()) != null)
                {
                    Console.WriteLine(line?.Shortern(5));
                }
            }

        }
        catch (System.Exception)
        {
            Console.WriteLine("An error occurred while reading the file.");
        }
    }

    private static void NoWay()
    {
        dynamic a = 10;
        a = "hello";
    }

    private static void NullableTypes()
    {
        // could be null - encapsulate the value type into a nullable type which can be null
        Nullable<DateTime> date1 = new DateTime(2022, 10, 10);
        // shorthand for Nullable<T> --> valueType?
        DateTime? date2;
        date2 = date1 ?? DateTime.Today;
        Console.WriteLine(date1.GetValueOrDefault()); // will print 2022-10-10
    }

    private static void LINQ()
    {
        var bookList = new BookList()
        {
            Books = new List<Book>(){
                new Book(10, "Book 1"),
                new Book(20, "Book 2"),
                new Book(30, "Book 3"),
                new Book(40, "Book 4"),
                new Book(50, "Book 5"),
            }
        };
        IEnumerable<Book> EnuList = bookList.GetBooks();
        var newList = EnuList.Where(book => book.Price < 31).OrderBy(book => book.Price).Select(book => book.Title);
        foreach (var book in newList)
        {
            Console.WriteLine(book);
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public Book(int a, string b)

        {
            Title = b;
            Price = a;

        }
    }
    public class BookList
    {
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
        public void AddBook(Book book)
        {
            Books = Books.Append(book);
        }
        public IEnumerable<Book> GetBooks()
        {
            return Books;
        }
    }

    private static void ExtentionMethods()
    {
        System.Console.WriteLine(new string("a b c d e ").Shortern(2));
    }

    private static void DelegatesEvents()
    {
        // delegate Action
        Action<int> lamba1 = (int a) => Console.WriteLine(a);
        // delgate func
        Func<int, int> lambda2 = (int a) => a * 2;


        Console.WriteLine(new StringBuilder().Append('-', 20).ToString());
        var video = new Video("New1");
        var mailService = new MailService(); //sub
        var smsService = new SMSService(); //sub
        var videoEncoder = new VideoEncoder();//publisher
        videoEncoder.VideoEncoded += smsService.SendSMS;
        videoEncoder.VideoEncoded += mailService.SendMail;
        videoEncoder.Encode(video);
        Console.WriteLine(new StringBuilder().Append('-', 20).ToString());
    }


    public class VideoEncodingEventArgs : EventArgs
    {
        public Video Video { get; set; }
        public VideoEncodingEventArgs(Video v)
        {
            Video = v;
        }

    }
    public class Video
    {
        public string Title { get; set; }
        public Video(string t)
        {
            Title = t;

        }
    }
    public class MailService
    {
        public void SendMail(object? sender, VideoEncodingEventArgs e)
        {
            // sending mail to subscribers [pubsub pattern between classes]
            //simple log
            Console.WriteLine($"Sending mail notification to subscribers [Video Title]:[{e.Video.Title}]");
        }
    }
    public class SMSService
    {
        public void SendSMS(object? sender, VideoEncodingEventArgs e)
        {
            // sending sms to subscribers [pubsub pattern between classes]
            // simple log that includ
            Console.WriteLine($"Sending SMS notification to subscribers [Video Title]:[{e.Video.Title}]");


        }
    }

    public class VideoEncoder
    {
        //1- Delegate
        public delegate void VideoEncodedEventHandler(object sender, VideoEncodingEventArgs e);
        //2- Event

        // instead of creating the delegate manually u can use the EventHanlder Generic helper
        public event EventHandler<VideoEncodingEventArgs>? VideoEncoded;
        public void Encode(Video video)
        {
            Console.WriteLine($"Encoding {video.Title}");
            Thread.Sleep(800); // simulating encoding time
            OnVideoEncoded(new VideoEncodingEventArgs(video));

        }

        protected virtual void OnVideoEncoded(VideoEncodingEventArgs e)
        {
            VideoEncoded?.Invoke(this, e);
        }
    }

    private static void clicky()
    {
        var btn = new Button();
        // click being the event
        // event hanlders that follow the PREDEFINED sender , eventargs 
        btn.Click += (sender, e) => Console.WriteLine("Button clicked using lambda 0| ");
        btn.Click += (sender, e) => Console.WriteLine("Button clicked using lambda 1| ");
        btn.Click += (sender, e) => Console.WriteLine("Button clicked using lambda 2| ");

        // call the event handler directly
        // btn.OnClickHandler(btn, EventArgs.Empty);

        // calling the eventHanlder witht a method
        btn.SimulateClick();
    }

    public class Button
    {
        public event EventHandler? Click;
        public void OnClickHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Button cliked!");
            // invoking the Event (running all the delegate functions attached to it) 
            // e being the args, this = the sender (the same obj)
            Click?.Invoke(this, e);
        }
        public void SimulateClick()
        {
            OnClickHandler(this, EventArgs.Empty);
        }
    }

    private static void Lambda()
    {
        #region lambda
        Func<int, int> square = (num) => num * num;
        Console.WriteLine(square(10));
        var books = new List<Product>{
            new Product{Name="Book1", Price=1},
            new Product{Name="Book2", Price=2},
            new Product{Name="Book3", Price=3},
            new Product{Name="Book4", Price=4},
            new Product{Name="Book5", Price=5},
        };
        var cheapBooks = books.FindAll(product => product.Price <= 2);
        cheapBooks.ForEach((item) => Console.WriteLine(item.Price));

        #endregion
    }

    /*
    -Summary of delegates: an object that knows how to excute 1 or more function pointers (functions=methods int his context)
    -used in event-driven patterns
    */
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Product()
        {
            Name = "default";
            Price = 0;
        }

    }
    private static void Delegates()
    {
        Photo photo = new Photo("photo.jpg");
        PhotoProcessor processor = new PhotoProcessor();
        // delegate will excute all these function pointers when called
        // THEY DON'T EXCUTE IN ORDER - AND RE-ASSIGNING THEM = OVERWRITE
        // delegate type = adding function/s
        Action<Photo> groupOfHanlders = PhotoFilters.ApplySharpnessFilter;
        groupOfHanlders += PhotoFilters.ApplyBrightnessFilter;
        groupOfHanlders += PhotoFilters.ApplyColorFilter;
        // adding an extention custom filter (the purpose of delegates is to add extensibility without recompiling the lib/framework)
        groupOfHanlders += CustomFilter;

        // calling them using a method
        processor.ProcessImage(photo, groupOfHanlders);
    }

    public static void CustomFilter(Photo photo)
    {
        Console.WriteLine("Applying custom filter to photo: " + photo.Path);
    }

    public class Photo
    {
        public string Path { get; set; }
        public Photo(string a)
        {
            Path = a;
        }
    }
    public class PhotoProcessor
    {
        // both have many overloads 
        // System.action<input type> : void
        // System.Func<input type, return type> : return type
        #region removing the deligate
        // public delegate void PhotoFilterHandler(Photo photo);
        #endregion
        // delegates = one filter or many that will be excuted and can be extensible as long as they follow
        // the delegate signature (function pointer cpp)
        public void ProcessImage(Photo photo, Action<Photo> FilterHanlderToApply)
        {
            FilterHanlderToApply(photo);
        }

    }
    public class PhotoFilters
    {
        public static void ApplyBrightnessFilter(Photo photo)
        {
            Console.WriteLine("Applying brightness filter to photo: " + photo.Path);
        }
        public static void ApplySharpnessFilter(Photo photo)
        {
            Console.WriteLine("Applying sharpness filter to photo: " + photo.Path);
        }
        public static void ApplyColorFilter(Photo photo)
        {
            Console.WriteLine("Applying color filter to photo: " + photo.Path);
        }
    }
    private static void Generics()
    {
        #region Generics
        Console.WriteLine("advanced C# - generics");
        Dict<string, string> dict = new();
        dict.Add("key1", "value1");
        Console.WriteLine(dict.Get("key1"));
        var max = Utils<int>.Max(10, 30);
        Console.WriteLine(max);
        #endregion
    }

    // where Template : IInterface  - impelments an interface
    // where Tempate: LivingBeing - LivingBeing class or it's sub classes 
    // where Template : struct (valueType)
    // where Template: class (ref type)
    // where Template : new() - Template hs to be a class with default constructor new()

    public class Dict<Keytype, ValueType> where Keytype : notnull
    {
        private readonly Dictionary<Keytype, ValueType> dict = new();
        public void Add(Keytype key, ValueType value)
        {
            dict.Add(key, value);
        }
        public ValueType Get(Keytype key)
        {
            return dict[key];
        }
        public void test()
        {
            throw new NotImplementedException();
        }
    }
    public class Utils<T> where T : IComparable
    {
        public static T Max(T firstItem, T secondItem)
        {
            return firstItem.CompareTo(secondItem) > 0 ? firstItem : secondItem;
        }
    }
}

#region Extension Methods
// convention : Static class 
public static class RichString
{
    public static string Shortern(this String str, int wordCount)
    {
        var words = str.Split(' ');
        if (wordCount == 0)
            return "";
        if (words.Length < wordCount)
            return str;

        if (words.Length > wordCount)
        {
            var newWordsArr = words.Take(wordCount);
            return string.Join(" ", newWordsArr);
        }

        return str;
    }
}
#endregion