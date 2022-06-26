using AutoMapper;
using ProjetoPadraoLideranca.Apresentacao.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using VendaTsdigital.Apresentacao.Util;
using VendaTsdigital.Dominio.Entidades;
using VendaTsdigital.Dominio.Entidades.dtos;
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
        public ActionResult ConsultarResultadoProjetosJira(string projeto, string regime, int mes, int ano)
        {
            try
            {
                ProjetosJiraRepository repository = new ProjetosJiraRepository();
                
                List<ProjetosJira> projetosJiras = new List<ProjetosJira>();
                List<ProjetosJiraDto> projetosJirasDto = new List<ProjetosJiraDto>();

                FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
                List<Funcionario> funcionarios = new List<Funcionario>();
                List<FuncionarioDto> funcionarioDto = new List<FuncionarioDto>();
                


                List<RelatorioJira> relatorioJiras = new List<RelatorioJira>();
                


                funcionarios = funcionarioRepository.ConsultarFuncionarios();
                foreach (var funcionarioReal in funcionarios)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Funcionario, FuncionarioDto>());
                    var mapper = config.CreateMapper();

                    FuncionarioDto info = mapper.Map<FuncionarioDto>(funcionarioReal);
                    funcionarioDto.Add(info);

                }
                projetosJiras = repository.consultaProjetosJira(projeto);
                foreach (var projetoReal in projetosJiras)
                {


                    var config = new MapperConfiguration(cfg => cfg.CreateMap<ProjetosJira, ProjetosJiraDto>());
                    var mapper = config.CreateMapper();

                    ProjetosJiraDto info = mapper.Map<ProjetosJiraDto>(projetoReal);
                    projetosJirasDto.Add(info);

                }


                DataTable funcTable = ToDataTable<FuncionarioDto>(funcionarioDto);
                DataTable projTable = ToDataTable<ProjetosJiraDto>(projetosJirasDto);


                MemoryStream str = new MemoryStream();
                funcTable.WriteXml(str, false);
                projTable.WriteXml(str, false);

                repository.GerarResultado(funcTable, projTable);

                RelatorioJiraRepository relatorioRepository = new RelatorioJiraRepository();
                List<RelatorioJira> retorno = new List<RelatorioJira>();
                retorno = relatorioRepository.PesquisarResultado(regime, mes, ano);


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

        [HttpGet]
        public ActionResult ExcelResultadoProjetosJira(string projeto, string regime, int mes, int ano)
        {
            try
            {

                RelatorioJiraRepository relatorioRepository = new RelatorioJiraRepository();


                System.Data.DataSet ds = new System.Data.DataSet();
                DataTable dt = new DataTable();
                dt = ToDataTable<RelatorioJira> (relatorioRepository.PesquisarResultado(regime, mes, ano));
                ds.Tables.Add(dt);
                MemoryStream stream = new MemoryStream();


                ExcelLibrary.DataSetHelper.CreateWorkbook(stream, ds);

                Response.Clear();
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("content-disposition", string.Format("attachment;filename={0}_resultado_fechamento.xls", projeto));

                stream.WriteTo(Response.OutputStream);
                Response.End();
                return null;
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