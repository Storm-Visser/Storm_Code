public class test{
private static int Printer(int j)
    {
     for (var i = j; i > 0; i = Printer(i - 1))
     {
          Console.Write(i);
     }
     return j;
    }
}