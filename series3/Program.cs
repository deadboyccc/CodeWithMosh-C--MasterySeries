namespace series3;

class Program
{
    static void Main(string[] args)
    {
        #region lambda
        #endregion

    }

    /*
    -Summary of delegates: an object that knows how to excute 1 or more function pointers (functions=methods int his context)
    -used in event-driven patterns
    */
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
