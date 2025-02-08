internal partial class Program
{
  private static void Main(string[] args)
  {
    Console.WriteLine("1-1 was a course intro");
    Console.WriteLine("1-2 talks about .net architecture, c# vs .net and the CLR and IR defs");
    Console.WriteLine("assemblies -> namespaces -> classes(building unit)");
    Console.WriteLine("C# -> IR code ->CLR is like the jvm");
    System.Console.WriteLine("cw -> cw snippet");
    Console.Beep(); // windows specific 
    byte test = 255;
    ++test;
    Console.WriteLine($"The value of test is {++test}");
    // overflowing is kinda non-UB so it kinda loops back to the lowest value
    test = 255;
    checked
    {

      try
      {
        test++;
      }
      catch (System.Exception)
      {

        throw new Exception("Joe Biden");
      }
      finally
      {
        Console.WriteLine($"The value of test is {test}");
      }
    }
  }
}