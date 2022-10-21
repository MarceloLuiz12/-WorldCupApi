using System.Globalization;
using System.Text;

namespace CopaDoMundo.Infra.Repository.Auxiliar
{
    public static class StringExtensions
    {
        public static string RemoverAcentos(this string input)
            => new(input
                    .ToLower()
                    .Normalize(NormalizationForm.FormD)
                    .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                    .ToArray());
    }
}
