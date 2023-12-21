using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Header
    {
        public Header(int version,
            string name,
            ulong timestamp,                       
            uint records,
            uint offsetRanges,
            uint offsetCities,                        
            uint offsetLocations
            )
        {
            Version = version;
            Timestamp = timestamp;
            Name = name;
            Records = records;
            OffsetCities = offsetCities;
            OffsetLocations = offsetLocations;
            OffsetRanges = offsetRanges;
        }
        public int Version { get; }
        public ulong Timestamp { get; }
        public string Name { get; }
        public uint Records { get; }
        public uint OffsetCities { get; }
        public uint OffsetLocations { get; }
        public uint OffsetRanges { get; }              
    }
}
