using System.Collections;

namespace FlyWeightExample;

interface IChar
{
    char Symbol { get; set; }
    int Size { get; set; }

    void Draw();
}

class MyChar : IChar
{
    public char Symbol { get; set; }
    public int Size { get; set; }

    public MyChar(char s, int z)
    {
        Symbol = s;
        Size = z;
    }

    public void Draw() => Console.WriteLine($"{Symbol} as {Size} points");
}
class Factory
{
    int size;
    Hashtable chars;

    public Factory(int size = 12)
    {
        this.size = size;
        chars = new Hashtable();
    }

    public MyChar GetChar(char key)
    {
        MyChar mc = chars[key] as MyChar;

        if (mc == null)
        {
            mc = new MyChar(key, size);
            chars.Add(key, mc);
        }

        return mc;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Flyweight";
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.Black;
        // We can save lots of RAM assuming our program has a lot of similar objects.
        string s = "dsSSWdsd";

        Factory f = new();

        foreach (var item in s)
            f.GetChar(item).Draw();

        Console.WriteLine("\n\n\n");

        Factory f2 = new(24);

        foreach (var item in s)
            f2.GetChar(item).Draw();

        Console.Read();
    }
}
