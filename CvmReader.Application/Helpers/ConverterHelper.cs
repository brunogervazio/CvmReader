namespace CvmReader.Application.Helpers
{
    public static class ConverterHelper
    {
        public static DateOnly? TryConvertDateOnly(this string date)
            => string.IsNullOrEmpty(date) ? null : DateOnly.Parse(date);
    }
}
