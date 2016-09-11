using Finance.Logic.Shared.Enums;

namespace Finance.Logic.Shared.Interfaces
{
    public interface IDiversLicenceDetails
    {
        DiversLicenceOption DiversLicenceStatus { get; set; }
        /// <summary>
        /// If DiversLicenceStatus = Overseas then this is needed.
        /// </summary>
        string OverseasDiversLicence { get; set; }

        string LicenceNumberSa { get; set; }

        string LicenceNumberSb { get; set; }
    }
}