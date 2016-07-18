namespace Generic.Framework.Interfaces.Comms
{
    public interface IPhone
    {
        /// <summary>
        /// Phone number fields
        /// </summary>
        string PhoneCountry { get; set; }
        string PhoneArea { get; set; }
        string PhoneNumber { get; set; }
    }
}