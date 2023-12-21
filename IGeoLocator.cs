using Data.Entities;

namespace GeoLocator
{
    public interface IGeoLocator
    {
        Location GetLocationsByIp(ulong ip);

        Location GetLocationsByCity(string city);
    }
}
