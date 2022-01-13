var x = new Utils();

while (true)
{
    x.Write();
    System.Threading.Thread.Sleep(1000);
}

public class Utils{
    public void Write()
    {
        Console.WriteLine("hello");
    }
}