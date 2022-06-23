using AutoMapper;
using ProjetoPadraoLideranca.Apresentacao.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using VendaTsdigital.Apresentacao.Util;
using VendaTsdigital.Dominio.Entidades;
using VendaTsdigital.Dominio.Entidades.dtos;
using VendaTsdigital.Dominio.Interfaces;
using VendaTsdigital.Infra.Data.Repository;

namespace ProjetoPadraoLideranca.Apresentacao.Controllers
{
    public class CadastroController : Controller
    {
        // GET: Modelo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edicao(string codFuncionario)
        {
            ViewBag.codFuncionario = codFuncionario;
            return View();
        }

        [HttpGet]
        public ActionResult AtualizaListaCadastro()
        {
            try
            {
                //FuncionarioRepository repository = new FuncionarioRepository();
                //Funcionario resposta = new Funcionario();
                //resposta = repository.AtualizaListaCadastro();

                //JsonResult jr = Json(new RetornoJson().Retorno(true, resposta, 0), JsonRequestBehavior.AllowGet);
                //jr.MaxJsonLength = int.MaxValue;
                //return jr;

                //Puxa os dados da base JIRA
                FuncionarioRepository repository = new FuncionarioRepository();
                List<Funcionario> listaNova = new List<Funcionario>();
                List<Funcionario> listaAtual = new List<Funcionario>();
                listaNova = repository.BaixarListaAtualizadaFuncionProc();
                listaAtual = repository.ListarAtualFuncionProc();
                
                List<FuncionarioNovoDto> mapped = new List<FuncionarioNovoDto>();  

                if(listaAtual.Count() == 0)
                {
                    foreach (var funcDto in listaNova)
                    {
                        var funcNovo = new FuncionarioNovoDto();
                        funcNovo.ApelidoBase = CrytoUtil.Encrypt(funcDto.ApelidoBase);
                        funcNovo.NomeBase = CrytoUtil.Encrypt(funcDto.NomeBase);
                        funcNovo.Ativo = funcDto.Ativo;
                        mapped.Add(funcNovo);
                    }

                     
                    DataTable map = new UtilsEditDoc().ToDataTable<FuncionarioNovoDto>(mapped);
                    repository.AdicionarNovosFuncionarios(map);
                }
                else 
                {
                    //ponto de gargalo no sistema
                    var diferenca =  listaNova.Where(l => !listaAtual.Any(e => l.ApelidoBase == e.ApelidoD)).ToList();


                    if(diferenca.Any())
                    {
                        foreach (var f in diferenca)
                        {
                            var funcNovo = new FuncionarioNovoDto();
                            funcNovo.ApelidoBase = CrytoUtil.Encrypt(f.ApelidoBase);
                            funcNovo.NomeBase = CrytoUtil.Encrypt(f.NomeBase);
                            funcNovo.Ativo = f.Ativo;
                            mapped.Add(funcNovo);
                        }
                        DataTable map = new UtilsEditDoc().ToDataTable<FuncionarioNovoDto>(mapped);
                        repository.AdicionarNovosFuncionarios(map);
                    }
                }

                    return null;


            }
            catch (Exception e)
            {
                var obj = new { codigo = -1, descricao = e.Message };

                var retorno = new RetornoJson().Retorno(false, obj, -1);
                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Consultar(string Nome = null, string Regime = null, string Tipo = null)
        {
            try
            {
                FuncionarioRepository repository = new FuncionarioRepository();
                List<Funcionario> retorno = new List<Funcionario>();
                retorno = repository.ConsultarFuncionarios();

                List<Funcionario> filteredList = retorno.Where(f => 
                                                                    f.Nome.Contains((Nome == "" | Nome == null) ? "" : Nome) &&
                                                                    f.RegimeD.Contains((Regime == "" | Regime == null) ? "" : Regime) &&
                                                                    f.TipoD.Contains((Tipo == "" | Tipo == null) ? "" : Tipo)

                                                                ).ToList();


                JsonResult jr = Json(new RetornoJson().Retorno(true, filteredList, 0), JsonRequestBehavior.AllowGet);
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
        public ActionResult ConsultaUmFuncionario(string codfuncionario = null)
        {
            try
            {
                FuncionarioRepository repository = new FuncionarioRepository();
                List<Funcionario> retorno = new List<Funcionario>();
                retorno = repository.ConsultarUmFuncionario(codfuncionario);

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
        public ActionResult AtualizarDadosFuncionario(int CodFuncionario, string Nome, string Regime, string Tipo, string CargaHoraria,  
                                                        string Salario, string Vt, string Vr, string Va, string Medica, string Odonto,
                                                        string Seguro, string Creche, string Baba)
        {
            try
            {

                FuncionarioRepository repository = new FuncionarioRepository();
                var retorno = repository.AtualizarDadosFuncionario(
                    CodFuncionario, 
                    Nome, 
                    Regime, 
                    Tipo, 
                    CargaHoraria, 
                    Salario, 
                    Vt, 
                    Vr, 
                    Va, 
                    Medica, 
                    Odonto,                              
                    Seguro, 
                    Creche, 
                    Baba);

                JsonResult jr = Json(new RetornoJson().Retorno(true, retorno, 0), JsonRequestBehavior.AllowGet);
                jr.MaxJsonLength = int.MaxValue;
                return jr;
            }
            catch (Exception e)
            {
                var obj = new { Codigo = -1, Descricao = e.Message };

                var retorno = new RetornoJson().Retorno(false, obj, -1);
                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
        }
    }
}