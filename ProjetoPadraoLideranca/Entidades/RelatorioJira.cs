using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendaTsdigital.Dominio.Entidades
{
    public class RelatorioJira
    {
		public static string PesquisarProjetosJira = "PesquisarProjetosJira";

		public string Nome{get; set;} 
		public string Regime{get; set;} 
		public string Horas{get; set;} 
		public string DiaUtil{get; set;}  
		public string HoraUtil{get; set;} 
		public string Mes{get; set;}  
		public string Ano{get; set;}  
		public string AssessoriaConsultaPJ{get;set;} 
		
		public string SalarioOrdenado{get; set;} 
		
		public string HoraExtra{get; set;} 
		
		public string Ferias{get; set;} 
		
		public string DecimoTerceiroProvisao{get; set;} 
		
		public string INSS{get; set;} 
		
		public string INSSProvisaoFerias{get; set;} 
		
		public string INSSProvisaoDecimoTerceiro{get; set;} 
		
		public string FGTS{get; set;} 
		
		public string FGTSProvisaoFerias{get; set;} 
		
		public string FGTSProvisaoDecimoTerceiro{get; set;} 
		
		public string Medica{get; set;} 
		
		public string Odonto{get; set;} 
		
		public string Pensao{get; set;} 
		
		public string TaxaAdmPensao{get; set;} 
		
		public string Seguro{get; set;} 
		
		public string Vt{get; set;} 
		
		public string Vr{get; set;} 
		
		public string Cesta{get; set;} 
		
		public string Creche{get; set;} 
		
		public string Va{get; set;} 
		
		public string Baba{get; set;}


		public decimal HorasFormatado { get { return CorrecaoDecimal(Horas); } }
		public decimal AssessoriaConsultaPJFormatado { get { return CorrecaoDecimal(AssessoriaConsultaPJ); } }

		public decimal SalarioOrdenadoFormatado { get { return CorrecaoDecimal(SalarioOrdenado); } }

		public decimal HoraExtraFormatado { get { return CorrecaoDecimal(HoraExtra); } }

		public decimal FeriasFormatado { get { return CorrecaoDecimal(Ferias); } }

		public decimal DecimoTerceiroProvisaoFormatado { get { return CorrecaoDecimal(DecimoTerceiroProvisao); } }

		public decimal INSSFormatado { get { return CorrecaoDecimal(INSS); } }

		public decimal INSSProvisaoFeriasFormatado { get { return CorrecaoDecimal(INSSProvisaoFerias); } }

		public decimal INSSProvisaoDecimoTerceiroFormatado { get { return CorrecaoDecimal(INSSProvisaoDecimoTerceiro); } }

		public decimal FGTSFormatado { get { return CorrecaoDecimal(FGTS); } }

		public decimal FGTSProvisaoFeriasFormatado { get { return CorrecaoDecimal(FGTSProvisaoFerias); } }

		public decimal FGTSProvisaoDecimoTerceiroFormatado { get { return CorrecaoDecimal(FGTSProvisaoDecimoTerceiro); } }

		public decimal MedicaFormatado { get { return CorrecaoDecimal(Medica); } }

		public decimal OdontoFormatado { get { return CorrecaoDecimal(Odonto); } }

		public decimal PensaoFormatado { get { return CorrecaoDecimal(Pensao); } }

		public decimal TaxaAdmPensaoFormatado { get { return CorrecaoDecimal(TaxaAdmPensao); } }

		public decimal SeguroFormatado { get { return CorrecaoDecimal(Seguro); } }

		public decimal VtFormatado { get { return CorrecaoDecimal(Vt); } }

		public decimal VrFormatado { get { return CorrecaoDecimal(Vr); } }

		public decimal CestaFormatado { get { return CorrecaoDecimal(Cesta); } }

		public decimal CrecheFormatado { get { return CorrecaoDecimal(Creche); } }

		public decimal VaFormatado { get { return CorrecaoDecimal(Va); } }

		public decimal BabaFormatado { get { return CorrecaoDecimal(Baba); } }

		private decimal CorrecaoDecimal(string valor)
		{
			decimal valorConv = Convert.ToDecimal((valor != null & valor != "") ? valor : "0");
			return decimal.Round(valorConv, 2, MidpointRounding.AwayFromZero);
		}

		}
}
