using System.Configuration;
using System.Reflection;
using log4net;
using GetSenha451.Web;

namespace Infra.Data.Contexto
{
    public class AdoContexto
    {
        public static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static string StrConnection;

        public AdoContexto()
        {
            StrConnection = AtualizaAutenticacao();
        }

        public static string AtualizaAutenticacao()
        {
            var getSenha = new GetSenha();
            var application = ConfigurationManager.AppSettings["ApplicationName"];

            return getSenha.GetConnectionString(application);
        }
    }
}
