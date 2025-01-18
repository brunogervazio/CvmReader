namespace CvmReader.Application.Helpers
{
    public static class FormatHelper
    {
        public static string CepFormatter(this string cep) =>
            string.IsNullOrWhiteSpace(cep)
                ? string.Empty
                : string.Format("{0:00000-000}", long.Parse(cep));

        public static string PhoneFormatter(this string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return string.Empty;

            return string.Format(phone.Length == 8 ? "{0:0000-0000}" : "{0:00000-0000}", long.Parse(phone));
        }

        public static string CnpjFormatter(this string cnpj) =>
            string.Format(@"{0:00\.000\.000\/0000\-00}", long.Parse(cnpj));
    }
}
