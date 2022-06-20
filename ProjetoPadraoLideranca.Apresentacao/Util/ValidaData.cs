using System;
using System.Globalization;

namespace ProjetoPadraoLideranca.Apresentacao.Util
{
    public static class ValidaData
    {
        public static bool ValidandoData(string data)
        {
            DateTime dt;

            bool isValid = DateTime.TryParseExact(data, "yyyyMM", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);

            return isValid;
        }
    }
}