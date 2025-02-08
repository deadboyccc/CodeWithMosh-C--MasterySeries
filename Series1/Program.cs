using System;
using System.Runtime.InteropServices;
using System.Text;
using Series1.human;
using Series1.mathTest;

namespace Series1;
internal partial class Program
{
  private static void Main(string[] args)
  {
    Console.WriteLine(new StringBuilder().Append('*', 12));
    #region dealWithFiles
    var filePathEx = "./data/test.txt";
    if (File.Exists(filePathEx))
    {
      // write a aggregate function to count how many "F" or "f" in the text
      var text = File.ReadAllText(filePathEx);
      int count = text.Aggregate(0, (acc, c) => (c == 'F' || c == 'f') ? acc + 1 : acc);

      System.Console.WriteLine(text.ElementAt(0));
    }
    if (Directory.Exists("."))
    {
      var files = Directory.GetFiles(".", "*.cs");
      foreach (var file in files)
      {
        System.Console.WriteLine(file);
      }
      var CurrentDirectory = Directory.GetCurrentDirectory();
      System.Console.WriteLine($"cwd : {CurrentDirectory}");
    }
    // path parse
    #region Path
    Console.WriteLine(Path.GetExtension("program.cpp").Substring(1));
    #endregion

    #endregion
    // cleanCodeBestPractices();
  }

  private static void cleanCodeBestPractices()
  {
    Console.WriteLine(new StringBuilder().Append('*', 12));
    Series1.types.Enu testEnum = types.Enu.Three;
    System.Console.WriteLine(testEnum);
    System.Console.WriteLine((uint)testEnum);
    var test = 2;
    System.Console.WriteLine((types.Enu)test);
    // returns an object cast it to the type of 
    var finalResult = (Series1.types.Enu)Enum.Parse(typeof(Series1.types.Enu), "One");
    System.Console.WriteLine("---------");
    System.Console.WriteLine("---------");
    System.Console.WriteLine(finalResult);
    var date = DateTime.Now;
    var duration = new TimeSpan(1, 2, 3);
    Console.WriteLine(new StringBuilder().Append('*', 12));
    System.Console.WriteLine(date.ToString("HH"));
    System.Console.WriteLine("---------");
    System.Console.WriteLine("---------");
    var p1 = new Person("Ahmed", 99);
    Console.WriteLine(mathTest.Math.Add(1, p1.Age));
    Console.WriteLine("1-1 was a course intro");
    Console.WriteLine("1-2 talks about .net architecture, c# vs .net and the CLR and IR defs");
    Console.WriteLine("assemblies -> namespaces -> classes(building unit)");
    Console.WriteLine("C# -> IR code ->CLR is like the jvm");
    System.Console.WriteLine("cw -> cw snippet");
    Console.Beep(); // windows specific 
    byte testByte = 255;
    ++testByte;
    Console.WriteLine($"The value of test is {++testByte}");
    // overflowing is kinda non-UB so it kinda loops back to the lowest value
    testByte = 255;
    checked
    {

      try
      {
        testByte++;
      }
      catch (System.Exception)
      {

        throw new Exception("Joe Biden");
      }
      finally
      {
        Console.WriteLine($"The value of test is {testByte}");
      }
    }
  }
}