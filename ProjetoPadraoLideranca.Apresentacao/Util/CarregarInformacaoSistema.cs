using System;
using System.Configuration;

namespace ProjetoPadraoLideranca.Apresentacao.Util
{
    public static class CarregarInformacaoSistema
    {
        /// <summary>
        /// Pegando a versão do Sistema Atual
        /// </summary>
        /// <returns></returns>
        public static string VersaoSistema()
        {
            return ConfigurationManager.AppSettings["VersaoSistema"];
        }

        /// <summary>
        /// Pegando o nome do Servidor de acordo o ambiente
        /// </summary>
        /// <returns></returns>
        public static string NomeServidor()
        {
            return GetNomeServidor();
        }

        public static string GetEnv(string env = "")
        {
            env = Environment.GetEnvironmentVariable("ENV");

            if (string.IsNullOrEmpty(env))
                env = "LOCAL";

            switch (env.ToLower())
            {
                case "local":
                case "debug":       // PROJ71-253 - Chiprauski - 13/07/2018.
                    return "local";
                case "dev":
                case "development":
                case "desenv":
                case "desenvolvimento":
                    return "dev";
                case "stg":
                case "staging":
                case "homolog":
                case "homologacao":
                    return "stg";
                case "live":
                case "prod":
                case "production":
                case "producao":
                    return "prod";
            }
            throw new Exception("Invalid env param: " + env);
        }

        public static string GetNomeServidor(string env = "")
        {
            env = Environment.GetEnvironmentVariable("ENV");

            if (string.IsNullOrEmpty(env))
                env = "LOCAL";

            switch (GetEnv(env))
            {
                case "dev":
                case "local":
                    return "CAPD1202";
                case "stg":
                    return "CAPD1203";
                case "prod":
                    return "CAPD1201";
            }

            return null;
        }
    }
}