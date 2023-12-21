using Data.Entities;

namespace Data
{
    internal static class DbReader
    {
        public static Memory<IpRange> GetIpRanges(uint offset, uint records, BinaryReader reader)
        {
            reader.BaseStream.Seek(offset, SeekOrigin.Begin);
            Memory<IpRange> ranges = new IpRange[records];
            //var ranges = new IpRange[records];
            for (var i = 0; i < records; i++)
            {
                ranges.Span[i] = new IpRange(ipFrom: reader.ReadUInt32(),
                                        ipTo: reader.ReadUInt32(),
                                        index: reader.ReadUInt32());
            }

            return ranges;
        }

        public static Memory<Location> GetLocations(uint offset, uint records, BinaryReader reader)
        {
            reader.BaseStream.Seek(offset, SeekOrigin.Begin);
            Memory<Location> locations = new Location[records];
            //Span<Location> locations = new Location[records];
            for (var i = 0; i < records; i++)
            {
                locations.Span[i] = new Location(country: new string(reader.ReadChars(8)).TrimEnd('\0'),
                                            region: new string(reader.ReadChars(12)).TrimEnd('\0'),
                                            postal: new string(reader.ReadChars(12)).TrimEnd('\0'),
                                            city: new string(reader.ReadChars(24)).TrimEnd('\0'),
                                            organization: new string(reader.ReadChars(32)).TrimEnd('\0'),
                                            latitude: reader.ReadSingle(),
                                            longitude: reader.ReadSingle());
            }

            return locations;
        }

        //public static Location[] GetLocations(uint offset, uint records, BinaryReader reader)
        //{
        //    reader.BaseStream.Seek(offset, SeekOrigin.Begin);
        //    var locations = new Location[records];
        //    for (var i = 0; i < records; i++)
        //    {
        //        locations[i] = new Location(country: new string(reader.ReadChars(8)).TrimEnd('\0'),
        //                                    region: new string(reader.ReadChars(12)).TrimEnd('\0'),
        //                                    postal: new string(reader.ReadChars(12)).TrimEnd('\0'),
        //                                    city: new string(reader.ReadChars(24)).TrimEnd('\0'),
        //                                    organization: new string(reader.ReadChars(32)).TrimEnd('\0'),
        //                                    latitude: reader.ReadSingle(),
        //                                    longitude: reader.ReadSingle());
        //    }

        //    return locations;
        //}

        public static Memory<uint> GetLocationIndexes(uint offset, uint records, BinaryReader reader)
        {
            reader.BaseStream.Seek(offset, SeekOrigin.Begin);

            Memory<uint> indexes = new uint[records];
            //var indexes = new uint[records];
            for (var i = 0; i < records; i++)
                indexes.Span[i] = reader.ReadUInt32() / 96;

            return indexes;
        }
    }
}
