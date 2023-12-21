namespace Data.Entities
{
    public class IpRange
    {
        public IpRange(uint ipFrom, uint ipTo, uint index)
        {
            IpFrom = ipFrom;
            IpTo = ipTo;
            Index = index;
        }

        public uint IpFrom { get; }
        public uint IpTo { get; }
        public uint Index { get; }
    }
}
