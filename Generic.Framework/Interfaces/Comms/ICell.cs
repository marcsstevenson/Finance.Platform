namespace Generic.Framework.Interfaces.Comms
{
    public interface ICell
    {
        /// <summary>
        /// Cell number fields
        /// </summary>
        string CellCountry { get; set; }
        string CellArea { get; set; }
        string CellNumber { get; set; }
    }
}