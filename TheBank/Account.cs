namespace TheBank
{
    public abstract class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public AccountType Type { get; set; }
        public abstract void ChargeInterest();
    }
    public class Checking : Account
    {
        decimal interest = 1.005M;
        public override void ChargeInterest()
        {
            Balance *= interest;
        }
    }
    public class Savings : Account
    {
        decimal interest1 = 1.01M;
        decimal interest2 = 1.02M;
        decimal interest3 = 1.03M;
        public override void ChargeInterest()
        {
            if (Balance <= 100000)
            {
                if (Balance <= 50000)
                {
                    Balance *= interest1;
                }
                else
                {
                    Balance *= interest2;
                }
            }
            else
            {
                Balance *= interest3;
            }
        }
    }
    public class Consumer : Account
    {
        decimal interest = 1.001M;
        decimal minusInterest = 1.2M;
        public override void ChargeInterest()
        {
            if (Balance > -1)
            {
                Balance *= interest;
            }
            else
            {
                Balance *= minusInterest;
            }
        }
    }
   
}
