namespace Finance.Logic.Shared.Interfaces
{
    public interface IOccupationalDetails
    {
        string OccupationEmployer { get; set; }
        string Occupation { get; set; }
        string OccupationAddressStreet { get; set; }
        string OccupationAddressSuburb { get; set; }
        string OccupationAddressPostcode { get; set; }
        string OccupationAddressCity { get; set; }
        int? OccupationDurationInMonths { get; set; }
    }
}
