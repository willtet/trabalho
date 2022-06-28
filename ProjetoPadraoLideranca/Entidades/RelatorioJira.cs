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


		public string HorasFormatado { get { return CorrecaoDecimal(Horas); } }
		public string AssessoriaConsultaPJFormatado { get { return CorrecaoDecimal(AssessoriaConsultaPJ); } }

		public string SalarioOrdenadoFormatado { get { return CorrecaoDecimal(SalarioOrdenado); } }

		public string HoraExtraFormatado { get { return CorrecaoDecimal(HoraExtra); } }

		public string FeriasFormatado { get { return CorrecaoDecimal(Ferias); } }

		public string DecimoTerceiroProvisaoFormatado { get { return CorrecaoDecimal(DecimoTerceiroProvisao); } }

		public string INSSFormatado { get { return CorrecaoDecimal(INSS); } }

		public string INSSProvisaoFeriasFormatado { get { return CorrecaoDecimal(INSSProvisaoFerias); } }

		public string INSSProvisaoDecimoTerceiroFormatado { get { return CorrecaoDecimal(INSSProvisaoDecimoTerceiro); } }

		public string FGTSFormatado { get { return CorrecaoDecimal(FGTS); } }

		public string FGTSProvisaoFeriasFormatado { get { return CorrecaoDecimal(FGTSProvisaoFerias); } }

		public string FGTSProvisaoDecimoTerceiroFormatado { get { return CorrecaoDecimal(FGTSProvisaoDecimoTerceiro); } }

		public string MedicaFormatado { get { return CorrecaoDecimal(Medica); } }

		public string OdontoFormatado { get { return CorrecaoDecimal(Odonto); } }

		public string PensaoFormatado { get { return CorrecaoDecimal(Pensao); } }

		public string TaxaAdmPensaoFormatado { get { return CorrecaoDecimal(TaxaAdmPensao); } }

		public string SeguroFormatado { get { return CorrecaoDecimal(Seguro); } }

		public string VtFormatado { get { return CorrecaoDecimal(Vt); } }

		public string VrFormatado { get { return CorrecaoDecimal(Vr); } }

		public string CestaFormatado { get { return CorrecaoDecimal(Cesta); } }

		public string CrecheFormatado { get { return CorrecaoDecimal(Creche); } }

		public string VaFormatado { get { return CorrecaoDecimal(Va); } }

		public string BabaFormatado { get { return CorrecaoDecimal(Baba); } }

		private string CorrecaoDecimal(string valor)
		{
			decimal valorConv = Convert.ToDecimal((valor != null & valor != "") ? valor : "0");
			return String.Format("{0:0.00}",  decimal.Round(valorConv, 2, MidpointRounding.AwayFromZero));
		}

		}
}
