using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace SynelApi.Interfaces
{
    public interface ICSVService
    {
        IEnumerable<T> ReadCSV<T, C>(Stream stream) where C : ClassMap;
    }
    public class CSVService : ICSVService
    {
        public IEnumerable<T> ReadCSV<T, C>(Stream stream) where C : ClassMap
        {
            var reader = new StreamReader(stream);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<C>();
            var records = csv.GetRecords<T>();
            return records;
        }
    }
}
