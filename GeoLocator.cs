using Data;
using Data.Entities;

namespace GeoLocator
{
    public class GeoLocator 
        //: IGeoLocator
    {
        private readonly DbContext _context;

        public GeoLocator(DbContextBuilder builder)
        {
            _context = builder.GetContext();
        }

        //public Location GetLocationsByCity(string city)
        //{
        //    var first = 0;
        //    var last = _context.Indexes.Length - 1;

        //    while (true)
        //    {
        //        if (last - first == 1)
        //        {
        //            var lastValue = _context.Indexes[last];
        //            var firstValue = _context.Indexes[first];

        //            if (string.Equals(city, _context.Locations[lastValue].City, StringComparison.Ordinal))
        //            {
        //                return _context.Locations.ElementAt((int)lastValue);
        //            }

        //            if (string.Equals(city, _context.Locations[firstValue].City, StringComparison.Ordinal))
        //            {
        //                return _context.Locations[firstValue];
        //            }                    
        //        }
        //        else
        //        {

        //            var middle = first + (last - first) / 2;

        //            var midIdx = _context.Indexes[middle];

        //            var middleLocation = _context.Locations[midIdx];

        //            if (string.Equals(city.Trim(), middleLocation.City.Trim(), StringComparison.Ordinal))
        //            {
        //                return middleLocation;
        //            }

        //            var result = string.Compare(middleLocation.City.TrimEnd(), city.TrimEnd(), StringComparison.Ordinal);
        //            if (result > 0)
        //            {
        //                last = middle;
        //            }
        //            else
        //            {
        //                first = middle;
        //            }
        //        }
        //    }
        //}

        //public Location GetLocationsByIp(ulong ip)
        //{
        //    var first = 0;
        //    var last = _context.IpRanges.Length - 1;


        //    while (true)
        //    {
        //        if (last - first == 1)
        //        {
        //            var lastRange = _context.IpRanges[last];
        //            var firstRange = _context.IpRanges[first];

        //            if (ip >= lastRange.IpFrom && ip <= lastRange.IpTo)
        //            {
        //                return _context.Locations[lastRange.Index];
        //            }
        //            if (ip >= firstRange.IpFrom && ip <= firstRange.IpTo)
        //            {
        //                return _context.Locations[firstRange.Index];
        //            }
        //        }
        //        else
        //        {

        //            int middle = first + (last - first) / 2;

        //            var midRange = _context.IpRanges[middle];

        //            if (ip >= midRange.IpFrom && ip <= midRange.IpTo)
        //            {
        //                return _context.Locations[midRange.Index];
        //            }

        //            if (ip < midRange.IpFrom)
        //            {
        //                last = middle;
        //            }
        //            else
        //            {
        //                first = middle;
        //            }
        //        }
        //    }
        //}
    }
}
