using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using log4net;
using ProjetoIncentivo.Apresentacao.Controllers;
using ProjetoIncentivo.Dominio.Entidades;

namespace ProjetoIncentivo.Apresentacao.Util
{
    public class SingleTon
    {
        public static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly SingleTon _instance = new SingleTon();
        private ProximosSorteio _proximosSorteio;
        public bool? Lookup;
        private Thread[] Threads = null;

        static SingleTon() { }

        public SingleTon()
        {
            try
            {
                //_lookup = HomeController.Teste();
                _proximosSorteio = HomeController.VerificarProximaDataSorteio();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static SingleTon Instance
        {
            get { return _instance; }
        }

        public void GetLookup()
        {
            if (Lookup == null)
            {
                Execute();
                Lookup = true;
            }
        }

        public void Execute()
        {
            Thread[] Threads = new Thread[1];

            if (Threads != null)
            {
                Threads = new Thread[1];
                Threads[0] = new Thread(() =>
                {
                    _proximosSorteio = HomeController.VerificarProximaDataSorteio();

                    if (_proximosSorteio != null )
                    {
                        if (_proximosSorteio.IsStatus && _proximosSorteio.Codigo.Equals(0))
                            log.DebugFormat("Data Próximo Sorteio: {0}", _proximosSorteio.ProximoSorteio);
                        else
                            log.DebugFormat("Error ao Carregar Data Próximo Sorteio: {0} - Código -1: {1}", _proximosSorteio.Descricao, _proximosSorteio.Codigo);
                    }
                    else
                    {
                        log.DebugFormat("Error ao carregar a próxima data de Sorteio: {0}", DateTime.Now);
                    }

                    System.Threading.Thread.Sleep(10000);
                    Threads = null;
                    Execute();
                });
                Threads[0].Start();
                //Threads[0].
            }
        }
    }
}