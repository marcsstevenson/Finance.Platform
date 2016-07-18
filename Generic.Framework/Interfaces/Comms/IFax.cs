namespace Generic.Framework.Interfaces.Comms
{
    public interface IFax
    {
        /// <summary>
        /// Phone number fields
        /// </summary>
        string FaxCountry { get; set; }
        string FaxArea { get; set; }
        string FaxNumber { get; set; }
    }
}