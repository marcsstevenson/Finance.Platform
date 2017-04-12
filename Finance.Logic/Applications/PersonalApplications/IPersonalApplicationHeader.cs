namespace Finance.Logic.Applications.PersonalApplications
{
    public interface IPersonalApplicationHeader
    {
        string FirstName { get; set; }
        string PreferredName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string MobilePhoneNumber { get; set; }
        string HomePhoneNumber { get; set; }
        string LicenceNumberSa { get; set; }
        string PersonalEmail { get; set; }
        string BusinessEmail { get; set; }
    }
}
