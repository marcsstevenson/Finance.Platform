namespace Generic.Framework.Interfaces
{
    public interface IBankAccount
    {
        string BankingCompany { get; set; }
        string BankAccountName { get; set; }
        string BankBranchName { get; set; }
        string BankAccountNumber { get; set; }
    }
}