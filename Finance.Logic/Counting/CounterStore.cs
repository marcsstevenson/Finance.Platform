using Generic.Framework.AbstractClasses;

namespace Finance.Logic.Counting
{
    public class CounterStore : Entity
    {
        public int CustomerCounter { get; set; } = 0;
        public int DealCounter { get; set; } = 0;
        //public int CustomerApplication { get; set; } = 0;
        public int PersonalApplicationCounter { get; set; } = 0;
    }
}
