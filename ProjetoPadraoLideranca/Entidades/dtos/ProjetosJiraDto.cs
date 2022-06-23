using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaTsdigital.Dominio.Utils;

namespace VendaTsdigital.Dominio.Entidades.dtos
{
    public class ProjetosJiraDto
    {
        public int AnoCriacao { get; set; }
        public string Status { get; set; }
        public int? MesCriacao { get; set; }
        public int? MesConclusao { get; set; }
        public string ChaveProjeto { get; set; }
        public string NomeProjeto { get; set; }
        public string CategoriaProjeto { get; set; }
        public string TipoTarefa { get; set; }
        public string Responsavel { get; set; }
        public string Author { get; set; }
        public string TempoTrabalhado { get; set; }
        public int Issuenum { get; set; }
        public string CodigoJira { get; set; }
        public DateTime Created { get; set; }

        public double DiaUtilMes { 
            get
            {
                var ano = Convert.ToInt32(MesCriacao.ToString().Substring(0, 4));
                var mes = Convert.ToInt32(MesCriacao.ToString().Substring(4, 2));
                return CalculoUtil.diasUteis(ano, mes);
            }
        }

        public double HoraUtil
        {
            get
            {
                return 168.0;
            }
        }

        public int Mes
        {
            get
            {
                return Convert.ToInt32(MesCriacao.ToString().Substring(4, 2));
            }
        }

        public int Ano
        {
            get
            {
                 return Convert.ToInt32(MesCriacao.ToString().Substring(0, 4));
            }
        }
    }
}
