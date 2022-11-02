namespace KickScooters
{
    public class OutputData
    {
        public string AmountLine { get; set; }
        public Line[] Lines { get; set; }
    }
    public class Line
    {
        public string AmountPoints { get; set; }
        public int[] IndexPoints { get; set; }
    }
}
