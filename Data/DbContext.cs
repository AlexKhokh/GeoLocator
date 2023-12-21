using Data.Entities;

namespace Data
{
    public class  DbContext
    {     

        public Header Header { get; set; }

        public Memory<IpRange> IpRanges { get; set; }

        public Memory<Location> Locations { get; set; }

        public Memory<uint> Indexes { get; set; }
    }
}