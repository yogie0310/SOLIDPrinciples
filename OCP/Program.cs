namespace OCP
{
    /* We have a membership class with GetTraining method. No of trainings are decided on membership type. New training types can be added with if else but
      it will voilate OCP which says if a class is crated and tested it should be closed for modification. 

    public class Membership
    {
        public int MembershipType { get; set; }
        public void Add()
        {
            // code to add the member to membership table
        }
        public int GetTraining()
        {
            if (MembershipType == 1) { return 10; } // Silver
            else if (MembershipType == 2) { return 20; } // Gold
            else if (MembershipType == 3) { return 20; } // Platinum
            else { return 2; }
        }
    } */

    /* Solution to the above problem is to create a base class and child membership type child classes */

    public class Membership
    {
        
        public void Add()
        {
            // code to add the member to membership table
        }
        public virtual int GetTraining()
        {
            return 2; 
        }
    }

    public class SilverMembership : Membership
    {
        public override int GetTraining()
        {
            return 10;
        }
    }

    public class GoldMembership : Membership
    {
        public override int GetTraining()
        {
            return 20;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Membership obj = new SilverMembership();
            int res = obj.GetTraining();
            Console.WriteLine(res);
            Console.WriteLine("Hello, World!");
        }
    }
}