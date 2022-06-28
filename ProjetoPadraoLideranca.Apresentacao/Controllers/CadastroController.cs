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
    public class CadastroController : BaseController
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
                        funcNovo.CodFuncionario = 0;
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

                    //List<FuncionarioNovoDto> mappedAux = new List<FuncionarioNovoDto>(); 

                    //foreach (var funcDto in listaNova)
                    //{
                    //    var funcNovo = new FuncionarioNovoDto();
                    //    funcNovo.CodFuncionario = 0;
                    //    funcNovo.ApelidoBase = funcDto.ApelidoBase;
                    //    funcNovo.NomeBase = funcDto.NomeBase;
                    //    funcNovo.Ativo = funcDto.Ativo;
                    //    mapped.Add(funcNovo);
                    //}

                    //foreach (var funcDto in listaAtual)
                    //{
                    //    var funcNovo = new FuncionarioNovoDto();
                    //    funcNovo.CodFuncionario = funcDto.CodFuncionario;
                    //    funcNovo.ApelidoBase = funcDto.ApelidoD;
                    //    funcNovo.NomeBase = funcDto.NomeD;
                    //    funcNovo.Ativo = funcDto.Ativo;
                    //    mappedAux.Add(funcNovo);
                    //}
                    //DataTable map = new UtilsEditDoc().ToDataTable<FuncionarioNovoDto>(mapped);
                    //DataTable mapAux = new UtilsEditDoc().ToDataTable<FuncionarioNovoDto>(mappedAux);

                    //List<Funcionario>   x = repository.TrazerListaAtualizadaFuncionarios(map, mapAux);


                    //ponto de gargalo no sistema
                    //IEnumerable<Funcionario> diferenca = listaNova.Where(l => !listaAtual.Any(e => l.ApelidoBase == e.ApelidoD)).ToList();


                    var dif = listaNova.Select(l => l.ApelidoBase).Except(listaAtual.Select(e => e.ApelidoD)).ToList();
                    var diferenca = (from std in listaNova
                               join std2 in dif on std.ApelidoBase equals std2.ToString()
                               select std);

                    //HashSet<Funcionario> lista = new HashSet<Funcionario>(listaAtual);
                    //IEnumerable<Funcionario> diferenca = listaNova.Where(l => !lista.Any(e => l.ApelidoBase == e.ApelidoD)).ToList();





                    //List<Funcionario> diferenca = new List<Funcionario>();
                    //foreach(var item in listaNova)
                    //{
                    //    if(!listaAtual.Exists(x => x.ApelidoBase == item.ApelidoD))
                    //    {
                    //        diferenca.Add(item);
                    //    }
                    //}

                    //var diferenca = from n in listaNova
                    //        where !(from a in listaAtual
                    //                select a.ApelidoD).Contains(n.ApelidoBase)
                    //        select n;



                    if (diferenca.Any())
                    {
                        foreach (var f in diferenca)
                        {
                            var funcNovo = new FuncionarioNovoDto();
                            funcNovo.ApelidoBase = CrytoUtil.Encrypt(f.ApelidoBase);
                            funcNovo.NomeBase = CrytoUtil.Encrypt(f.NomeBase);
                            funcNovo.Ativo = f.Ativo;
                            mapped.Add(funcNovo);
                        }
                        DataTable maps = new UtilsEditDoc().ToDataTable<FuncionarioNovoDto>(mapped);
                        repository.AdicionarNovosFuncionarios(maps);
                    }




                    listaNova = repository.BaixarListaAtualizadaFuncionProc();
                    listaAtual = repository.ListarAtualFuncionProc();
                    var ativo = listaNova.Select(l => l.Ativo).Except(listaAtual.Select(e => e.Ativo)).ToList();
                    //diferenca = (from std in listaNova
                    //             join std2 in ativo on std.Ativo equals std2.
                    //             select std);

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
        public ActionResult Consultar(string Nome = null, string Regime = null, string Tipo = null, bool Ativos = false)
        {
            try
            {
                FuncionarioRepository repository = new FuncionarioRepository();
                List<Funcionario> retorno = new List<Funcionario>();
                retorno = repository.ConsultarFuncionarios();

                List<Funcionario> filteredList = retorno.Where(f => 
                                                                    f.NomeD.Contains((Nome == "" | Nome == null) ? "" : Nome) &&
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
                    Baba,
                    _User.Login);

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