using System.Text.RegularExpressions;

namespace Viacep.Infrastructure
{
    public class CepValidator
    {
        public bool ValidateCepFormat(string cep)
        {
            var pattern = @"^\d{8}$";

            return Regex.IsMatch(cep, pattern);
        }
    }
}
