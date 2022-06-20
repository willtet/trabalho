using ProjetoPadraoLideranca.Apresentacao.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using VendaTsdigital.Dominio.Entidades;
using VendaTsdigital.Dominio.Utils;
using VendaTsdigital.Infra.Data.Repository;

namespace ProjetoPadraoLideranca.Apresentacao.Controllers
{
    public class ControleController : Controller
    {
        // GET: Modelo
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ConsultarProjetos()
        {
            try
            {
                ProjetosJiraRepository repository = new ProjetosJiraRepository();
                List<ProjetosJira> retorno = new List<ProjetosJira>();
                retorno = repository.ListarCodigosProjeto();

                JsonResult jr = Json(new RetornoJson().Retorno(true, retorno, 0), JsonRequestBehavior.AllowGet);
                jr.MaxJsonLength = int.MaxValue;
                return jr;
            }
            catch (Exception e)
            {
                var obj = new { codigo = -1, descricao = e.Message };

                var retorno = new RetornoJson().Retorno(false, obj, -1);
                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ConsultarResultadoProjetosJira(string projeto)
        {
            try
            {
                ProjetosJiraRepository repository = new ProjetosJiraRepository();
                List<ProjetosJira> projetosJiras = new List<ProjetosJira>();
                
                
                FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
                List<Funcionario> funcionarios = new List<Funcionario>();


                List<RelatorioJira> relatorioJiras = new List<RelatorioJira>();


                funcionarios = funcionarioRepository.ConsultarFuncionarios();
                projetosJiras = repository.consultaProjetosJira(projeto);



                DataTable funcTable = ToDataTable<Funcionario>(funcionarios);
                DataTable projTable = ToDataTable<ProjetosJira>(projetosJiras);

                MemoryStream str = new MemoryStream();
                funcTable.WriteXml(str, false);
                projTable.WriteXml(str, false);

                repository.Teste(funcTable, projTable);

                //foreach (ProjetosJira projetos in projetosJiras)
                //{
                //    //Funcionario funcion = (Funcionario) funcionarios.Where(f => (f.Apelido.ToString() == projetos.Author.ToString()));.
                //    Funcionario funcion = funcionarios.Find(i => i.Apelido == projetos.Author);
                //    var x = 0;

                //    var ano = Convert.ToInt32(projetos.MesCriacao.ToString().Substring(0, 4));
                //    var mes = Convert.ToInt32(projetos.MesCriacao.ToString().Substring(4, 2));

                //    decimal horaUtil = Convert.ToDecimal(new CalculoUtil().horaUtil(Convert.ToDouble(projetos.TempoTrabalhado), ano, mes));
                //    decimal salario = funcion.SalarioD;
                //    decimal tempoTrabalhado = Convert.ToDecimal(projetos.TempoTrabalhado);


                //    RelatorioJira relatorio = new RelatorioJira();

                //    relatorio.Nome = projetos.NomeProjeto;
                //    relatorio.Regime = funcion.RegimeD;
                //    relatorio.Horas = projetos.TempoTrabalhado;
                //    relatorio.DiaUtil = Convert.ToString(new CalculoUtil().diasUteis(ano, mes));
                //    relatorio.HoraUtil = Convert.ToString(horaUtil);
                //    relatorio.Mes = Convert.ToString(mes);
                //    relatorio.Ano = Convert.ToString(ano);

                //    relatorio.AssessoriaConsultaPJ = Convert.ToString(new CalculoUtil().calcula(4, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));
                //    relatorio.SalarioOrdenado = Convert.ToString(new CalculoUtil().calcula(5, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));
                //    relatorio.HoraExtra = Convert.ToString(new CalculoUtil().calcula(6, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));
                //    relatorio.Ferias = Convert.ToString(new CalculoUtil().calcula(7, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));
                //    relatorio.DecimoTerceiroProvisao = Convert.ToString(new CalculoUtil().calcula(8, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));
                //    relatorio.INSS = Convert.ToString(new CalculoUtil().calcula(9, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));
                //    relatorio.INSSProvisaoFerias = Convert.ToString(new CalculoUtil().calcula(10, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));
                //    relatorio.INSSProvisaoDecimoTerceiro = Convert.ToString(new CalculoUtil().calcula(11, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));
                //    relatorio.FGTS = Convert.ToString(new CalculoUtil().calcula(12, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));
                //    relatorio.FGTSProvisaoFerias = Convert.ToString(new CalculoUtil().calcula(13, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));
                //    relatorio.FGTSProvisaoDecimoTerceiro = Convert.ToString(new CalculoUtil().calcula(14, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));
                //    relatorio.Medica = Convert.ToString(new CalculoUtil().calcula(15, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));
                //    relatorio.Odonto = Convert.ToString(new CalculoUtil().calcula(16, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));
                //    relatorio.Pensao = Convert.ToString(new CalculoUtil().calcula(17, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));
                //    relatorio.TaxaAdmPensao = Convert.ToString(new CalculoUtil().calcula(18, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));
                //    relatorio.Seguro = Convert.ToString(new CalculoUtil().calcula(19, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));
                //    relatorio.Vt = Convert.ToString(new CalculoUtil().calcula(20, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));
                //    relatorio.Vr = Convert.ToString(new CalculoUtil().calcula(21, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));
                //    relatorio.Cesta = Convert.ToString(new CalculoUtil().calcula(22, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));
                //    relatorio.Creche = Convert.ToString(new CalculoUtil().calcula(23, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));
                //    relatorio.Va = Convert.ToString(new CalculoUtil().calcula(24, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));
                //    relatorio.Baba = Convert.ToString(new CalculoUtil().calcula(25, salario, horaUtil, tempoTrabalhado, funcion.RegimeD, funcion.TipoD));

                //    relatorioJiras.Add(relatorio);  

                //}







                JsonResult jr = Json(new RetornoJson().Retorno(true, null, 0), JsonRequestBehavior.AllowGet);
                jr.MaxJsonLength = int.MaxValue;
                return jr;
            }
            catch (Exception e)
            {
                var obj = new { codigo = -1, descricao = e.Message };

                var retorno = new RetornoJson().Retorno(false, obj, -1);
                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
        }




        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

    }

    


}