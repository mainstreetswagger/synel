using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Newtonsoft.Json;
using SynelApi.Dtos;
using System.Globalization;

namespace SynelApi.CsvConverters
{
    public class EmployeeCsvCoverter : ClassMap<EmployeeData>
    {
        public EmployeeCsvCoverter()
        {
            Map(p => p.PayrollNumber).Name("Personnel_Records.Payroll_Number");
            Map(p => p.Forename).Name("Personnel_Records.Forenames");
            Map(p => p.Surename).Name("Personnel_Records.Surname");
            Map(p => p.DOB)
                .Name("Personnel_Records.Date_of_Birth")
                .TypeConverter<DateTimeConverter>();
            Map(p => p.Telephone).Name("Personnel_Records.Telephone");
            Map(p => p.Mobile).Name("Personnel_Records.Mobile");
            Map(p => p.Address).Name("Personnel_Records.Address");
            Map(p => p.Location).Name("Personnel_Records.Address_2");
            Map(p => p.Postcode).Name("Personnel_Records.Postcode");
            Map(p => p.Email).Name("Personnel_Records.EMail_Home");
            Map(p => p.StartDate)
                .Name("Personnel_Records.Start_Date")
                 .TypeConverter<DateTimeConverter>();
        }
    }
    public class DateTimeConverter : DefaultTypeConverter
    {
        private readonly DateTimeFormatInfo dateTimeFormat;
        public DateTimeConverter()
        {
            dateTimeFormat = new();
            dateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
        }
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            return DateOnly.Parse(text, dateTimeFormat);
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            if (value.GetType() == typeof(DateTime))
            {
                return ((DateOnly)value).ToString(dateTimeFormat);
            }
            return string.Empty;
        }
    }
}
