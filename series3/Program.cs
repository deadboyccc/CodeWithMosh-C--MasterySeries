namespace series3;

class Program
{
    static void Main(string[] args)
    {
        Photo photo = new Photo("photo.jpg");
        PhotoProcessor processor = new PhotoProcessor();
        processor.ProcessImage(photo, PhotoFilters.ApplySharpnessFilter);


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
        public delegate void PhotoFilterHandler(Photo photo);
        // delegates = one filter or many that will be excuted and can be extensible as long as they follow
        // the delegate signature (function pointer cpp)
        public void ProcessImage(Photo photo, PhotoFilterHandler FilterHanlderToApply)
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
