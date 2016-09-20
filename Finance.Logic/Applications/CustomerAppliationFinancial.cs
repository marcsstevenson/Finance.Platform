namespace Finance.Logic.Applications
{
    /// <summary>
    /// A name and dollar value of an application financial option
    /// </summary>
    public class CustomerAppliationFinancial: AppliationFinancial
    {
        public CustomerApplication CustomerApplication { get; set; }
    }
}
