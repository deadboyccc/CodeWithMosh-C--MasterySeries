using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;

namespace series3;
class Program
{
    static void Main(string[] args)
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