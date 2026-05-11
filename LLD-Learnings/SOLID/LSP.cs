interface DepositOnlyAccount
{
    void Deposit(decimal amount);
}
interface WithdrawOnlyAccount
{
    void Withdraw(decimal amount);
}
public class SavingsAccount : WithdrawOnlyAccount
{
    private decimal balance;

    public SavingsAccount(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public void Withdraw(decimal amount)
    {
        if (amount > balance)
        {
            Console.WriteLine("Insufficient funds!");
            return;
        }
        balance -= amount;
        Console.WriteLine($"Withdrew {amount}. New balance: {balance}");
    }
}
public class FixedDepositAccount : DepositOnlyAccount
{
    private decimal balance;
    public FixedDepositAccount(decimal initialBalance)
    {
        balance = initialBalance;
    }
    public void Deposit(decimal amount)
    {
        balance += amount;
        Console.WriteLine($"Deposited {amount}. New balance: {balance}");
    }

}

public class LSP
{
    public static void Main(String[] args)
    {
        DepositOnlyAccount depositAccount = new FixedDepositAccount(1000);
        depositAccount.Deposit(500); // Works fine
        WithdrawOnlyAccount withdrawAccount = new SavingsAccount(1000);
        withdrawAccount.Withdraw(200); // Works fine
        
    }
}