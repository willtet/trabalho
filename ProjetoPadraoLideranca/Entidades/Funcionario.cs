using Dapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaTsdigital.Dominio.Interfaces;

namespace VendaTsdigital.Dominio.Entidades
{
    public class Funcionario : RespostaAPI
    {
        public static string FuncionarioConsultaProc = "FuncionarioConsultaProc";
        public static string ConsultaFuncProc = "ConsultaFuncProc";
        public static string AtualizaListaFuncProc = "AtualizaListaFuncProc";
        public static string InsereDadosFuncProc = "InsereDadosFuncProc";
        public static string BaixarListaAtualizadaFuncionProc = "BaixarListaAtualizadaFuncionProc";
        public static string ListarAtualFuncionProc = "ListarAtualFuncionProc";
        public static string InserirListaFuncionariosProc = "InserirListaFuncionariosProc";
        public static string AtualizarFuncionarios = "AtualizarFuncionarios";
        public static string TrazerListaAtualizadaFuncionarios = "TrazerListaAtualizadaFuncionarios";
        



        public int CodFuncionario { get; set; }
        public string Nome { get; set; }
        public string NomeD
        {
            get { return (Nome != null & Nome != "") ? CrytoUtil.Decrypt(Nome) : ""; }
        }
        public string Apelido { get; set; }
        public string ApelidoD
        {
            get { return (Apelido != null & Apelido != "") ? CrytoUtil.Decrypt(Apelido) : ""; }
        }
        public string Regime { get; set; }

        public string RegimeD
        {
            get { 
                return (Regime != null & Regime != "") ? CrytoUtil.Decrypt(Regime) : ""; }
        }
        public string Tipo { get; set; }
        public string TipoD
        {
            get { return (Tipo != null & Tipo != "") ? CrytoUtil.Decrypt(Tipo) : ""; }
        }
        public string CargaHoraria { get; set; }
        public string CargaHorariaD
        {
            get { return (CargaHoraria != null & CargaHoraria != "") ? CrytoUtil.Decrypt(CargaHoraria) : ""; }
        }
        public string Salario { get; set; }
        public decimal SalarioD
        {
            get { return decimal.Round(Convert.ToDecimal((Salario != null & Salario != "") ? CrytoUtil.Decrypt(Salario) : "0") / 100, 2, MidpointRounding.AwayFromZero) ; }
        }

        public string SalarioFormatado {
            get
            {
                return DinheiroFormatado(Salario);
            }
        }
        public string Vt { get; set; }
        public string VtFormatado
        {
            get
            {
                return DinheiroFormatado(Vt);
            }
        }
        public string Vr { get; set; }
        public string VrFormatado
        {
            get
            {
                return DinheiroFormatado(Vr);
            }
        }
        public string Va { get; set; }
        public string VaFormatado
        {
            get
            {
                return DinheiroFormatado(Va);
            }
        }
        public string Medica { get; set; }
        public string MedicaFormatado
        {
            get
            {
                return DinheiroFormatado(Medica);
            }
        }
        public string Odonto { get; set; }
        public string OdontoFormatado
        {
            get
            {
                return DinheiroFormatado(Odonto);
            }
        }
        public string SeguroVida { get; set; }
        public string SeguroVidaFormatado
        {
            get
            {
                return DinheiroFormatado(SeguroVida);
            }
        }
        public string Creche { get; set; }
        public string CrecheFormatado
        {
            get
            {
                return DinheiroFormatado(Creche);
            }
        }
        public string Baba { get; set; }
        public string BabaFormatado
        {
            get
            {
                return DinheiroFormatado(Baba);
            }
        }
        public bool Novo { get; set; }

        public bool Ativo { get; set; }
        public string AtivoFormatado
        {
            get
            {
                return (Ativo ? "Sim" : "Não");
            }
        }




        public string NomeBase { get; set; }
        public string ApelidoBase { get; set; }


        public string DinheiroFormatado(string encrypt)
        {
            if(encrypt != null & encrypt != "")
            {
                string retornoPassado = CrytoUtil.Decrypt(encrypt);
                decimal? valor = Convert.ToDecimal(retornoPassado);
                valor = (valor) / 100m;

                string retorno = "R$ 0,00";
                if (valor.HasValue)
                {
                    retorno = String.Format("{0:C}", valor.Value, new CultureInfo("pt-BR"));
                }
                return retorno;
            }
            else
            {
                return "R$ 0,00";
            }
            
        }

    }
}
