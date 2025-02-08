namespace Series1.human;
// Interal = assembly lvl (bunch of namespaces)
public class Person
{
  public string Name { get; set; }
  public int Age { get; set; }
  public Person(string a, int b)
  {
    Name = a;
    Age = b;
  }
  public void introduce()
  {
    Console.WriteLine($"Hi, my name is {Name} and I'm {Age} years old.");
  }
}