namespace SRP
{

    /* This membership class has the resposiblity to add member to membership table and additional responsibility of logging error. This is the voilatio of SRP.
    public class Membership
    {
        public void Add()
        {
            try
            {
                // code to add the member to membership table
            }
            catch (Exception ex)
            {
                File.WriteAllText(@"C:\Error.txt", ex.Message);
            }
        }
    } */

    /* Solution to the above problem is to create a separate class for error handling. */
    public class Membership
    {
        public void Add()
        {
            try
            {
                // code to add the member to membership table
            }
            catch (Exception ex)
            {
                //FileLogger logger = new FileLogger(); // We can create normal FileLogger class, create object and call the logError method
                //logger.LogError();

                // Or we can mark the FileLogger class static and call the logError method with class name
                FileLogger.LogError(ex.Message);
            }
        }
    }

    public static class FileLogger
    { 
        public static void LogError(string error)
        {
            File.WriteAllText(@"C:\Error.txt", error);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}