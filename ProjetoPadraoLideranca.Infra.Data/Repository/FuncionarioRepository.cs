using Dapper;
using Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using VendaTsdigital.Dominio.Entidades;
using VendaTsdigital.Dominio.Entidades.dtos;
using VendaTsdigital.Dominio.Interfaces;

namespace VendaTsdigital.Infra.Data.Repository
{
    public class FuncionarioRepository : RepositoryBase<Funcionario>
    {
        public List<Funcionario> ConsultarFuncionarios(string nome = null, string regime = null, string tipo = null)
        {
            try
            {
                var param = new DynamicParameters();

                return this.GetAll(new Funcionario(), param, Funcionario.ConsultaFuncProc).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Funcionario AtualizaListaCadastro()
        {
            try
            {
                var param = new DynamicParameters();

                return this.Get(new Funcionario(), Funcionario.AtualizaListaFuncProc);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Funcionario> ConsultarUmFuncionario(string codFuncionario)
        {
            try
            {
                var param = new DynamicParameters();

                if (!string.IsNullOrEmpty(codFuncionario))
                {
                    param.Add("@CodFuncionario", Int32.Parse(codFuncionario));
                }

                return this.GetAll(new Funcionario(), param, Funcionario.ConsultaFuncProc).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AdicionarNovosFuncionarios(DataTable listaFuncionario)
        {
            using (var con = new SqlConnection(StrConnection))
            {
                con.Open();
                using (var cmd = new SqlCommand(Funcionario.InserirListaFuncionariosProc, con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TblFuncionarios", listaFuncionario);

                        cmd.CommandTimeout = 0;
                        SqlDataReader rs = cmd.ExecuteReader();
                    }
                    catch (Exception e)
                    {

                        throw;
                    }
                }
            }
        }

        public List<Funcionario> ListarAtualFuncionProc()
        {
            try
            {

                return this.GetAll(new Funcionario(), Funcionario.ListarAtualFuncionProc).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Funcionario> BaixarListaAtualizadaFuncionProc()
        {
            try
            {

                return this.GetAll(new Funcionario(), Funcionario.BaixarListaAtualizadaFuncionProc).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Funcionario AtualizarDadosFuncionario(int CodFuncionario, string Nome, string Regime, string Tipo, string CargaHoraria,
                                                        string Salario, string Vt, string Vr, string Va, string Medica, string Odonto,
                                                        string Seguro, string Creche, string Baba)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                double ConvertDouble = 0.0;
                string cpf = string.Empty;

                parameters.Add("@CodFuncionario", CodFuncionario);
                parameters.Add("@nome", CrytoUtil.Encrypt(Nome));
                parameters.Add("@regime", CrytoUtil.Encrypt(Regime));
                parameters.Add("@tipo", CrytoUtil.Encrypt(Tipo));
                parameters.Add("@carga", CrytoUtil.Encrypt(CargaHoraria));

                if (!string.IsNullOrEmpty(Salario))
                {
                    Salario = Salario.Replace("R$", "");
                    Salario = Salario.Replace(".", "");
                    Salario = Salario.Replace(",", ".");
                    parameters.Add("@salario", CrytoUtil.Encrypt(Salario));
                }
                if (!string.IsNullOrEmpty(Vt))
                {
                    Vt = Vt.Replace("R$", "");
                    Vt = Vt.Replace(".", "");
                    Vt = Vt.Replace(",", ".");
                    parameters.Add("@vt", CrytoUtil.Encrypt(Vt));
                }
                if (!string.IsNullOrEmpty(Vr))
                {
                    Vr = Vr.Replace("R$", "");
                    Vr = Vr.Replace(".", "");
                    Vr = Vr.Replace(",", ".");
                    parameters.Add("@vr", CrytoUtil.Encrypt(Vr));
                }
                if (!string.IsNullOrEmpty(Va))
                {
                    Va = Va.Replace("R$", "");
                    Va = Va.Replace(".", "");
                    Va = Va.Replace(",", ".");
                    parameters.Add("@va", CrytoUtil.Encrypt(Va));
                }
                if (!string.IsNullOrEmpty(Medica))
                {
                    Medica = Medica.Replace("R$", "");
                    Medica = Medica.Replace(".", "");
                    Medica = Medica.Replace(",", ".");
                    parameters.Add("@medica", CrytoUtil.Encrypt(Medica));
                }
                if (!string.IsNullOrEmpty(Odonto))
                {
                    Odonto = Odonto.Replace("R$", "");
                    Odonto = Odonto.Replace(".", "");
                    Odonto = Odonto.Replace(",", ".");
                    parameters.Add("@odonto", CrytoUtil.Encrypt(Odonto));
                }
                if (!string.IsNullOrEmpty(Seguro))
                {
                    Seguro = Seguro.Replace("R$", "");
                    Seguro = Seguro.Replace(".", "");
                    Seguro = Seguro.Replace(",", ".");
                    parameters.Add("@seguro", CrytoUtil.Encrypt(Seguro));
                }
                if (!string.IsNullOrEmpty(Creche))
                {
                    Creche = Creche.Replace("R$", "");
                    Creche = Creche.Replace(".", "");
                    Creche = Creche.Replace(",", ".");
                    parameters.Add("@creche", CrytoUtil.Encrypt(Creche));
                }
                if (!string.IsNullOrEmpty(Baba))
                {
                    Baba = Baba.Replace("R$", "");
                    Baba = Baba.Replace(".", "");
                    Baba = Baba.Replace(",", ".");
                    parameters.Add("@baba", CrytoUtil.Encrypt(Baba));
                }

                var retorno = this.Add(new Funcionario(), parameters, Funcionario.InsereDadosFuncProc);
                return retorno;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
