using System.ComponentModel;

namespace Finance.Logic.Shared.Enums
{
    public enum ResidencyOption
    {
        [Description("Resident")]
        Resident,
        [Description("Work Visa")]
        WorkVisa,
        [Description("No Work Visa")]
        NoWorkVisa
    }
}