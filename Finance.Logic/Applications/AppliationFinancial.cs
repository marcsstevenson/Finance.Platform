using System.ComponentModel.DataAnnotations;
using Generic.Framework.AbstractClasses;

namespace Finance.Logic.Applications
{

    /// <summary>
    /// A name and dollar value of an application financial option
    /// </summary>
    public abstract class AppliationFinancial : Entity
    {
        /// <summary>
        /// A name an application financial option
        /// <see cref="AppliationFinancialOption"/>
        /// </summary>
        [Required]
        public string OptionName { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public AppliationFinancialType AppliationFinancialType { get; set; }
    }
}
