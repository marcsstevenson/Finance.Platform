using System.ComponentModel;

namespace Finance.Logic.Crm
{
    public enum AddressArrangement
    {
        [Description("Own Home")]
        OwnHome,
        [Description("Renting")]
        Renting,
        [Description("Boarding")]
        Boarding,
        [Description("Family Home")]
        FamilyHome,
        [Description("Other")]
        Other
    }
}
