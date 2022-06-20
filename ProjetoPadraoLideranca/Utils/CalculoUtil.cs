using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendaTsdigital.Dominio.Utils
{
    public class CalculoUtil
    {

        private string itipo = "CAPEX";
        private decimal vferias = 11.11m;
        private decimal vtreze = 8.33m;
        private decimal vinss = 29.2m;
        private decimal vfgts = 8.0m;
        private decimal salarioAuxiliar;


        public decimal calcula(int iop, decimal salario, decimal horaUtilMes, decimal horaLancada, string tipoRegime, string tipoCapexOpex)
        {
            itipo = tipoCapexOpex.ToUpper();
            salarioAuxiliar = salario;
            decimal resultado;

            if (tipoRegime == "CLT")
            {
                if (iop == 4)
                {
                    salario = 0.0m;
                }
                else if (iop == 5)
                {
                    salario = salario * 1;
                }
                else if (iop == 6)
                {
                    salario = 0.0m;
                }
                else if (iop == 7)
                {
                    salario = Math.Round((salarioAuxiliar * vferias) / 100, 2);
                }
                else if (iop == 8)
                {
                    salario = Math.Round((salarioAuxiliar * vtreze) / 100, 2);
                }
                else if (iop == 9)
                {
                    salario = Math.Round((salarioAuxiliar * vinss) / 100, 2);
                }
                else if (iop == 10)
                {
                    salario = Math.Round((salarioAuxiliar * vferias) / 100, 2);
                    salario = Math.Round((salario * vinss) / 100, 2);
                }
                else if (iop == 11)
                {
                    salario = Math.Round((salarioAuxiliar * vtreze) / 100, 2);
                    salario = Math.Round((salario * vinss) / 100, 2);
                }
                else if (iop == 12)
                {
                    salario = Math.Round((salarioAuxiliar * vfgts) / 100, 2);
                }
                else if (iop == 13)
                {
                    salario = Math.Round((salarioAuxiliar * vferias) / 100, 2);
                    salario = Math.Round((salario * vfgts) / 100, 2);
                }
                else if (iop == 14)
                {
                    salario = Math.Round((salarioAuxiliar * vtreze) / 100, 2);
                    salario = Math.Round((salario * vfgts) / 100, 2);
                }
                else if (iop == 15)
                {
                    salario = 1000m;

                }
                else if (iop == 16)
                {
                    salario = 100m;

                }
                else if (iop == 17)
                {
                    salario = 300m;

                }
                else if (iop == 18)
                {
                    salario = 0m;

                }
                else if (iop == 19)
                {
                    salario = 300m;

                }
                else if (iop == 20)
                {
                    salario = 500m;

                }
                else if (iop == 21)
                {
                    salario = 750m;

                }
                else if (iop == 22)
                {
                    salario = 0m;

                }
                else if (iop == 23)
                {
                    salario = 250m;

                }
                else if (iop == 24)
                {
                    salario = 600m;

                }
                else if (iop == 25)
                {
                    salario = 0m;

                }
                else
                {
                    return 0.0m;
                }

                if (itipo.Equals("CAPEX") | itipo.Equals("OPEX"))
                {
                    resultado = Math.Round(salario / horaUtilMes * horaLancada, 2);
                }
                else
                {
                    resultado = salario;
                }


                return resultado;
            }
            else
            {
                if (iop != 4)
                {
                    return 0.0m;
                }


                if (itipo.Equals("CAPEX") | itipo.Equals("OPEX"))
                {
                    resultado = Math.Round(salario / horaUtilMes * horaLancada, 2);
                }
                else
                {
                    resultado = salario;
                }
                return resultado;
            }


        }


        public double diasUteis(int year, int month)
        {
            //DateTime date = DateTime.Now;
            var firstDayOfMonth = new DateTime(year, month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            DateTime startD = firstDayOfMonth;
            DateTime endD = lastDayOfMonth;
            double calcBusinessDays = 1 + ((endD - startD).TotalDays * 5 - (startD.DayOfWeek - endD.DayOfWeek) * 2) / 7;
            if (endD.DayOfWeek == DayOfWeek.Saturday) calcBusinessDays--;
            if (startD.DayOfWeek == DayOfWeek.Sunday) calcBusinessDays--;
            return calcBusinessDays;
        }

        public double horaUtil(double horaDeTrabalho, int ano, int mes)
        {
            return horaDeTrabalho * diasUteis(ano, mes);
        }




        //private decimal retorno(decimal salario, decimal horaUtilMes, decimal horaLancada)
        //{
        //    return a / b * c;
        //}


        //public decimal assessoriaEConsultoriaPj()
        //{
        //    return 0.0m;
        //}
        //public decimal salariosEOrdenados()
        //{
        //    return 0.0m;
        //}
        //public decimal horasExtrasNormais()
        //{
        //    return 0.0m;
        //}
        //public decimal ferias(decimal salario, decimal horaUtilMes, decimal horaLancada)
        //{
        //    salario = (salario * vferias) / 100;
        //    return 0;
        //}
        //public decimal provisaoDe13Salario()
        //{
        //    return 0;
        //}
        //public decimal inss()
        //{
        //    return 0;
        //}
        //public decimal inssProvisaoDeFerias()
        //{
        //    return 0;
        //}
        //public decimal inssProvisaoDe13Salario()
        //{
        //    return 0;
        //}
        //public decimal fgts()
        //{
        //    return 0;
        //}
        //public decimal fgtsProvisaoDeFerias()
        //{
        //    return 0;
        //}
        //public decimal fgtsProvisaoDe13Salario()
        //{
        //    return 0;
        //}
        //public decimal assistênciaMedicaESocial()
        //{
        //    return 0;
        //}
        //public decimal assistenciaOdontologica()
        //{
        //    return 0;
        //}
        //public decimal fundoDePensao()
        //{
        //    return 0;
        //}
        //public decimal taxaAdmFundoDePensao()
        //{
        //    return 0;
        //}
        //public decimal seguroDeVidaEmGrupo()
        //{
        //    return 0;
        //}
        //public decimal valeTransporte()
        //{
        //    return 0;
        //}
        //public decimal valeRefeicao()
        //{
        //    return 0;
        //}
        //public decimal cestaBasica()
        //{
        //    return 0;
        //}
        //public decimal auxilioCreche()
        //{
        //    return 0;
        //}
        //public decimal valeAlimentacao()
        //{
        //    return 0;
        //}
        //public decimal auxilioBaba()
        //{
        //    return 0;
        //}
    }
}
