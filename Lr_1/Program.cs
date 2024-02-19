/// <summary>
/// Коментарі для створення XML-документації.
/// </summary>

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");

        Hello hello = new Hello();

        hello.SayHello();
    }
}

class Hello
{
    public void SayHello()
    {
        Console.WriteLine("Hello!");
    }
}
