namespace Grafica_lab2;

public class MyService
{
    public static string[] ReadLinesFromFile(string filePath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            return lines;
        }
        catch (IOException e)
        {
            Console.WriteLine(e);
            throw;
        }
    } 
}