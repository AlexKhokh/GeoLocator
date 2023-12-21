using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace Data.Entities
{
    public class DbContextBuilder : IHostedService, IDisposable
    {
        private readonly string _source;
        private DbContext _context;
        private BinaryReader _reader;

        public DbContextBuilder(string source)
        {
            if (!File.Exists(source))
            {
                throw new FileNotFoundException(nameof(source));
            }
            _source = source;
        }

        private DbContext Init()
        {
            if (_context == null)
            {
                byte[] bytes = File.ReadAllBytes(_source);
                _context = new DbContext();

                _reader = new BinaryReader(new MemoryStream(bytes));
                _reader.BaseStream.Seek(0, SeekOrigin.Begin);

                Stopwatch stopwatch = Stopwatch.StartNew();
                _context.Header = new Header(version: _reader.ReadInt32(),
                            name: new string(_reader.ReadChars(32)).Trim('\0'),
                            timestamp: _reader.ReadUInt64(),
                            records: _reader.ReadUInt32(),
                            offsetRanges: _reader.ReadUInt32(),
                            offsetCities: _reader.ReadUInt32(),
                            offsetLocations: _reader.ReadUInt32());

                _context.IpRanges = DbReader.GetIpRanges(_context.Header.OffsetRanges, _context.Header.Records, _reader);
                _context.Locations = DbReader.GetLocations(_context.Header.OffsetLocations, _context.Header.Records, _reader);
                _context.Indexes = DbReader.GetLocationIndexes(_context.Header.OffsetCities, _context.Header.Records, _reader);

                stopwatch.Stop();
                Debug.WriteLine($"Db load requested: {stopwatch.ElapsedMilliseconds} ms");
            }

            return _context;
        }

        public DbContext GetContext() { return _context; }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Init());
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Dispose();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _reader?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
