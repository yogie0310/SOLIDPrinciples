namespace DIP
{
    /*Here high level module (Membership class) is dependent on low level module (File logger class). By module we mean concrete classes. It should be dependent on 
     the abstraction. Abstraction is achieved  through interface.
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
                FileLogger logger = new FileLogger();
                logger.LogError(ex.ToString());
            }
        }
    }
    public class FileLogger
    {
        public  void LogError(string error)
        {
            File.WriteAllText(@"C:\Error.txt", error);
        }
    }  */


    public class Membership
    {
        Ilogger logger;

        //This correct but not a better approach. Also it is breaking OCP
        /*public Membership()
        {
            // TO DO: read from config file

            int config = 1;
            if (config == 1)
            {
                logger = new FileLogger();
            }
            else
            {
                logger = new ConsoleLogger();
            }
        } */

        // Below is the better approach

        public Membership(Ilogger _logger)
        {
            logger= _logger;
        }

        public void Add()
        {
            try
            {
                // code to add the member to membership table
            }
            catch (Exception ex)
            {
                FileLogger logger = new FileLogger();
                logger.LogError(ex.ToString());
            }
        }
    }

    public interface Ilogger
    {
        void LogError(string message);
    }
    public class FileLogger : Ilogger
    {
        public void LogError(string error)
        {
            File.WriteAllText(@"C:\Error.txt", error);
        }
    }

    public class ConsoleLogger : Ilogger
    {
        public void LogError(string error)
        {
            Console.WriteLine($"Error: {error}");
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