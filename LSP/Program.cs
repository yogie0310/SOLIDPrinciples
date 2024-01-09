namespace LSP
{
    /*Solution is don by creating separate interfaces for commom and uncommon methods 
    public class Membership
    {
        public virtual void Add()
        {
            // code to add the member to membership table
        }
        public virtual int GetTraining()
        {
            return 5;
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

    public class TrailMembership : Membership // In continuation to LSP , new type Trail membership is added, which will get 2 trainings but data is not added to DB
    {
        public override void Add()
        {
           throw new NotImplementedException("Trail user cannot be saved in DB");
        }
        public override int GetTraining()
        {
            return 2;
        }
    } */

    public interface ITraining
    {
        int GetTraining();
    }
    public interface IMembership : ITraining
    {
        void Add();
    }

    public class Membership : IMembership
    {
        public virtual void  Add()
        {
            // code to add members to databse
        }

        public virtual int GetTraining()
        {
            return 2;
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


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Membership> membershipsList = new List<Membership>();
            membershipsList.Add(new SilverMembership());
            membershipsList.Add(new GoldMembership());
            //membershipsList.Add(new TrailMembership()); // this is removed after implementing of LSP becuase Trail class is no more extension of Membership class
            
            ITraining obj = new TrailMembership();
            obj.GetTraining();

            /* this will break the code for trail membership because add method is not implemented. Solution will be to create the separate interfaces
             one interface for commom method (Add) and another interface for uncommon method (GetTraining)*/
            foreach (var item in membershipsList)
            {
                item.Add();
            }

            Console.WriteLine("Hello, World!");
        }
    }
}