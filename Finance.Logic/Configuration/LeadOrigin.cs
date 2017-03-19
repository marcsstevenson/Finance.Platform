using Generic.Framework.AbstractClasses;
using Generic.Framework.Interfaces;

namespace Finance.Logic.Configuration
{
    public class LeadOrigin : Entity, IName, IIsDefault
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
    }
}
