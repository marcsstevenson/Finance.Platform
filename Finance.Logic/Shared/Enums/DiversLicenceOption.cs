using System.ComponentModel;

namespace Finance.Logic.Shared.Enums
{
    public enum DiversLicenceOption
    {
        [Description("Full")]
        Full,
        [Description("Restricted")]
        Restricted,
        [Description("Learners")]
        Learners,
        [Description("Overseas")]
        Overseas
    }
}