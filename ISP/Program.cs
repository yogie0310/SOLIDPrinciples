namespace ISP
{
    /*New Live training is introduced for new clients. As old clients do not need this, this will be handled through separate interface*/
    public interface ITraining
    {
        int GetTraining();
    }
    public interface IMembership : ITraining
    {
        void Add();
    }

    public interface ILiveTraining : IMembership
    {
        int GetLiveTraining(); 
    }

    public  class Membership : IMembership, ILiveTraining
    {
        public virtual void Add()
        {
            // code to add members to databse
        }

        public virtual int GetTraining()
        {
            return 2;
        }

        int ILiveTraining.GetLiveTraining()
        {
            return 1; // Live training
        }
    }
    public class SilverMembership : Membership
    {
        public override void Add()
        {
            // code to add members to databse
        }
        public override int GetTraining()
        {
            return 10;
        }
    }

    public class GoldMembership : Membership
    {
        public override void Add()
        {
            // code to add members to databse
        }
        public override int GetTraining()
        {
            return 20;
        }
    }

    public class TrailMembership : ITraining
    {
        int ITraining.GetTraining()
        {
            return 2;
        }
    }

    public class PremiumMembership : Membership, ILiveTraining
    {
        public override void Add()
        {
            // To add
        }

        public override int GetTraining()
        {
            return 10;
        }
        public int GetLiveTraining()
        {
            return 20;
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // 100 old clients : self paced
            IMembership mem1 = new Membership();
            mem1.Add();


            // new clients : Live Training + Self paced
            ILiveTraining mem2 = new PremiumMembership();
            mem2.Add(); 
            mem2.GetLiveTraining();

            Console.WriteLine("Hello, World!");
        }
    }
}