using System.ComponentModel;

namespace Finance.Logic.Applications.PersonalApplications
{
    public enum PersonalApplicationStatus
    {
        [Description("Customer Query")]
        CustomerQuery = 0,
        [Description("Received")]
        Received = 5,
        [Description("Completed")]
        Completed = 15,
        [Description("Submitted")]
        Submitted = 20,
        [Description("Approved")]
        Approved = 25,
        [Description("Declined")]
        Declined = 30,
        [Description("Not Proceeding")]
        Cancelled = 35
    }
}
