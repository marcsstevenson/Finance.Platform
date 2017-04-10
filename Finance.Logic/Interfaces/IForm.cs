namespace Finance.Logic.Interfaces
{
    public interface IForm
    {
        string SchemaVersion { get; set; }
        string JsonData { get; set; }
    }
}
